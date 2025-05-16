using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Domain;

[MemoryDiagnoser, ShortRunJob]
public class PhoneNumberExtraction
{
    private static readonly PhoneNumberFinder _finder = new();
    private static readonly string[] _samples = {
        "Payment of $50.00 to John at +14155552671",
        "Transaction #123456 from account 6789 to 16505551234",
        "Invoice #A12345 paid by 2125551212",
        "Transfer to Bob +442071234567 complete",
    };

    [Benchmark]
    public List<(string phone, string normalized)> RegexTest()
    {
        var results = new List<(string phone, string normalized)>(_samples.Length);
        foreach (var sample in _samples)
        {
            results.Add(_finder.RegexExtract(sample));
        }
        return results;
    }

    [Benchmark]
    public List<(string phone, string normalized)> NonRegexTest()
    {
        var results = new List<(string phone, string normalized)>(_samples.Length);
        foreach (var sample in _samples)
        {
            results.Add(_finder.NonRegexExtract(sample));
        }
        return results;
    }

    private class PhoneNumberFinder
    {
        private static readonly Regex _usRegex = new(@"\+?(?:\d{1,3})?(\d{10}|\d{7,15})", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.NonBacktracking);

        public (string phone, string normalized) RegexExtract(string normalizedDesc)
        {
            var match = _usRegex.Match(normalizedDesc);
            if (!match.Success)
            {
                return ("", normalizedDesc);
            }

            var phone = match.Value;
            var clean = _usRegex.Replace(normalizedDesc, "");
            return (phone, clean);
        }

        public (string phoneNumber, string normalizedDescription) NonRegexExtract(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return ("", text);
            }

            var span = text.AsSpan();
            var textLength = span.Length;

            for (var i = 0; i < textLength; i++)
            {
                // Check if we can start a potential phone number
                if (!IsDigit(span[i]) && span[i] != '+')
                {
                    continue;
                }

                // Skip + sign but track it for removal
                var startPos = i;
                if (span[i] == '+' && i + 1 < textLength)
                {
                    i++;
                }

                // Potential starting point of digits
                var digitStart = i;
                var digitCount = 0;
                var hasPrefix = false;

                // Count consecutive digits
                while (i < textLength && IsDigit(span[i]))
                {
                    digitCount++;
                    i++;
                }

                // If we potentially have a US number with prefix
                if (digitCount == 11 && span[digitStart] == '1')
                {
                    hasPrefix = true;
                }

                // Valid US phone: 10 digits or 11 digits with '1' prefix
                if (digitCount == 10 || (hasPrefix && digitCount == 11))
                {
                    // Full range to remove (including + if present)
                    var removeLength = i - startPos;

                    // Get the 10-digit number (standardized without country code)
                    var actualStart = hasPrefix ? digitStart + 1 : digitStart;
                    var actualLength = 10;

                    var phoneNumber = span.Slice(actualStart, actualLength).ToString();
                    var normalizedDescription = text.Remove(startPos, removeLength);

                    return (phoneNumber, normalizedDescription);
                }

                // Position i at the last checked character
                i--;
            }

            // No phone number found
            return ("", text);
        }

        private static bool IsDigit(char c) => c is >= '0' and <= '9';
    }
}

