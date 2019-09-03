﻿using System;
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

        private const string _bigChunk = "DE89370400440532013000DE89370400440532013000DE89370400440532013000DE89370400440532013000DE89370400440532013000DE89370400440532013000DE89370400440532013000DE89370400440532013000DE89370400440532013000DE89370400440532013000DE89370400440532013000";
        private const string _smallChunk = "DE89370400440532013000";
        private const int _chunkSize = 4;

        [Benchmark]
        public string BigChunkWithTruncation()
            => ChunkWithTruncation(_chunkSize, _bigChunk.AsSpan(), " ".AsSpan());

        [Benchmark]
        public string SmallChunkWithTruncation()
            => ChunkWithTruncation(_chunkSize, _smallChunk.AsSpan(), " ".AsSpan());

        [Benchmark]
        public string BigChunkWithConditionalAppend()
            => ChunkWithConditionalAppend(_chunkSize, _bigChunk.AsSpan(), " ".AsSpan());

        [Benchmark]
        public string SmallChunkWithConditionalAppend()
            => ChunkWithConditionalAppend(_chunkSize, _smallChunk.AsSpan(), " ".AsSpan());

        private static string ChunkWithTruncation(int chunkSize, ReadOnlySpan<char> toBeChunked, ReadOnlySpan<char> separator)
        {
            var numberOfChunks = (toBeChunked.Length / chunkSize) + 1;
            var builderCapacity = toBeChunked.Length + (numberOfChunks * separator.Length) + separator.Length;
            var builder = new StringBuilder(builderCapacity);

            for (var i = 0; i < toBeChunked.Length; i += chunkSize)
            {
                var remainingChars = toBeChunked.Length - i;
                var sliceSize = Math.Min(chunkSize, remainingChars);
                var section = toBeChunked.Slice(i, sliceSize);
                builder.Append(section);
                builder.Append(separator);
            }

            // Avoid the last branch mispredict in the loop above by unconditionally removing the trailing separator
            builder.Length -= separator.Length;

            return builder.ToString();
        }

        private static string ChunkWithConditionalAppend(int chunkSize, ReadOnlySpan<char> toBeChunked, ReadOnlySpan<char> separator)
        {
            var numberOfChunks = (toBeChunked.Length / chunkSize) + 1;
            var builderCapacity = toBeChunked.Length + (numberOfChunks * separator.Length) + separator.Length;
            var builder = new StringBuilder(builderCapacity);

            for (var i = 0; i < toBeChunked.Length; i += chunkSize)
            {
                var remainingChars = toBeChunked.Length - i;
                var sliceSize = Math.Min(chunkSize, remainingChars);
                var section = toBeChunked.Slice(i, sliceSize);
                builder.Append(section);

                if (remainingChars > sliceSize)
                {
                    builder.Append(separator);
                }
            }

            return builder.ToString();
        }
    }
}
