using BenchmarkDotNet.Running;
using PerfTesting.Collections;
using PerfTesting.DateAndTime;
using PerfTesting.Strings;
using PerfTesting.Synchronization;
using PerfTesting.Trivia;

namespace PerfTesting
{
    public class Runner
    {
        static void Main(string[] args)
        {
            // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(ExtensionMethods)));
            BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(CountSubstringTests)));
            BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(RegexTests)));
            BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(ContainsTests)));
            // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(StringBuilderTests)));
            // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(SynchronizationTests)));
            // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(DateTimeTests)));
            // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(MathTrivia)));
            // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(NodaTimeShootout)));
        }
    }
}
