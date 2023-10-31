using BenchmarkDotNet.Attributes;

namespace PerfTesting.Trivia
{
    public class MathTrivia
    {
        private static readonly IReadOnlyList<int> IntCollection = Enumerable.Range(0, 100).ToList().AsReadOnly();

        [Benchmark]
        public bool ModuloIsEven()
        {
            var result = false;
            foreach (var element in IntCollection)
            {
                var evenIsEven = element % 2 == 0;
                var oddIsOdd = element % 2 == 1;
                result = evenIsEven && oddIsOdd;
            }

            return result;
        }

        [Benchmark]
        public bool BitwiseIsEven()
        {
            var result = false; 
            foreach (var element in IntCollection)
            {
                var evenIsEven = (element & 1) == 0;
                var oddIsOdd = (element & 1) == 1;
                result = evenIsEven && oddIsOdd;
            }

            return result;
        }
    }
}