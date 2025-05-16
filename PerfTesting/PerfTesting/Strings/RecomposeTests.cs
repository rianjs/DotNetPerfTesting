using System.Text;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Strings;

[MemoryDiagnoser, ShortRunJob]
public class RecomposeTests
{
    public string RecomposeSplit(string source)
    {
        var splitQuery = source.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return string.Join(' ', splitQuery);
    }

    [Benchmark]
    public string ShortStringSplit() => RecomposeSplit(Strings.SmallHaystack);

    [Benchmark]
    public string LongStringSplit() => RecomposeSplit(Strings.Haystack);

    public string RecomposeSpan(string source)
    {
        if (string.IsNullOrWhiteSpace(source))
        {
            return string.Empty;
        }

        // Use stack for smaller strings, heap for larger ones
        var buffer = source.Length <= 1024
            ? stackalloc char[source.Length]
            : new char[source.Length];

        var writeIndex = 0;
        var previousWasSpace = true;

        for (var i = 0; i < source.Length; i++)
        {
            var c = source[i];
            if (c == ' ')
            {
                if (!previousWasSpace)
                {
                    buffer[writeIndex++] = ' ';
                    previousWasSpace = true;
                }
            }
            else
            {
                buffer[writeIndex++] = c;
                previousWasSpace = false;
            }
        }

        // Trim trailing space if present
        if (previousWasSpace && writeIndex > 0)
        {
            writeIndex--;
        }

        return new string(buffer[..writeIndex]);
    }

    [Benchmark]
    public string ShortStringSpan() => RecomposeSpan(Strings.SmallHaystack);

    [Benchmark]
    public string LongStringSpan() => RecomposeSpan(Strings.Haystack);

    public static string RecomposeStringBuilder(string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return string.Empty;
        }

        var sb = new StringBuilder(source.Length);
        var previousWasSpace = true; // Start true to handle leading spaces

        foreach (var c in source)
        {
            if (c == ' ')
            {
                if (!previousWasSpace)
                {
                    sb.Append(' ');
                    previousWasSpace = true;
                }
            }
            else
            {
                sb.Append(c);
                previousWasSpace = false;
            }
        }

        // Remove trailing space if present
        if (previousWasSpace && sb.Length > 0)
        {
            sb.Length--;
        }

        return sb.ToString();
    }

    [Benchmark]
    public string ShortStringBuilder() => RecomposeStringBuilder(Strings.SmallHaystack);

    [Benchmark]
    public string LongStringBuilder() => RecomposeStringBuilder(Strings.Haystack);
}