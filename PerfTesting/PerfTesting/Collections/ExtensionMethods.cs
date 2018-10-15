﻿using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Collections
{
    public class ExtensionMethods
    {
        private static readonly int[] _intArray = Enumerable.Range(0, 50).ToArray();

        [Benchmark]
        public List<int> ArrayToListViaExtentionMethod()
            => _intArray.ToList();

        [Benchmark]
        public List<int> ArrayToListViaConstructor()
            => new List<int>(_intArray);

        [Benchmark]
        public List<int> ArrayToListViaAddRange()
        {
            var list = new List<int>();
            list.AddRange(_intArray);
            return list;
        }

        [Benchmark]
        public List<int> ArrayToListViaInitializedAddRange()
        {
            var list = new List<int>(_intArray.Length);
            list.AddRange(_intArray);
            return list;
        }
    }
}