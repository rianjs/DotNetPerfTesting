using BenchmarkDotNet.Attributes;

namespace PerfTesting.Types;

[MemoryDiagnoser, ShortRunJob]
public class TypeEqualityTests
{
    // Small types (16 bytes)
    private static readonly SmallStruct _smallStruct1 = new(1, 2, 3, 4);
    private static readonly SmallStruct _smallStruct2 = new(1, 2, 3, 4);
    private static readonly SmallStruct _smallStruct3 = new(5, 6, 7, 8);
    
    private static readonly SmallRecord _smallRecord1 = new(1, 2, 3, 4);
    private static readonly SmallRecord _smallRecord2 = new(1, 2, 3, 4);
    private static readonly SmallRecord _smallRecord3 = new(5, 6, 7, 8);
    
    private static readonly SmallReadonlyRecordStruct _smallReadonlyRecordStruct1 = new(1, 2, 3, 4);
    private static readonly SmallReadonlyRecordStruct _smallReadonlyRecordStruct2 = new(1, 2, 3, 4);
    private static readonly SmallReadonlyRecordStruct _smallReadonlyRecordStruct3 = new(5, 6, 7, 8);
    
    private static readonly SmallReadonlyStruct _smallReadonlyStruct1 = new(1, 2, 3, 4);
    private static readonly SmallReadonlyStruct _smallReadonlyStruct2 = new(1, 2, 3, 4);
    private static readonly SmallReadonlyStruct _smallReadonlyStruct3 = new(5, 6, 7, 8);

    // Large types (32+ bytes)
    private static readonly LargeStruct _largeStruct1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeStruct _largeStruct2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeStruct _largeStruct3 = new(9, 10, 11, 12, 13, 14, 15, 16);
    
    private static readonly LargeRecord _largeRecord1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeRecord _largeRecord2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeRecord _largeRecord3 = new(9, 10, 11, 12, 13, 14, 15, 16);
    
    private static readonly LargeReadonlyRecordStruct _largeReadonlyRecordStruct1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeReadonlyRecordStruct _largeReadonlyRecordStruct2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeReadonlyRecordStruct _largeReadonlyRecordStruct3 = new(9, 10, 11, 12, 13, 14, 15, 16);
    
    private static readonly LargeReadonlyStruct _largeReadonlyStruct1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeReadonlyStruct _largeReadonlyStruct2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeReadonlyStruct _largeReadonlyStruct3 = new(9, 10, 11, 12, 13, 14, 15, 16);

    // Unoptimized struct types (no IEquatable implementation)
    private static readonly SmallStructUnoptimized _smallStructUnoptimized1 = new(1, 2, 3, 4);
    private static readonly SmallStructUnoptimized _smallStructUnoptimized2 = new(1, 2, 3, 4);
    private static readonly SmallStructUnoptimized _smallStructUnoptimized3 = new(5, 6, 7, 8);
    
    private static readonly SmallReadonlyStructUnoptimized _smallReadonlyStructUnoptimized1 = new(1, 2, 3, 4);
    private static readonly SmallReadonlyStructUnoptimized _smallReadonlyStructUnoptimized2 = new(1, 2, 3, 4);
    private static readonly SmallReadonlyStructUnoptimized _smallReadonlyStructUnoptimized3 = new(5, 6, 7, 8);
    
    private static readonly LargeStructUnoptimized _largeStructUnoptimized1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeStructUnoptimized _largeStructUnoptimized2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeStructUnoptimized _largeStructUnoptimized3 = new(9, 10, 11, 12, 13, 14, 15, 16);
    
    private static readonly LargeReadonlyStructUnoptimized _largeReadonlyStructUnoptimized1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeReadonlyStructUnoptimized _largeReadonlyStructUnoptimized2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly LargeReadonlyStructUnoptimized _largeReadonlyStructUnoptimized3 = new(9, 10, 11, 12, 13, 14, 15, 16);

    private static readonly HashSet<SmallStruct> _smallStructSet = new() { _smallStruct1, _smallStruct3 };
    private static readonly HashSet<SmallRecord> _smallRecordSet = new() { _smallRecord1, _smallRecord3 };
    private static readonly HashSet<SmallReadonlyRecordStruct> _smallReadonlyRecordStructSet = new() { _smallReadonlyRecordStruct1, _smallReadonlyRecordStruct3 };
    private static readonly HashSet<SmallReadonlyStruct> _smallReadonlyStructSet = new() { _smallReadonlyStruct1, _smallReadonlyStruct3 };
    
