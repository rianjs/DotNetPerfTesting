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
}