using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Strings;

[MemoryDiagnoser, ShortRunJob]
public class CountSubstringTests
{
    private const string _needle = "the";

    private static readonly string[] _split = [_needle];
    private static readonly Regex _compiled = new(_needle, RegexOptions.Compiled);

    [Benchmark]
    public int CountSmallWithSplit() => Strings.SmallHaystack.Split(_split, StringSplitOptions.None).Length - 1;

    [Benchmark]
    public int CountBigWithSplit() => Strings.Haystack.Split(_split, StringSplitOptions.None).Length - 1;

    [Benchmark]
    public int CountSmallWithCompiledRegex() => _compiled.Matches(Strings.SmallHaystack).Count;

    [Benchmark]
    public int CountBigWithCompiledRegex() => _compiled.Matches(Strings.Haystack).Count;

    [Benchmark]
    public int CountSmallWithRegex() => new Regex(_needle).Matches(Strings.SmallHaystack).Count;

    [Benchmark]
    public int CountBigWithRegex() => new Regex(_needle).Matches(Strings.Haystack).Count;

    [Benchmark]
    public int CountSmallWithStaticRegex() => Regex.Matches(Strings.SmallHaystack, _needle).Count;

    [Benchmark]
    public int CountBigWithStaticRegex() => Regex.Matches(Strings.Haystack, _needle).Count;

    [Benchmark]
    public bool SearchBigWithCompiledRegex()
    {
        var compiled = new Regex(_needle, RegexOptions.Compiled);
        var search = compiled.Match(Strings.Haystack);
        return search.Success;
    }

    [Benchmark]
    public bool SearchBigWithRegex()
    {
        var regex = new Regex(_needle);
        var search = regex.Match(Strings.Haystack);
        return search.Success;
    }

    [Benchmark]
    public int CountSmallWithIndexOf()
    {
        var text = Strings.SmallHaystack;
        int count = 0, index = 0;
        while ((index = text.IndexOf(_needle, index)) != -1)
        {
            count++;
            index += _needle.Length;
        }
        return count;
    }

    [Benchmark]
    public int CountBigWithIndexOf()
    {
        var text = Strings.Haystack;
        int count = 0, index = 0;
        while ((index = text.IndexOf(_needle, index)) != -1)
        {
            count++;
            index += _needle.Length;
        }
        return count;
    }

    [Benchmark]
    public int CountSmallWithIndexOfOrdinal()
    {
        var text = Strings.SmallHaystack;
        int count = 0, index = 0;
        while ((index = text.IndexOf(_needle, index, StringComparison.Ordinal)) != -1)
        {
            count++;
            index += _needle.Length;
        }
        return count;
    }

    [Benchmark]
    public int CountBigWithIndexOfOrdinal()
    {
        var text = Strings.Haystack;
        int count = 0, index = 0;
        while ((index = text.IndexOf(_needle, index, StringComparison.Ordinal)) != -1)
        {
            count++;
            index += _needle.Length;
        }
        return count;
    }

    [Benchmark]
    public int CountSmallWithSpan()
    {
        ReadOnlySpan<char> text = Strings.SmallHaystack.AsSpan();
        ReadOnlySpan<char> needle = _needle.AsSpan();
        int count = 0, index = 0;
        while ((index = text.Slice(index).IndexOf(needle)) != -1)
        {
            count++;
            index += needle.Length;
        }
        return count;
    }

    [Benchmark]
    public int CountBigWithSpan()
    {
        ReadOnlySpan<char> text = Strings.Haystack.AsSpan();
        ReadOnlySpan<char> needle = _needle.AsSpan();
        int count = 0, index = 0;
        while ((index = text.Slice(index).IndexOf(needle)) != -1)
        {
            count++;
            index += needle.Length;
        }
        return count;
    }

    [Benchmark]
    public int CountSmallWithReplace() => (Strings.SmallHaystack.Length - Strings.SmallHaystack.Replace(_needle, "").Length) / _needle.Length;

    [Benchmark]
    public int CountBigWithReplace() => (Strings.Haystack.Length - Strings.Haystack.Replace(_needle, "").Length) / _needle.Length;
}