    private static readonly HashSet<LargeStruct> _largeStructSet = new() { _largeStruct1, _largeStruct3 };
    private static readonly HashSet<LargeRecord> _largeRecordSet = new() { _largeRecord1, _largeRecord3 };
    private static readonly HashSet<LargeReadonlyRecordStruct> _largeReadonlyRecordStructSet = new() { _largeReadonlyRecordStruct1, _largeReadonlyRecordStruct3 };
    private static readonly HashSet<LargeReadonlyStruct> _largeReadonlyStructSet = new() { _largeReadonlyStruct1, _largeReadonlyStruct3 };
    
    private static readonly HashSet<SmallStructUnoptimized> _smallStructUnoptimizedSet = new() { _smallStructUnoptimized1, _smallStructUnoptimized3 };
    private static readonly HashSet<SmallReadonlyStructUnoptimized> _smallReadonlyStructUnoptimizedSet = new() { _smallReadonlyStructUnoptimized1, _smallReadonlyStructUnoptimized3 };
    private static readonly HashSet<LargeStructUnoptimized> _largeStructUnoptimizedSet = new() { _largeStructUnoptimized1, _largeStructUnoptimized3 };
    private static readonly HashSet<LargeReadonlyStructUnoptimized> _largeReadonlyStructUnoptimizedSet = new() { _largeReadonlyStructUnoptimized1, _largeReadonlyStructUnoptimized3 };

    // Equality Tests - Small Types
    [Benchmark] public bool SmallStruct_EqualityEqual() => _smallStruct1 == _smallStruct2;
    [Benchmark] public bool SmallStruct_EqualityNotEqual() => _smallStruct1 == _smallStruct3;
    [Benchmark] public bool SmallStruct_EqualsEqual() => _smallStruct1.Equals(_smallStruct2);
    [Benchmark] public bool SmallStruct_EqualsNotEqual() => _smallStruct1.Equals(_smallStruct3);

    [Benchmark] public bool SmallRecord_EqualityEqual() => _smallRecord1 == _smallRecord2;
    [Benchmark] public bool SmallRecord_EqualityNotEqual() => _smallRecord1 == _smallRecord3;
    [Benchmark] public bool SmallRecord_EqualsEqual() => _smallRecord1.Equals(_smallRecord2);
    [Benchmark] public bool SmallRecord_EqualsNotEqual() => _smallRecord1.Equals(_smallRecord3);

    [Benchmark] public bool SmallReadonlyRecordStruct_EqualityEqual() => _smallReadonlyRecordStruct1 == _smallReadonlyRecordStruct2;
    [Benchmark] public bool SmallReadonlyRecordStruct_EqualityNotEqual() => _smallReadonlyRecordStruct1 == _smallReadonlyRecordStruct3;
    [Benchmark] public bool SmallReadonlyRecordStruct_EqualsEqual() => _smallReadonlyRecordStruct1.Equals(_smallReadonlyRecordStruct2);
    [Benchmark] public bool SmallReadonlyRecordStruct_EqualsNotEqual() => _smallReadonlyRecordStruct1.Equals(_smallReadonlyRecordStruct3);

    [Benchmark] public bool SmallReadonlyStruct_EqualityEqual() => _smallReadonlyStruct1 == _smallReadonlyStruct2;
    [Benchmark] public bool SmallReadonlyStruct_EqualityNotEqual() => _smallReadonlyStruct1 == _smallReadonlyStruct3;
    [Benchmark] public bool SmallReadonlyStruct_EqualsEqual() => _smallReadonlyStruct1.Equals(_smallReadonlyStruct2);
    [Benchmark] public bool SmallReadonlyStruct_EqualsNotEqual() => _smallReadonlyStruct1.Equals(_smallReadonlyStruct3);

    // Equality Tests - Large Types
    [Benchmark] public bool LargeStruct_EqualityEqual() => _largeStruct1 == _largeStruct2;
    [Benchmark] public bool LargeStruct_EqualityNotEqual() => _largeStruct1 == _largeStruct3;
    [Benchmark] public bool LargeStruct_EqualsEqual() => _largeStruct1.Equals(_largeStruct2);
    [Benchmark] public bool LargeStruct_EqualsNotEqual() => _largeStruct1.Equals(_largeStruct3);

