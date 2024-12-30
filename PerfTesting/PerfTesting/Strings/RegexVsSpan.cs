using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Strings;

[MemoryDiagnoser, ShortRunJob]
public class RegexVsSpan
{
    /// <summary>
    /// Transaction blobs are written to S3 with the following suffix: -YYYY-txns.json.gz, where any string can come before that (numbers, guid, etc.).
    /// This method returns the YYYY component if there is one, otherwise an empty string.
    /// </summary>
    public static string FindYearString(string i)
        => FindYear(i).ToString();

    /// <summary>
    /// Transaction blobs are written to S3 with the following suffix: -YYYY-txns.json.gz, where any string can come before that (numbers, guid, etc.).
    /// This method returns the YYYY component if there is one, otherwise an empty string.
    /// </summary>
    public static ReadOnlySpan<char> FindYear(string i)
    {
        var lastDashIdx = i.LastIndexOf('-');
        if (lastDashIdx < 4)
        {
            return string.Empty;
        }

        var charCount = 0;
        for (var j = lastDashIdx - 1; j >= 0; j--)
        {
            var c = i[j];
            if (!char.IsNumber(c))
            {
                break;
            }

            charCount++;
        }

        if (charCount != 4)
        {
            return string.Empty;
        }

        var startIndex = lastDashIdx - charCount;
        return i.AsSpan(startIndex, 4);
    }


    private static readonly Regex _findYearRegex = new Regex(@"-(\d{4})-txns\.json\.gz$",
        RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.NonBacktracking);
    public static string FindYearRegex(string i)
    {
        var match = _findYearRegex.Match(i);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }

    private static readonly string[] _testCases =
    [
        "113858-2024-txns.json.gz",
        "outdata-data-2024-txns.json.gz",
        "outdatadata-2024txns.json.gz",
        "outdata-data-202-txns.json.gz",
        "outdatadata2024txns.json.gz",
        "foo",
        "outdata-202a-txns.json.gz",
        "outdata-20242-txns.json.gz",
        "outdata--2024-txns.json.gz",
        "outdata-0000-txns.json.gz",
        "outdata-9999-txns.json.gz",
        "outdata-2024-txns.json.gz.backup",
        "outdata-2024-TXNS.json.gz",
        "outdata-2024-.json.gz",
        "-2024-txns.json.gz",
        "2024-txns.json.gz",
        "",
        "-",
    ];

    [Benchmark]
    public void FindYearStringTests()
    {
        foreach (var i in _testCases)
        {
            var result = FindYearString(i);
        }
    }

    [Benchmark]
    public void FindYearTests()
    {
        foreach (var i in _testCases)
        {
            var result = FindYear(i);
        }
    }

    [Benchmark]
    public void FindYearRegexTests()
    {
        foreach (var i in _testCases)
        {
            var result = FindYearRegex(i);
        }
    }
}

