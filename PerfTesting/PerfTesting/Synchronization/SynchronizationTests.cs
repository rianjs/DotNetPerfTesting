﻿using System.Collections.Frozen;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Synchronization;

[MemoryDiagnoser, ShortRunJob]
public class SynchronizationTests
{
    private static readonly object _lockObject = new();
    private static readonly Dictionary<string, int> _lockDictionary = GetSampleData();
    private static readonly Dictionary<string, int> _semaphoreDictionary = GetSampleData();
    private static readonly FrozenDictionary<string, int> _frozenDictionary = GetFrozenSampleData();
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    private static Dictionary<string, int> GetSampleData()
        => Enumerable.Range(0, 16)
            .ToDictionary(val => val.ToString(), val => val, StringComparer.Ordinal);

    private static FrozenDictionary<string, int> GetFrozenSampleData()
        => Enumerable.Range(0, 16)
            .ToFrozenDictionary(val => val.ToString(), val => val, StringComparer.Ordinal);

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

    [Benchmark]
    public bool DictionaryValueExists()
    {
        return _lockDictionary.ContainsKey("9");
    }

    [Benchmark]
    public bool FrozenDictionaryValueExists()
    {
        return _frozenDictionary.ContainsKey("9");
    }
}