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


    private static readonly List<Guid> _sortedList = InitGuidSortedList();
    private static Guid _sortedListNeedle;
    private static List<Guid> InitGuidSortedList()
    {
        var l = new List<Guid>(100);
        for (var i = 0; i < 100; i++)
        {
            var g = new Guid();
            l.Add(g);
            if (i == 67)
            {
                _sortedListNeedle = g;
            }
        }

        l.Sort();
        return l;
    }

    [Benchmark]
    public bool ListBinarySearch()
    {
        var index = _sortedList.BinarySearch(_sortedListNeedle);
        return index >= 0;
    }
}