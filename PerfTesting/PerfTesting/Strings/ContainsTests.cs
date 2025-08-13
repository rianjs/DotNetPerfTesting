using BenchmarkDotNet.Attributes;

namespace PerfTesting.Strings;

[MemoryDiagnoser, ShortRunJob]
public class ContainsTests
{
    private const string _needle = "the";

    [Benchmark]
    public bool StringContainsOrdinal()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.Ordinal);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.Ordinal);
        return bigMatch || smallMatch;
    }

    [Benchmark]
    public bool StringContainsOrdinalIgnoreCase()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.OrdinalIgnoreCase);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.OrdinalIgnoreCase);
        return bigMatch || smallMatch;
    }

    [Benchmark]
    public bool StringContainsInvariantCulture()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.InvariantCulture);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.InvariantCulture);
        return bigMatch || smallMatch;
    }

    [Benchmark]
    public bool StringContainsInvariantCultureIgnoreCase()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.InvariantCultureIgnoreCase);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.InvariantCultureIgnoreCase);
        return bigMatch || smallMatch;
    }

    [Benchmark]
    public bool StringContainsCurrentCulture()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.CurrentCulture);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.CurrentCulture);
        return bigMatch || smallMatch;
    }

    [Benchmark]
    public bool StringContainsCurrentCultureIgnoreCase()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.CurrentCultureIgnoreCase);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.CurrentCultureIgnoreCase);
        return bigMatch || smallMatch;
    }
}