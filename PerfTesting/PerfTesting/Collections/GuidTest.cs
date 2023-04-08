using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Collections;

public class GuidTest
{
    private static readonly List<Guid> _guidList = GetGuidList();
    private static List<Guid> GetGuidList()
    {
        var q = Enumerable.Range(0, 100).Select(_ => new Guid()).ToList();
        q.TrimExcess();
        return q;
    }

    [Benchmark]
    public bool ListContains()
    {
        var needle = _guidList[67];
        return _guidArray.Contains(needle);
    }

    private static readonly Guid[] _guidArray = GetGuidArray();
    private static Guid[] GetGuidArray()
        => Enumerable.Range(0, 100).Select(_ => new Guid()).ToArray();

    [Benchmark]
    public bool ArrayContains()
    {
        var needle = _guidArray[67];
        return _guidArray.Contains(needle);
    }

    private static readonly HashSet<Guid> _guidSet = InitGuidSet();
    private static Guid _setNeedle;
    private static HashSet<Guid> InitGuidSet()
    {
        var q = Enumerable.Range(0, 100).Select(_ => new Guid()).ToHashSet();
        q.TrimExcess();

        var i = 0;
        foreach (var g in q)
        {
            if (i == 67)
            {
                _setNeedle = g;
            }

            i++;
        }
        return q;
    }

    [Benchmark]
    public bool HashSetContains()
    {
        return _guidSet.Contains(_setNeedle);
    }
}