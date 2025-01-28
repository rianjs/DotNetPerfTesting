using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Strings;

[MemoryDiagnoser, ShortRunJob]
public class SafeReplace
{
    [Benchmark]
    public void SafeReplaceRegexTest()
    {
        var inputs = new[]
        {
            "MAYNARD MA",
            "MA MAYNARD MA MA MA",
            "SHORT STRING WITH MA IN IT MA",
            "MA " + new string('x', 200) + " MA"  // longer string
        };

        foreach (var input in inputs)
        {
            _ = SafeReplaceRegex(input, "MA");
        }
    }

    private static string SafeReplaceRegex(string input, string searchText)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(searchText))
        {
            return input;
        }

        var pattern = $@"\b{Regex.Escape(searchText)}\b";
        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.NonBacktracking);
        return regex.Replace(input, "");
    }

    [Benchmark]
    public void SafeReplaceSplitTest()
    {
        var inputs = new[]
        {
            "MAYNARD MA",
            "MA MAYNARD MA MA MA",
            "SHORT STRING WITH MA IN IT MA",
            "MA " + new string('x', 200) + " MA"  // longer string
        };

        foreach (var input in inputs)
        {
            _ = SafeReplaceSplit(input, "MA");
        }
    }

    private static string SafeReplaceSplit(string input, string searchText)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(searchText))
        {
            return input;
        }

        var words = input.Split(' ');
        for (var i = 0; i < words.Length; i++)
        {
            if (string.Equals(words[i], searchText, StringComparison.Ordinal))
            {
                words[i] = "";
            }
        }

        return string.Join(' ', words).Trim();
    }
}