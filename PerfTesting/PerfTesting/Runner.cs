﻿using BenchmarkDotNet.Running;
using PerfTesting.Boxing;
using PerfTesting.Collections;
using PerfTesting.DateAndTime;
using PerfTesting.Domain;
using PerfTesting.Linq;
using PerfTesting.Reflection;
using PerfTesting.Strings;
using PerfTesting.Synchronization;
using PerfTesting.Trivia;

namespace PerfTesting;

public class Runner
{
    static void Main(string[] args)
    {
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(ExtensionMethods)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(CountSubstringTests)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(RegexTests)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(ContainsTests)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(GuidTest)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(StringBuilderTests)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(SynchronizationTests)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(DateTimeTests)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(MathTrivia)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(NodaTimeShootout)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(ClassBoxTests)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(StructBoxTests)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(RegexVsSpan)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(ReflectionTests)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(SafeReplace)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(LengthPropertyRead)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(PredicateLocation)));
        // BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(PhoneNumberExtraction)));
        BenchmarkRunner.Run(BenchmarkConverter.TypeToBenchmarks(typeof(RecomposeTests)));
    }
}