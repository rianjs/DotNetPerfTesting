using BenchmarkDotNet.Attributes;

namespace PerfTesting.DateAndTime;

[MemoryDiagnoser, ShortRunJob]
public class DateTimeTests
{
    [Benchmark]
    public DateTime GetDateTimeNow() => DateTime.Now;

    [Benchmark]
    public DateTime GetDateTimeUtcNow() => DateTime.UtcNow;
}