using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Synchronization
{
    public class SynchronizationTests
    {
        private static readonly object _lockObject = new object();
        private static readonly Dictionary<string, int> _lockDictionary = GetSampleData();
        private static readonly Dictionary<string, int> _semaphoreDictionary = GetSampleData();
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        private static Dictionary<string, int> GetSampleData()
            => Enumerable.Range(0, 16)
                .ToDictionary(val => val.ToString(), val => val, StringComparer.Ordinal);

        [Benchmark]
        public async Task<bool> SemaphoreSlimValueExists()
        {
            try
            {
                await _semaphore.WaitAsync();
                return _semaphoreDictionary.ContainsKey("9");
            }
            finally
            {
                _semaphore.Release();
            }
        }

        [Benchmark]
        public bool LockDictionaryValueExists()
        {
            lock (_lockObject)
            {
                return _lockDictionary.ContainsKey("9");
            }
        }
    }
}