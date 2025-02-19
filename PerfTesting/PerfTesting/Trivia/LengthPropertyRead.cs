using BenchmarkDotNet.Attributes;

namespace PerfTesting.Trivia;

[MemoryDiagnoser, ShortRunJob]
public class LengthPropertyRead
{
    [Benchmark]
    public string InlinePropertyRead()
    {
        var trimRear = "-2024.json.gz".Length;
        const string someString = "_core/12345/67890-2024.json.gz";
        return someString[..^trimRear];
    }

    private static readonly int _length = "-2024.json.gz".Length;

    [Benchmark]
    public string StaticCacheRead()
    {
        const string someString = "_core/12345/67890-2024.json.gz";
        return someString[..^_length];
    }

    [Benchmark]
    public string ConstRead()
    {
        var someString = "_core/12345/67890-2024.json.gz";
        return someString[..^13];
    }
}