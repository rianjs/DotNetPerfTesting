using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Strings
{
    public class RegexTests
    {
        private const string _pattern = "the";

        [Benchmark]
        public Regex GetCompiled() => new Regex(_pattern, RegexOptions.Compiled);

        [Benchmark]
        public Regex GetUncompiled() => new Regex(_pattern);

    }
}
