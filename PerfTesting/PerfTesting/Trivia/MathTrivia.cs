using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Trivia
{
    public class MathTrivia
    {
        //private static readonly IReadOnlyList<int> IntCollection = Enumerable.Range(0, 100).ToList().AsReadOnly();
        private const int _odd = 99;
        private const int _even = 98;

        [Benchmark]
        public bool ModuloIsEven()
        {
            var evenIsEven = _even % 2 == 0;
            var oddIsOdd = _odd % 2 == 1;
            return evenIsEven && oddIsOdd;
        }

        [Benchmark]
        public bool BitwiseIsEven()
        {
            var evenIsEven = (_even & 1) == 0;
            var oddIsOdd = (_odd & 1) == 1;
            return evenIsEven && oddIsOdd;
        }
    }
}