    [Benchmark] public bool LargeRecord_EqualityEqual() => _largeRecord1 == _largeRecord2;
    [Benchmark] public bool LargeRecord_EqualityNotEqual() => _largeRecord1 == _largeRecord3;
    [Benchmark] public bool LargeRecord_EqualsEqual() => _largeRecord1.Equals(_largeRecord2);
    [Benchmark] public bool LargeRecord_EqualsNotEqual() => _largeRecord1.Equals(_largeRecord3);

    [Benchmark] public bool LargeReadonlyRecordStruct_EqualityEqual() => _largeReadonlyRecordStruct1 == _largeReadonlyRecordStruct2;
    [Benchmark] public bool LargeReadonlyRecordStruct_EqualityNotEqual() => _largeReadonlyRecordStruct1 == _largeReadonlyRecordStruct3;
    [Benchmark] public bool LargeReadonlyRecordStruct_EqualsEqual() => _largeReadonlyRecordStruct1.Equals(_largeReadonlyRecordStruct2);
    [Benchmark] public bool LargeReadonlyRecordStruct_EqualsNotEqual() => _largeReadonlyRecordStruct1.Equals(_largeReadonlyRecordStruct3);

    [Benchmark] public bool LargeReadonlyStruct_EqualityEqual() => _largeReadonlyStruct1 == _largeReadonlyStruct2;
    [Benchmark] public bool LargeReadonlyStruct_EqualityNotEqual() => _largeReadonlyStruct1 == _largeReadonlyStruct3;
    [Benchmark] public bool LargeReadonlyStruct_EqualsEqual() => _largeReadonlyStruct1.Equals(_largeReadonlyStruct2);
    [Benchmark] public bool LargeReadonlyStruct_EqualsNotEqual() => _largeReadonlyStruct1.Equals(_largeReadonlyStruct3);

    // GetHashCode Tests
    [Benchmark] public int SmallStruct_GetHashCode() => _smallStruct1.GetHashCode();
    [Benchmark] public int SmallRecord_GetHashCode() => _smallRecord1.GetHashCode();
    [Benchmark] public int SmallReadonlyRecordStruct_GetHashCode() => _smallReadonlyRecordStruct1.GetHashCode();
    [Benchmark] public int SmallReadonlyStruct_GetHashCode() => _smallReadonlyStruct1.GetHashCode();
    
    [Benchmark] public int LargeStruct_GetHashCode() => _largeStruct1.GetHashCode();
    [Benchmark] public int LargeRecord_GetHashCode() => _largeRecord1.GetHashCode();
    [Benchmark] public int LargeReadonlyRecordStruct_GetHashCode() => _largeReadonlyRecordStruct1.GetHashCode();
    [Benchmark] public int LargeReadonlyStruct_GetHashCode() => _largeReadonlyStruct1.GetHashCode();

    // HashSet Membership Tests
    [Benchmark] public bool SmallStruct_SetContainsTrue() => _smallStructSet.Contains(_smallStruct1);
    [Benchmark] public bool SmallStruct_SetContainsFalse() => _smallStructSet.Contains(_smallStruct2);
    [Benchmark] public bool SmallRecord_SetContainsTrue() => _smallRecordSet.Contains(_smallRecord1);
    [Benchmark] public bool SmallRecord_SetContainsFalse() => _smallRecordSet.Contains(_smallRecord2);
    [Benchmark] public bool SmallReadonlyRecordStruct_SetContainsTrue() => _smallReadonlyRecordStructSet.Contains(_smallReadonlyRecordStruct1);
    [Benchmark] public bool SmallReadonlyRecordStruct_SetContainsFalse() => _smallReadonlyRecordStructSet.Contains(_smallReadonlyRecordStruct2);
    [Benchmark] public bool SmallReadonlyStruct_SetContainsTrue() => _smallReadonlyStructSet.Contains(_smallReadonlyStruct1);
    [Benchmark] public bool SmallReadonlyStruct_SetContainsFalse() => _smallReadonlyStructSet.Contains(_smallReadonlyStruct2);

