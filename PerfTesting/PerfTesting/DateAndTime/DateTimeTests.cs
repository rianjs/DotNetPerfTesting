using BenchmarkDotNet.Attributes;

namespace PerfTesting.DateAndTime
{
    public class DateTimeTests
    {
        [Benchmark]
        public DateTime GetDateTimeNow() => DateTime.Now;

        [Benchmark]
        public DateTime GetDateTimeUtcNow() => DateTime.UtcNow;
    }
}
