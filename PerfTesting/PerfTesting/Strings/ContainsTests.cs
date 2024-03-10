using BenchmarkDotNet.Attributes;

namespace PerfTesting.Strings;

[MemoryDiagnoser, ShortRunJob]
public class ContainsTests
{
    private const string _needle = "the";

    [Benchmark]
    public void StringContainsOrdinal()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.Ordinal);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.Ordinal);
    }

    [Benchmark]
    public void StringContainsOrdinalIgnoreCase()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.OrdinalIgnoreCase);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.OrdinalIgnoreCase);
    }

    [Benchmark]
    public void StringContainsInvariantCulture()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.InvariantCulture);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.InvariantCulture);
    }

    [Benchmark]
    public void StringContainsInvariantCultureIgnoreCase()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.InvariantCultureIgnoreCase);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.InvariantCultureIgnoreCase);
    }

    [Benchmark]
    public void StringContainsCurrentCulture()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.CurrentCulture);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.CurrentCulture);
    }

    [Benchmark]
    public void StringContainsCurrentCultureIgnoreCase()
    {
        var bigMatch = Strings.Haystack.Contains(_needle, StringComparison.CurrentCultureIgnoreCase);
        var smallMatch = Strings.SmallHaystack.Contains(_needle, StringComparison.CurrentCultureIgnoreCase);
    }
}