using BenchmarkDotNet.Attributes;
using System.Collections.Frozen;

namespace PerfTesting.Collections;

[MemoryDiagnoser, ShortRunJob]
public class DictionaryInstantiationTests
{
    private static readonly string[] _keys10;
    private static readonly string[] _keys100;
    private static readonly string[] _keys1000;
    private static readonly string[] _keys10000;

    static DictionaryInstantiationTests()
    {
        _keys10 = GenerateKeys(10);
        _keys100 = GenerateKeys(100);
        _keys1000 = GenerateKeys(1000);
        _keys10000 = GenerateKeys(10000);
    }

    private static string[] GenerateKeys(int count)
    {
        var keys = new string[count];
        for (var i = 0; i < count; i++)
        {
            keys[i] = $"Key_{i:D6}";
        }
        return keys;
    }

    [Benchmark]
    public Dictionary<string, int> Dictionary_10_Elements()
    {
        var dict = new Dictionary<string, int>(10, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < _keys10.Length; i++)
        {
            dict[_keys10[i]] = i;
        }
        return dict;
    }

    [Benchmark]
    public Dictionary<string, int> Dictionary_100_Elements()
    {
        var dict = new Dictionary<string, int>(100, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < _keys100.Length; i++)
        {
            dict[_keys100[i]] = i;
        }
        return dict;
    }

    [Benchmark]
    public Dictionary<string, int> Dictionary_1000_Elements()
    {
        var dict = new Dictionary<string, int>(1000, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < _keys1000.Length; i++)
        {
            dict[_keys1000[i]] = i;
        }
        return dict;
    }

    [Benchmark]
    public Dictionary<string, int> Dictionary_10000_Elements()
    {
        var dict = new Dictionary<string, int>(10000, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < _keys10000.Length; i++)
        {
            dict[_keys10000[i]] = i;
        }
        return dict;
    }

    [Benchmark]
    public FrozenDictionary<string, int> FrozenDictionary_10_Elements()
    {
        var dict = new Dictionary<string, int>(10, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < _keys10.Length; i++)
        {
            dict[_keys10[i]] = i;
        }
        return dict.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    }

    [Benchmark]
    public FrozenDictionary<string, int> FrozenDictionary_100_Elements()
    {
        var dict = new Dictionary<string, int>(100, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < _keys100.Length; i++)
        {
            dict[_keys100[i]] = i;
        }
        return dict.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    }

    [Benchmark]
    public FrozenDictionary<string, int> FrozenDictionary_1000_Elements()
    {
        var dict = new Dictionary<string, int>(1000, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < _keys1000.Length; i++)
        {
            dict[_keys1000[i]] = i;
        }
        return dict.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    }

    [Benchmark]
    public FrozenDictionary<string, int> FrozenDictionary_10000_Elements()
    {
        var dict = new Dictionary<string, int>(10000, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < _keys10000.Length; i++)
        {
            dict[_keys10000[i]] = i;
        }
        return dict.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    }
}