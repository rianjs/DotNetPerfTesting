using System.Text;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Strings
{
    public class StringBuilderTests
    {
        private const string _baseQuery =
@"SELECT Foo, Bar, Baz, Qux
FROM FooBar
WHERE 1=1";

        private const string _append =
@"  AND Surname = '%'
    , AND GivenName = 'Wylis'
    , AND Alias = 'Hodor'
ORDER BY
    Surname, GivenName, Alias";

        [Benchmark]
        public void StringConstructor()
        {
            var sb = new StringBuilder(_baseQuery);
            sb.AppendLine(_append);
        }

        [Benchmark]
        public void BuilderWithAppend()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_baseQuery);
            sb.AppendLine(_append);
        }

        [Benchmark]
        public void PerfectBuffer()
        {
            var sb = new StringBuilder(_baseQuery, _baseQuery.Length + _append.Length + 2);
            sb.AppendLine(_append);
        }

        [Benchmark]
        public void NaiveBuffer()
        {
            var sb = new StringBuilder(_baseQuery, _baseQuery.Length + 256);
            sb.AppendLine(_append);
        }
    }
}
