using System;
using BenchmarkDotNet.Attributes;
using NodaTime.Text;

namespace PerfTesting.DateAndTime
{
    public class NodaTimeShootout
    {
        private static readonly string _isoUtcString = DateTime.UtcNow.ToString("O");

        [Benchmark]
        public DateTime DateTimeParse() => DateTime.Parse(_isoUtcString).ToUniversalTime();

        [Benchmark]
        public DateTime InstantPatternParse() => InstantPattern.ExtendedIso.Parse(_isoUtcString).Value.ToDateTimeUtc();
    }
}
