using System;
using System.IO;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess;
using PerfTesting.Strings;

namespace PerfTesting
{
    public class Runner
    {
        static void Main(string[] args)
        {
            BenchmarkRunnerCore.Run(BenchmarkConverter.TypeToBenchmarks(typeof(Substrings)), t => InProcessToolchain.Instance);
        }
    }
}
