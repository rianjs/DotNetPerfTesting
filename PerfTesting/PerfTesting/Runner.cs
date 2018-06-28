using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess;
using PerfTesting.Strings;

namespace PerfTesting
{
    public class Runner
    {
        static void Main(string[] args)
        {
            BenchmarkRunnerCore.Run(BenchmarkConverter.TypeToBenchmarks(typeof(SubstringTests)), t => InProcessToolchain.Instance);
            BenchmarkRunnerCore.Run(BenchmarkConverter.TypeToBenchmarks(typeof(RegexTests)), t => InProcessToolchain.Instance);
            BenchmarkRunnerCore.Run(BenchmarkConverter.TypeToBenchmarks(typeof(StringBuilderTests)), t => InProcessToolchain.Instance);
        }
    }
}