    [Benchmark] public bool LargeStruct_SetContainsTrue() => _largeStructSet.Contains(_largeStruct1);
    [Benchmark] public bool LargeStruct_SetContainsFalse() => _largeStructSet.Contains(_largeStruct2);
    [Benchmark] public bool LargeRecord_SetContainsTrue() => _largeRecordSet.Contains(_largeRecord1);
    [Benchmark] public bool LargeRecord_SetContainsFalse() => _largeRecordSet.Contains(_largeRecord2);
    [Benchmark] public bool LargeReadonlyRecordStruct_SetContainsTrue() => _largeReadonlyRecordStructSet.Contains(_largeReadonlyRecordStruct1);
    [Benchmark] public bool LargeReadonlyRecordStruct_SetContainsFalse() => _largeReadonlyRecordStructSet.Contains(_largeReadonlyRecordStruct2);
    [Benchmark] public bool LargeReadonlyStruct_SetContainsTrue() => _largeReadonlyStructSet.Contains(_largeReadonlyStruct1);
    [Benchmark] public bool LargeReadonlyStruct_SetContainsFalse() => _largeReadonlyStructSet.Contains(_largeReadonlyStruct2);

    // Unoptimized Struct Tests - Small Types (no IEquatable, uses reflection-based equality)
    [Benchmark] public bool SmallStructUnoptimized_EqualsEqual() => _smallStructUnoptimized1.Equals(_smallStructUnoptimized2);
    [Benchmark] public bool SmallStructUnoptimized_EqualsNotEqual() => _smallStructUnoptimized1.Equals(_smallStructUnoptimized3);
    [Benchmark] public int SmallStructUnoptimized_GetHashCode() => _smallStructUnoptimized1.GetHashCode();
    [Benchmark] public bool SmallStructUnoptimized_SetContainsTrue() => _smallStructUnoptimizedSet.Contains(_smallStructUnoptimized1);
    [Benchmark] public bool SmallStructUnoptimized_SetContainsFalse() => _smallStructUnoptimizedSet.Contains(_smallStructUnoptimized2);

    [Benchmark] public bool SmallReadonlyStructUnoptimized_EqualsEqual() => _smallReadonlyStructUnoptimized1.Equals(_smallReadonlyStructUnoptimized2);
    [Benchmark] public bool SmallReadonlyStructUnoptimized_EqualsNotEqual() => _smallReadonlyStructUnoptimized1.Equals(_smallReadonlyStructUnoptimized3);
    [Benchmark] public int SmallReadonlyStructUnoptimized_GetHashCode() => _smallReadonlyStructUnoptimized1.GetHashCode();
    [Benchmark] public bool SmallReadonlyStructUnoptimized_SetContainsTrue() => _smallReadonlyStructUnoptimizedSet.Contains(_smallReadonlyStructUnoptimized1);
    [Benchmark] public bool SmallReadonlyStructUnoptimized_SetContainsFalse() => _smallReadonlyStructUnoptimizedSet.Contains(_smallReadonlyStructUnoptimized2);

    // Unoptimized Struct Tests - Large Types
    [Benchmark] public bool LargeStructUnoptimized_EqualsEqual() => _largeStructUnoptimized1.Equals(_largeStructUnoptimized2);
    [Benchmark] public bool LargeStructUnoptimized_EqualsNotEqual() => _largeStructUnoptimized1.Equals(_largeStructUnoptimized3);
    [Benchmark] public int LargeStructUnoptimized_GetHashCode() => _largeStructUnoptimized1.GetHashCode();
    [Benchmark] public bool LargeStructUnoptimized_SetContainsTrue() => _largeStructUnoptimizedSet.Contains(_largeStructUnoptimized1);
    [Benchmark] public bool LargeStructUnoptimized_SetContainsFalse() => _largeStructUnoptimizedSet.Contains(_largeStructUnoptimized2);

    [Benchmark] public bool LargeReadonlyStructUnoptimized_EqualsEqual() => _largeReadonlyStructUnoptimized1.Equals(_largeReadonlyStructUnoptimized2);
    [Benchmark] public bool LargeReadonlyStructUnoptimized_EqualsNotEqual() => _largeReadonlyStructUnoptimized1.Equals(_largeReadonlyStructUnoptimized3);
    [Benchmark] public int LargeReadonlyStructUnoptimized_GetHashCode() => _largeReadonlyStructUnoptimized1.GetHashCode();
    [Benchmark] public bool LargeReadonlyStructUnoptimized_SetContainsTrue() => _largeReadonlyStructUnoptimizedSet.Contains(_largeReadonlyStructUnoptimized1);
    [Benchmark] public bool LargeReadonlyStructUnoptimized_SetContainsFalse() => _largeReadonlyStructUnoptimizedSet.Contains(_largeReadonlyStructUnoptimized2);
}