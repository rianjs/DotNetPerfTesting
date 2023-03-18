using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Strings
{
    public class RegexTests
    {
        private const string _needle = "the";

        [Benchmark]
        public Regex GetCompiled() => new(_needle, RegexOptions.Compiled);

        [Benchmark]
        public Regex GetUncompiled() => new(_needle);

        [Benchmark]
        public void StaticRegexIsMatch()
        {
            var bigMatch = Regex.IsMatch(Strings.Haystack, _needle);
            var smallMatch = Regex.IsMatch(Strings.SmallHaystack, _needle);
        }

        private static readonly Regex _precompiled = new(_needle, RegexOptions.Compiled);

        [Benchmark]
        public void CachedPrecompiledRegexIsMatch()
        {
            var bigMatch = _precompiled.IsMatch(Strings.Haystack);
            var smallMatch = _precompiled.IsMatch(Strings.SmallHaystack);
        }

        private static readonly Regex _uncompiled = new(_needle);

        [Benchmark]
        public void CachedUncompiledRegexIsMatch()
        {
            var bigMatch = _uncompiled.IsMatch(Strings.Haystack);
            var smallMatch = _uncompiled.IsMatch(Strings.SmallHaystack);
        }

        [Benchmark]
        public void InlineInstantiation()
        {
            var bigMatch = new Regex(_needle).IsMatch(Strings.Haystack);
            var smallMatch = new Regex(_needle).IsMatch(Strings.SmallHaystack);
        }
    }
}
