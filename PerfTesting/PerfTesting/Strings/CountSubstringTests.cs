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
    public int CountSmallWithSplit() => Strings.SmallHaystack.Split(_split, StringSplitOptions.None).Length;

    [Benchmark]
    public int CountBigWithSplit() => Strings.Haystack.Split(_split, StringSplitOptions.None).Length;

    [Benchmark]
    public int CountSmallWithCompiledRegex() => _compiled.Match(Strings.SmallHaystack).Length;

    [Benchmark]
    public int CountBigWithCompiledRegex() => _compiled.Match(Strings.Haystack).Length;

    [Benchmark]
    public int CountSmallWithRegex() => new Regex(_needle).Match(Strings.SmallHaystack).Length;

    [Benchmark]
    public int CountBigWithRegex() => new Regex(_needle).Match(Strings.Haystack).Length;

    [Benchmark]
    public int CountSmallWithStaticRegex() => Regex.Match(Strings.SmallHaystack, _needle).Length;

    [Benchmark]
    public int CountBigWithStaticRegex() => Regex.Match(Strings.Haystack, _needle).Length;

    [Benchmark]
    public void SearchBigWithCompiledRegex()
    {
        var compiled = new Regex(_needle, RegexOptions.Compiled);
        var search = compiled.Match(Strings.Haystack);
    }

    [Benchmark]
    public void SearchBigWithRegex()
    {
        var regex = new Regex(_needle);
        var search = regex.Match(Strings.Haystack);
    }
}