using BenchmarkDotNet.Attributes;
using System.Collections.Frozen;

namespace PerfTesting.Collections;

[MemoryDiagnoser, ShortRunJob]
public class DictionaryLookupTests
{
    private static readonly Dictionary<string, int> _dict10;
    private static readonly Dictionary<string, int> _dict100;
    private static readonly Dictionary<string, int> _dict1000;
    private static readonly Dictionary<string, int> _dict10000;
    private static readonly FrozenDictionary<string, int> _frozenDict10;
    private static readonly FrozenDictionary<string, int> _frozenDict100;
    private static readonly FrozenDictionary<string, int> _frozenDict1000;
    private static readonly FrozenDictionary<string, int> _frozenDict10000;
    
    private static readonly string _key10;
    private static readonly string _key100;
    private static readonly string _key1000;
    private static readonly string _key10000;
    private const string _nonExistentKey = "NonExistent_Key_999999";

    static DictionaryLookupTests()
    {
        var keys10 = GenerateKeys(10);
        var keys100 = GenerateKeys(100);
        var keys1000 = GenerateKeys(1000);
        var keys10000 = GenerateKeys(10000);

        _dict10 = CreateDictionary(keys10);
        _dict100 = CreateDictionary(keys100);
        _dict1000 = CreateDictionary(keys1000);
        _dict10000 = CreateDictionary(keys10000);

        _frozenDict10 = _dict10.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
        _frozenDict100 = _dict100.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
        _frozenDict1000 = _dict1000.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
        _frozenDict10000 = _dict10000.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);

        _key10 = keys10[(int)(10 * 0.67)];
        _key100 = keys100[(int)(100 * 0.67)];
        _key1000 = keys1000[(int)(1000 * 0.67)];
        _key10000 = keys10000[(int)(10000 * 0.67)];
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

    private static Dictionary<string, int> CreateDictionary(string[] keys)
    {
        var dict = new Dictionary<string, int>(keys.Length, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < keys.Length; i++)
        {
            dict[keys[i]] = i;
        }
        return dict;
    }

    [Benchmark]
    public bool Dictionary_10_Elements_Success()
        => _dict10.ContainsKey(_key10);

    [Benchmark]
    public bool Dictionary_100_Elements_Success()
        => _dict100.ContainsKey(_key100);

    [Benchmark]
    public bool Dictionary_1000_Elements_Success()
        => _dict1000.ContainsKey(_key1000);

    [Benchmark]
    public bool Dictionary_10000_Elements_Success()
        => _dict10000.ContainsKey(_key10000);

    [Benchmark]
    public bool Dictionary_10_Elements_Fail()
        => _dict10.ContainsKey(_nonExistentKey);

    [Benchmark]
    public bool Dictionary_100_Elements_Fail()
        => _dict100.ContainsKey(_nonExistentKey);

    [Benchmark]
    public bool Dictionary_1000_Elements_Fail()
        => _dict1000.ContainsKey(_nonExistentKey);

    [Benchmark]
    public bool Dictionary_10000_Elements_Fail()
        => _dict10000.ContainsKey(_nonExistentKey);

    [Benchmark]
    public bool FrozenDictionary_10_Elements_Success()
        => _frozenDict10.ContainsKey(_key10);

    [Benchmark]
    public bool FrozenDictionary_100_Elements_Success()
        => _frozenDict100.ContainsKey(_key100);

    [Benchmark]
    public bool FrozenDictionary_1000_Elements_Success()
        => _frozenDict1000.ContainsKey(_key1000);

    [Benchmark]
    public bool FrozenDictionary_10000_Elements_Success()
        => _frozenDict10000.ContainsKey(_key10000);

    [Benchmark]
    public bool FrozenDictionary_10_Elements_Fail()
        => _frozenDict10.ContainsKey(_nonExistentKey);

    [Benchmark]
    public bool FrozenDictionary_100_Elements_Fail()
        => _frozenDict100.ContainsKey(_nonExistentKey);

    [Benchmark]
    public bool FrozenDictionary_1000_Elements_Fail()
        => _frozenDict1000.ContainsKey(_nonExistentKey);

    [Benchmark]
    public bool FrozenDictionary_10000_Elements_Fail()
        => _frozenDict10000.ContainsKey(_nonExistentKey);
}