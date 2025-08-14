using BenchmarkDotNet.Attributes;

namespace PerfTesting.Types;

[MemoryDiagnoser, ShortRunJob]
public class TypeEqualityTests
{
    // 16-byte types
    private static readonly Byte16Struct _b16Struct1 = new(1, 2, 3, 4);
    private static readonly Byte16Struct _b16Struct2 = new(1, 2, 3, 4);
    private static readonly Byte16Struct _b16Struct3 = new(5, 6, 7, 8);
    
    private static readonly Byte16Record _b16Record1 = new(1, 2, 3, 4);
    private static readonly Byte16Record _b16Record2 = new(1, 2, 3, 4);
    private static readonly Byte16Record _b16Record3 = new(5, 6, 7, 8);
    
    private static readonly Byte16ReadonlyRecordStruct _b16ReadonlyRecordStruct1 = new(1, 2, 3, 4);
    private static readonly Byte16ReadonlyRecordStruct _b16ReadonlyRecordStruct2 = new(1, 2, 3, 4);
    private static readonly Byte16ReadonlyRecordStruct _b16ReadonlyRecordStruct3 = new(5, 6, 7, 8);
    
    private static readonly Byte16ReadonlyStruct _b16ReadonlyStruct1 = new(1, 2, 3, 4);
    private static readonly Byte16ReadonlyStruct _b16ReadonlyStruct2 = new(1, 2, 3, 4);
    private static readonly Byte16ReadonlyStruct _b16ReadonlyStruct3 = new(5, 6, 7, 8);

    // 32-byte types
    private static readonly Byte32Struct _b32Struct1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32Struct _b32Struct2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32Struct _b32Struct3 = new(9, 10, 11, 12, 13, 14, 15, 16);
    
    private static readonly Byte32Record _b32Record1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32Record _b32Record2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32Record _b32Record3 = new(9, 10, 11, 12, 13, 14, 15, 16);
    
    private static readonly Byte32ReadonlyRecordStruct _b32ReadonlyRecordStruct1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32ReadonlyRecordStruct _b32ReadonlyRecordStruct2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32ReadonlyRecordStruct _b32ReadonlyRecordStruct3 = new(9, 10, 11, 12, 13, 14, 15, 16);
    
    private static readonly Byte32ReadonlyStruct _b32ReadonlyStruct1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32ReadonlyStruct _b32ReadonlyStruct2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32ReadonlyStruct _b32ReadonlyStruct3 = new(9, 10, 11, 12, 13, 14, 15, 16);

    // 64-byte types
    private static readonly Byte64Struct _b64Struct1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64Struct _b64Struct2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64Struct _b64Struct3 = new(17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    
    private static readonly Byte64Record _b64Record1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64Record _b64Record2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64Record _b64Record3 = new(17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    
    private static readonly Byte64ReadonlyRecordStruct _b64ReadonlyRecordStruct1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64ReadonlyRecordStruct _b64ReadonlyRecordStruct2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64ReadonlyRecordStruct _b64ReadonlyRecordStruct3 = new(17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    
    private static readonly Byte64ReadonlyStruct _b64ReadonlyStruct1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64ReadonlyStruct _b64ReadonlyStruct2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64ReadonlyStruct _b64ReadonlyStruct3 = new(17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);

    // 128-byte types
    private static readonly Byte128Struct _b128Struct1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128Struct _b128Struct2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128Struct _b128Struct3 = new(33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64);
    
    private static readonly Byte128Record _b128Record1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128Record _b128Record2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128Record _b128Record3 = new(33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64);
    
    private static readonly Byte128ReadonlyRecordStruct _b128ReadonlyRecordStruct1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128ReadonlyRecordStruct _b128ReadonlyRecordStruct2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128ReadonlyRecordStruct _b128ReadonlyRecordStruct3 = new(33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64);
    
    private static readonly Byte128ReadonlyStruct _b128ReadonlyStruct1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128ReadonlyStruct _b128ReadonlyStruct2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128ReadonlyStruct _b128ReadonlyStruct3 = new(33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64);

    // Unoptimized struct types (no IEquatable implementation)
    private static readonly Byte16StructUnoptimized _b16StructUnoptimized1 = new(1, 2, 3, 4);
    private static readonly Byte16StructUnoptimized _b16StructUnoptimized2 = new(1, 2, 3, 4);
    private static readonly Byte16StructUnoptimized _b16StructUnoptimized3 = new(5, 6, 7, 8);
    
    private static readonly Byte16ReadonlyStructUnoptimized _b16ReadonlyStructUnoptimized1 = new(1, 2, 3, 4);
    private static readonly Byte16ReadonlyStructUnoptimized _b16ReadonlyStructUnoptimized2 = new(1, 2, 3, 4);
    private static readonly Byte16ReadonlyStructUnoptimized _b16ReadonlyStructUnoptimized3 = new(5, 6, 7, 8);
    
    private static readonly Byte32StructUnoptimized _b32StructUnoptimized1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32StructUnoptimized _b32StructUnoptimized2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32StructUnoptimized _b32StructUnoptimized3 = new(9, 10, 11, 12, 13, 14, 15, 16);
    
    private static readonly Byte32ReadonlyStructUnoptimized _b32ReadonlyStructUnoptimized1 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32ReadonlyStructUnoptimized _b32ReadonlyStructUnoptimized2 = new(1, 2, 3, 4, 5, 6, 7, 8);
    private static readonly Byte32ReadonlyStructUnoptimized _b32ReadonlyStructUnoptimized3 = new(9, 10, 11, 12, 13, 14, 15, 16);
    
    private static readonly Byte64StructUnoptimized _b64StructUnoptimized1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64StructUnoptimized _b64StructUnoptimized2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64StructUnoptimized _b64StructUnoptimized3 = new(17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    
    private static readonly Byte64ReadonlyStructUnoptimized _b64ReadonlyStructUnoptimized1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64ReadonlyStructUnoptimized _b64ReadonlyStructUnoptimized2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
    private static readonly Byte64ReadonlyStructUnoptimized _b64ReadonlyStructUnoptimized3 = new(17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    
    private static readonly Byte128StructUnoptimized _b128StructUnoptimized1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128StructUnoptimized _b128StructUnoptimized2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128StructUnoptimized _b128StructUnoptimized3 = new(33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64);
    
    private static readonly Byte128ReadonlyStructUnoptimized _b128ReadonlyStructUnoptimized1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128ReadonlyStructUnoptimized _b128ReadonlyStructUnoptimized2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);
    private static readonly Byte128ReadonlyStructUnoptimized _b128ReadonlyStructUnoptimized3 = new(33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64);

    private static readonly HashSet<Byte16Struct> _b16StructSet = new() { _b16Struct1, _b16Struct3 };
    private static readonly HashSet<Byte16Record> _b16RecordSet = new() { _b16Record1, _b16Record3 };
    private static readonly HashSet<Byte16ReadonlyRecordStruct> _b16ReadonlyRecordStructSet = new() { _b16ReadonlyRecordStruct1, _b16ReadonlyRecordStruct3 };
    private static readonly HashSet<Byte16ReadonlyStruct> _b16ReadonlyStructSet = new() { _b16ReadonlyStruct1, _b16ReadonlyStruct3 };
    
    private static readonly HashSet<Byte32Struct> _b32StructSet = new() { _b32Struct1, _b32Struct3 };
    private static readonly HashSet<Byte32Record> _b32RecordSet = new() { _b32Record1, _b32Record3 };
    private static readonly HashSet<Byte32ReadonlyRecordStruct> _b32ReadonlyRecordStructSet = new() { _b32ReadonlyRecordStruct1, _b32ReadonlyRecordStruct3 };
    private static readonly HashSet<Byte32ReadonlyStruct> _b32ReadonlyStructSet = new() { _b32ReadonlyStruct1, _b32ReadonlyStruct3 };
    
    private static readonly HashSet<Byte64Struct> _b64StructSet = new() { _b64Struct1, _b64Struct3 };
    private static readonly HashSet<Byte64Record> _b64RecordSet = new() { _b64Record1, _b64Record3 };
    private static readonly HashSet<Byte64ReadonlyRecordStruct> _b64ReadonlyRecordStructSet = new() { _b64ReadonlyRecordStruct1, _b64ReadonlyRecordStruct3 };
    private static readonly HashSet<Byte64ReadonlyStruct> _b64ReadonlyStructSet = new() { _b64ReadonlyStruct1, _b64ReadonlyStruct3 };
    
    private static readonly HashSet<Byte128Struct> _b128StructSet = new() { _b128Struct1, _b128Struct3 };
    private static readonly HashSet<Byte128Record> _b128RecordSet = new() { _b128Record1, _b128Record3 };
    private static readonly HashSet<Byte128ReadonlyRecordStruct> _b128ReadonlyRecordStructSet = new() { _b128ReadonlyRecordStruct1, _b128ReadonlyRecordStruct3 };
    private static readonly HashSet<Byte128ReadonlyStruct> _b128ReadonlyStructSet = new() { _b128ReadonlyStruct1, _b128ReadonlyStruct3 };
    
    private static readonly HashSet<Byte16StructUnoptimized> _b16StructUnoptimizedSet = new() { _b16StructUnoptimized1, _b16StructUnoptimized3 };
    private static readonly HashSet<Byte16ReadonlyStructUnoptimized> _b16ReadonlyStructUnoptimizedSet = new() { _b16ReadonlyStructUnoptimized1, _b16ReadonlyStructUnoptimized3 };
    private static readonly HashSet<Byte32StructUnoptimized> _b32StructUnoptimizedSet = new() { _b32StructUnoptimized1, _b32StructUnoptimized3 };
    private static readonly HashSet<Byte32ReadonlyStructUnoptimized> _b32ReadonlyStructUnoptimizedSet = new() { _b32ReadonlyStructUnoptimized1, _b32ReadonlyStructUnoptimized3 };
    private static readonly HashSet<Byte64StructUnoptimized> _b64StructUnoptimizedSet = new() { _b64StructUnoptimized1, _b64StructUnoptimized3 };
    private static readonly HashSet<Byte64ReadonlyStructUnoptimized> _b64ReadonlyStructUnoptimizedSet = new() { _b64ReadonlyStructUnoptimized1, _b64ReadonlyStructUnoptimized3 };
    private static readonly HashSet<Byte128StructUnoptimized> _b128StructUnoptimizedSet = new() { _b128StructUnoptimized1, _b128StructUnoptimized3 };
    private static readonly HashSet<Byte128ReadonlyStructUnoptimized> _b128ReadonlyStructUnoptimizedSet = new() { _b128ReadonlyStructUnoptimized1, _b128ReadonlyStructUnoptimized3 };

    // Equality Tests - 16-byte Types
    [Benchmark]
    public bool Byte16Struct_EqualityEqual()
        => _b16Struct1 == _b16Struct2;
    
    [Benchmark]
    public bool Byte16Struct_EqualityNotEqual()
        => _b16Struct1 == _b16Struct3;
    
    [Benchmark]
    public bool Byte16Struct_EqualsEqual()
        => _b16Struct1.Equals(_b16Struct2);
    
    [Benchmark]
    public bool Byte16Struct_EqualsNotEqual()
        => _b16Struct1.Equals(_b16Struct3);

    [Benchmark]
    public bool Byte16Record_EqualityEqual()
        => _b16Record1 == _b16Record2;
    
    [Benchmark]
    public bool Byte16Record_EqualityNotEqual()
        => _b16Record1 == _b16Record3;
    
    [Benchmark]
    public bool Byte16Record_EqualsEqual()
        => _b16Record1.Equals(_b16Record2);
    
    [Benchmark]
    public bool Byte16Record_EqualsNotEqual()
        => _b16Record1.Equals(_b16Record3);

    [Benchmark]
    public bool Byte16ReadonlyRecordStruct_EqualityEqual()
        => _b16ReadonlyRecordStruct1 == _b16ReadonlyRecordStruct2;
    
    [Benchmark]
    public bool Byte16ReadonlyRecordStruct_EqualityNotEqual()
        => _b16ReadonlyRecordStruct1 == _b16ReadonlyRecordStruct3;
    
    [Benchmark]
    public bool Byte16ReadonlyRecordStruct_EqualsEqual()
        => _b16ReadonlyRecordStruct1.Equals(_b16ReadonlyRecordStruct2);
    
    [Benchmark]
    public bool Byte16ReadonlyRecordStruct_EqualsNotEqual()
        => _b16ReadonlyRecordStruct1.Equals(_b16ReadonlyRecordStruct3);

    [Benchmark]
    public bool Byte16ReadonlyStruct_EqualityEqual()
        => _b16ReadonlyStruct1 == _b16ReadonlyStruct2;
    
    [Benchmark]
    public bool Byte16ReadonlyStruct_EqualityNotEqual()
        => _b16ReadonlyStruct1 == _b16ReadonlyStruct3;
    
    [Benchmark]
    public bool Byte16ReadonlyStruct_EqualsEqual()
        => _b16ReadonlyStruct1.Equals(_b16ReadonlyStruct2);
    
    [Benchmark]
    public bool Byte16ReadonlyStruct_EqualsNotEqual()
        => _b16ReadonlyStruct1.Equals(_b16ReadonlyStruct3);

    // Equality Tests - 32-byte Types
    [Benchmark]
    public bool Byte32Struct_EqualityEqual()
        => _b32Struct1 == _b32Struct2;
    
    [Benchmark]
    public bool Byte32Struct_EqualityNotEqual()
        => _b32Struct1 == _b32Struct3;
    
    [Benchmark]
    public bool Byte32Struct_EqualsEqual()
        => _b32Struct1.Equals(_b32Struct2);
    
    [Benchmark]
    public bool Byte32Struct_EqualsNotEqual()
        => _b32Struct1.Equals(_b32Struct3);

    [Benchmark]
    public bool Byte32Record_EqualityEqual()
        => _b32Record1 == _b32Record2;
    
    [Benchmark]
    public bool Byte32Record_EqualityNotEqual()
        => _b32Record1 == _b32Record3;
    
    [Benchmark]
    public bool Byte32Record_EqualsEqual()
        => _b32Record1.Equals(_b32Record2);
    
    [Benchmark]
    public bool Byte32Record_EqualsNotEqual()
        => _b32Record1.Equals(_b32Record3);

    [Benchmark]
    public bool Byte32ReadonlyRecordStruct_EqualityEqual()
        => _b32ReadonlyRecordStruct1 == _b32ReadonlyRecordStruct2;
    
    [Benchmark]
    public bool Byte32ReadonlyRecordStruct_EqualityNotEqual()
        => _b32ReadonlyRecordStruct1 == _b32ReadonlyRecordStruct3;
    
    [Benchmark]
    public bool Byte32ReadonlyRecordStruct_EqualsEqual()
        => _b32ReadonlyRecordStruct1.Equals(_b32ReadonlyRecordStruct2);
    
    [Benchmark]
    public bool Byte32ReadonlyRecordStruct_EqualsNotEqual()
        => _b32ReadonlyRecordStruct1.Equals(_b32ReadonlyRecordStruct3);

    [Benchmark]
    public bool Byte32ReadonlyStruct_EqualityEqual()
        => _b32ReadonlyStruct1 == _b32ReadonlyStruct2;
    
    [Benchmark]
    public bool Byte32ReadonlyStruct_EqualityNotEqual()
        => _b32ReadonlyStruct1 == _b32ReadonlyStruct3;
    
    [Benchmark]
    public bool Byte32ReadonlyStruct_EqualsEqual()
        => _b32ReadonlyStruct1.Equals(_b32ReadonlyStruct2);
    
    [Benchmark]
    public bool Byte32ReadonlyStruct_EqualsNotEqual()
        => _b32ReadonlyStruct1.Equals(_b32ReadonlyStruct3);

    // Equality Tests - 64-byte Types
    [Benchmark]
    public bool Byte64Struct_EqualityEqual()
        => _b64Struct1 == _b64Struct2;
    
    [Benchmark]
    public bool Byte64Struct_EqualityNotEqual()
        => _b64Struct1 == _b64Struct3;
    
    [Benchmark]
    public bool Byte64Struct_EqualsEqual()
        => _b64Struct1.Equals(_b64Struct2);
    
    [Benchmark]
    public bool Byte64Struct_EqualsNotEqual()
        => _b64Struct1.Equals(_b64Struct3);

    [Benchmark]
    public bool Byte64Record_EqualityEqual()
        => _b64Record1 == _b64Record2;
    
    [Benchmark]
    public bool Byte64Record_EqualityNotEqual()
        => _b64Record1 == _b64Record3;
    
    [Benchmark]
    public bool Byte64Record_EqualsEqual()
        => _b64Record1.Equals(_b64Record2);
    
    [Benchmark]
    public bool Byte64Record_EqualsNotEqual()
        => _b64Record1.Equals(_b64Record3);

    [Benchmark]
    public bool Byte64ReadonlyRecordStruct_EqualityEqual()
        => _b64ReadonlyRecordStruct1 == _b64ReadonlyRecordStruct2;
    
    [Benchmark]
    public bool Byte64ReadonlyRecordStruct_EqualityNotEqual()
        => _b64ReadonlyRecordStruct1 == _b64ReadonlyRecordStruct3;
    
    [Benchmark]
    public bool Byte64ReadonlyRecordStruct_EqualsEqual()
        => _b64ReadonlyRecordStruct1.Equals(_b64ReadonlyRecordStruct2);
    
    [Benchmark]
    public bool Byte64ReadonlyRecordStruct_EqualsNotEqual()
        => _b64ReadonlyRecordStruct1.Equals(_b64ReadonlyRecordStruct3);

    [Benchmark]
    public bool Byte64ReadonlyStruct_EqualityEqual()
        => _b64ReadonlyStruct1 == _b64ReadonlyStruct2;
    
    [Benchmark]
    public bool Byte64ReadonlyStruct_EqualityNotEqual()
        => _b64ReadonlyStruct1 == _b64ReadonlyStruct3;
    
    [Benchmark]
    public bool Byte64ReadonlyStruct_EqualsEqual()
        => _b64ReadonlyStruct1.Equals(_b64ReadonlyStruct2);
    
    [Benchmark]
    public bool Byte64ReadonlyStruct_EqualsNotEqual()
        => _b64ReadonlyStruct1.Equals(_b64ReadonlyStruct3);

    // Equality Tests - 128-byte Types
    [Benchmark]
    public bool Byte128Struct_EqualityEqual()
        => _b128Struct1 == _b128Struct2;
    
    [Benchmark]
    public bool Byte128Struct_EqualityNotEqual()
        => _b128Struct1 == _b128Struct3;
    
    [Benchmark]
    public bool Byte128Struct_EqualsEqual()
        => _b128Struct1.Equals(_b128Struct2);
    
    [Benchmark]
    public bool Byte128Struct_EqualsNotEqual()
        => _b128Struct1.Equals(_b128Struct3);

    [Benchmark]
    public bool Byte128Record_EqualityEqual()
        => _b128Record1 == _b128Record2;
    
    [Benchmark]
    public bool Byte128Record_EqualityNotEqual()
        => _b128Record1 == _b128Record3;
    
    [Benchmark]
    public bool Byte128Record_EqualsEqual()
        => _b128Record1.Equals(_b128Record2);
    
    [Benchmark]
    public bool Byte128Record_EqualsNotEqual()
        => _b128Record1.Equals(_b128Record3);

    [Benchmark]
    public bool Byte128ReadonlyRecordStruct_EqualityEqual()
        => _b128ReadonlyRecordStruct1 == _b128ReadonlyRecordStruct2;
    
    [Benchmark]
    public bool Byte128ReadonlyRecordStruct_EqualityNotEqual()
        => _b128ReadonlyRecordStruct1 == _b128ReadonlyRecordStruct3;
    
    [Benchmark]
    public bool Byte128ReadonlyRecordStruct_EqualsEqual()
        => _b128ReadonlyRecordStruct1.Equals(_b128ReadonlyRecordStruct2);
    
    [Benchmark]
    public bool Byte128ReadonlyRecordStruct_EqualsNotEqual()
        => _b128ReadonlyRecordStruct1.Equals(_b128ReadonlyRecordStruct3);

    [Benchmark]
    public bool Byte128ReadonlyStruct_EqualityEqual()
        => _b128ReadonlyStruct1 == _b128ReadonlyStruct2;
    
    [Benchmark]
    public bool Byte128ReadonlyStruct_EqualityNotEqual()
        => _b128ReadonlyStruct1 == _b128ReadonlyStruct3;
    
    [Benchmark]
    public bool Byte128ReadonlyStruct_EqualsEqual()
        => _b128ReadonlyStruct1.Equals(_b128ReadonlyStruct2);
    
    [Benchmark]
    public bool Byte128ReadonlyStruct_EqualsNotEqual()
        => _b128ReadonlyStruct1.Equals(_b128ReadonlyStruct3);

    // GetHashCode Tests
    [Benchmark]
    public int Byte16Struct_GetHashCode()
        => _b16Struct1.GetHashCode();
    
    [Benchmark]
    public int Byte16Record_GetHashCode()
        => _b16Record1.GetHashCode();
    
    [Benchmark]
    public int Byte16ReadonlyRecordStruct_GetHashCode()
        => _b16ReadonlyRecordStruct1.GetHashCode();
    
    [Benchmark]
    public int Byte16ReadonlyStruct_GetHashCode()
        => _b16ReadonlyStruct1.GetHashCode();
    
    [Benchmark]
    public int Byte32Struct_GetHashCode()
        => _b32Struct1.GetHashCode();
    
    [Benchmark]
    public int Byte32Record_GetHashCode()
        => _b32Record1.GetHashCode();
    
    [Benchmark]
    public int Byte32ReadonlyRecordStruct_GetHashCode()
        => _b32ReadonlyRecordStruct1.GetHashCode();
    
    [Benchmark]
    public int Byte32ReadonlyStruct_GetHashCode()
        => _b32ReadonlyStruct1.GetHashCode();
    
    [Benchmark]
    public int Byte64Struct_GetHashCode()
        => _b64Struct1.GetHashCode();
    
    [Benchmark]
    public int Byte64Record_GetHashCode()
        => _b64Record1.GetHashCode();
    
    [Benchmark]
    public int Byte64ReadonlyRecordStruct_GetHashCode()
        => _b64ReadonlyRecordStruct1.GetHashCode();
    
    [Benchmark]
    public int Byte64ReadonlyStruct_GetHashCode()
        => _b64ReadonlyStruct1.GetHashCode();
    
    [Benchmark]
    public int Byte128Struct_GetHashCode()
        => _b128Struct1.GetHashCode();
    
    [Benchmark]
    public int Byte128Record_GetHashCode()
        => _b128Record1.GetHashCode();
    
    [Benchmark]
    public int Byte128ReadonlyRecordStruct_GetHashCode()
        => _b128ReadonlyRecordStruct1.GetHashCode();
    
    [Benchmark]
    public int Byte128ReadonlyStruct_GetHashCode()
        => _b128ReadonlyStruct1.GetHashCode();

    // HashSet Membership Tests
    [Benchmark]
    public bool Byte16Struct_SetContainsTrue()
        => _b16StructSet.Contains(_b16Struct1);
    
    [Benchmark]
    public bool Byte16Struct_SetContainsFalse()
        => _b16StructSet.Contains(_b16Struct2);
    
    [Benchmark]
    public bool Byte16Record_SetContainsTrue()
        => _b16RecordSet.Contains(_b16Record1);
    
    [Benchmark]
    public bool Byte16Record_SetContainsFalse()
        => _b16RecordSet.Contains(_b16Record2);
    
    [Benchmark]
    public bool Byte16ReadonlyRecordStruct_SetContainsTrue()
        => _b16ReadonlyRecordStructSet.Contains(_b16ReadonlyRecordStruct1);
    
    [Benchmark]
    public bool Byte16ReadonlyRecordStruct_SetContainsFalse()
        => _b16ReadonlyRecordStructSet.Contains(_b16ReadonlyRecordStruct2);
    
    [Benchmark]
    public bool Byte16ReadonlyStruct_SetContainsTrue()
        => _b16ReadonlyStructSet.Contains(_b16ReadonlyStruct1);
    
    [Benchmark]
    public bool Byte16ReadonlyStruct_SetContainsFalse()
        => _b16ReadonlyStructSet.Contains(_b16ReadonlyStruct2);

    [Benchmark]
    public bool Byte32Struct_SetContainsTrue()
        => _b32StructSet.Contains(_b32Struct1);
    
    [Benchmark]
    public bool Byte32Struct_SetContainsFalse()
        => _b32StructSet.Contains(_b32Struct2);
    
    [Benchmark]
    public bool Byte32Record_SetContainsTrue()
        => _b32RecordSet.Contains(_b32Record1);
    
    [Benchmark]
    public bool Byte32Record_SetContainsFalse()
        => _b32RecordSet.Contains(_b32Record2);
    
    [Benchmark]
    public bool Byte32ReadonlyRecordStruct_SetContainsTrue()
        => _b32ReadonlyRecordStructSet.Contains(_b32ReadonlyRecordStruct1);
    
    [Benchmark]
    public bool Byte32ReadonlyRecordStruct_SetContainsFalse()
        => _b32ReadonlyRecordStructSet.Contains(_b32ReadonlyRecordStruct2);
    
    [Benchmark]
    public bool Byte32ReadonlyStruct_SetContainsTrue()
        => _b32ReadonlyStructSet.Contains(_b32ReadonlyStruct1);
    
    [Benchmark]
    public bool Byte32ReadonlyStruct_SetContainsFalse()
        => _b32ReadonlyStructSet.Contains(_b32ReadonlyStruct2);

    [Benchmark]
    public bool Byte64Struct_SetContainsTrue()
        => _b64StructSet.Contains(_b64Struct1);
    
    [Benchmark]
    public bool Byte64Struct_SetContainsFalse()
        => _b64StructSet.Contains(_b64Struct2);
    
    [Benchmark]
    public bool Byte64Record_SetContainsTrue()
        => _b64RecordSet.Contains(_b64Record1);
    
    [Benchmark]
    public bool Byte64Record_SetContainsFalse()
        => _b64RecordSet.Contains(_b64Record2);
    
    [Benchmark]
    public bool Byte64ReadonlyRecordStruct_SetContainsTrue()
        => _b64ReadonlyRecordStructSet.Contains(_b64ReadonlyRecordStruct1);
    
    [Benchmark]
    public bool Byte64ReadonlyRecordStruct_SetContainsFalse()
        => _b64ReadonlyRecordStructSet.Contains(_b64ReadonlyRecordStruct2);
    
    [Benchmark]
    public bool Byte64ReadonlyStruct_SetContainsTrue()
        => _b64ReadonlyStructSet.Contains(_b64ReadonlyStruct1);
    
    [Benchmark]
    public bool Byte64ReadonlyStruct_SetContainsFalse()
        => _b64ReadonlyStructSet.Contains(_b64ReadonlyStruct2);

    [Benchmark]
    public bool Byte128Struct_SetContainsTrue()
        => _b128StructSet.Contains(_b128Struct1);
    
    [Benchmark]
    public bool Byte128Struct_SetContainsFalse()
        => _b128StructSet.Contains(_b128Struct2);
    
    [Benchmark]
    public bool Byte128Record_SetContainsTrue()
        => _b128RecordSet.Contains(_b128Record1);
    
    [Benchmark]
    public bool Byte128Record_SetContainsFalse()
        => _b128RecordSet.Contains(_b128Record2);
    
    [Benchmark]
    public bool Byte128ReadonlyRecordStruct_SetContainsTrue()
        => _b128ReadonlyRecordStructSet.Contains(_b128ReadonlyRecordStruct1);
    
    [Benchmark]
    public bool Byte128ReadonlyRecordStruct_SetContainsFalse()
        => _b128ReadonlyRecordStructSet.Contains(_b128ReadonlyRecordStruct2);
    
    [Benchmark]
    public bool Byte128ReadonlyStruct_SetContainsTrue()
        => _b128ReadonlyStructSet.Contains(_b128ReadonlyStruct1);
    
    [Benchmark]
    public bool Byte128ReadonlyStruct_SetContainsFalse()
        => _b128ReadonlyStructSet.Contains(_b128ReadonlyStruct2);

    // Unoptimized Struct Tests - 16-byte Types (no IEquatable, uses reflection-based equality)
    [Benchmark]
    public bool Byte16StructUnoptimized_EqualsEqual()
        => _b16StructUnoptimized1.Equals(_b16StructUnoptimized2);
    
    [Benchmark]
    public bool Byte16StructUnoptimized_EqualsNotEqual()
        => _b16StructUnoptimized1.Equals(_b16StructUnoptimized3);
    
    [Benchmark]
    public int Byte16StructUnoptimized_GetHashCode()
        => _b16StructUnoptimized1.GetHashCode();
    
    [Benchmark]
    public bool Byte16StructUnoptimized_SetContainsTrue()
        => _b16StructUnoptimizedSet.Contains(_b16StructUnoptimized1);
    
    [Benchmark]
    public bool Byte16StructUnoptimized_SetContainsFalse()
        => _b16StructUnoptimizedSet.Contains(_b16StructUnoptimized2);

    [Benchmark]
    public bool Byte16ReadonlyStructUnoptimized_EqualsEqual()
        => _b16ReadonlyStructUnoptimized1.Equals(_b16ReadonlyStructUnoptimized2);
    
    [Benchmark]
    public bool Byte16ReadonlyStructUnoptimized_EqualsNotEqual()
        => _b16ReadonlyStructUnoptimized1.Equals(_b16ReadonlyStructUnoptimized3);
    
    [Benchmark]
    public int Byte16ReadonlyStructUnoptimized_GetHashCode()
        => _b16ReadonlyStructUnoptimized1.GetHashCode();
    
    [Benchmark]
    public bool Byte16ReadonlyStructUnoptimized_SetContainsTrue()
        => _b16ReadonlyStructUnoptimizedSet.Contains(_b16ReadonlyStructUnoptimized1);
    
    [Benchmark]
    public bool Byte16ReadonlyStructUnoptimized_SetContainsFalse()
        => _b16ReadonlyStructUnoptimizedSet.Contains(_b16ReadonlyStructUnoptimized2);

    // Unoptimized Struct Tests - 32-byte Types
    [Benchmark]
    public bool Byte32StructUnoptimized_EqualsEqual()
        => _b32StructUnoptimized1.Equals(_b32StructUnoptimized2);
    
    [Benchmark]
    public bool Byte32StructUnoptimized_EqualsNotEqual()
        => _b32StructUnoptimized1.Equals(_b32StructUnoptimized3);
    
    [Benchmark]
    public int Byte32StructUnoptimized_GetHashCode()
        => _b32StructUnoptimized1.GetHashCode();
    
    [Benchmark]
    public bool Byte32StructUnoptimized_SetContainsTrue()
        => _b32StructUnoptimizedSet.Contains(_b32StructUnoptimized1);
    
    [Benchmark]
    public bool Byte32StructUnoptimized_SetContainsFalse()
        => _b32StructUnoptimizedSet.Contains(_b32StructUnoptimized2);

    [Benchmark]
    public bool Byte32ReadonlyStructUnoptimized_EqualsEqual()
        => _b32ReadonlyStructUnoptimized1.Equals(_b32ReadonlyStructUnoptimized2);
    
    [Benchmark]
    public bool Byte32ReadonlyStructUnoptimized_EqualsNotEqual()
        => _b32ReadonlyStructUnoptimized1.Equals(_b32ReadonlyStructUnoptimized3);
    
    [Benchmark]
    public int Byte32ReadonlyStructUnoptimized_GetHashCode()
        => _b32ReadonlyStructUnoptimized1.GetHashCode();
    
    [Benchmark]
    public bool Byte32ReadonlyStructUnoptimized_SetContainsTrue()
        => _b32ReadonlyStructUnoptimizedSet.Contains(_b32ReadonlyStructUnoptimized1);
    
    [Benchmark]
    public bool Byte32ReadonlyStructUnoptimized_SetContainsFalse()
        => _b32ReadonlyStructUnoptimizedSet.Contains(_b32ReadonlyStructUnoptimized2);

    // Unoptimized Struct Tests - 64-byte Types
    [Benchmark]
    public bool Byte64StructUnoptimized_EqualsEqual()
        => _b64StructUnoptimized1.Equals(_b64StructUnoptimized2);
    
    [Benchmark]
    public bool Byte64StructUnoptimized_EqualsNotEqual()
        => _b64StructUnoptimized1.Equals(_b64StructUnoptimized3);
    
    [Benchmark]
    public int Byte64StructUnoptimized_GetHashCode()
        => _b64StructUnoptimized1.GetHashCode();
    
    [Benchmark]
    public bool Byte64StructUnoptimized_SetContainsTrue()
        => _b64StructUnoptimizedSet.Contains(_b64StructUnoptimized1);
    
    [Benchmark]
    public bool Byte64StructUnoptimized_SetContainsFalse()
        => _b64StructUnoptimizedSet.Contains(_b64StructUnoptimized2);

    [Benchmark]
    public bool Byte64ReadonlyStructUnoptimized_EqualsEqual()
        => _b64ReadonlyStructUnoptimized1.Equals(_b64ReadonlyStructUnoptimized2);
    
    [Benchmark]
    public bool Byte64ReadonlyStructUnoptimized_EqualsNotEqual()
        => _b64ReadonlyStructUnoptimized1.Equals(_b64ReadonlyStructUnoptimized3);
    
    [Benchmark]
    public int Byte64ReadonlyStructUnoptimized_GetHashCode()
        => _b64ReadonlyStructUnoptimized1.GetHashCode();
    
    [Benchmark]
    public bool Byte64ReadonlyStructUnoptimized_SetContainsTrue()
        => _b64ReadonlyStructUnoptimizedSet.Contains(_b64ReadonlyStructUnoptimized1);
    
    [Benchmark]
    public bool Byte64ReadonlyStructUnoptimized_SetContainsFalse()
        => _b64ReadonlyStructUnoptimizedSet.Contains(_b64ReadonlyStructUnoptimized2);

    // Unoptimized Struct Tests - 128-byte Types
    [Benchmark]
    public bool Byte128StructUnoptimized_EqualsEqual()
        => _b128StructUnoptimized1.Equals(_b128StructUnoptimized2);
    
    [Benchmark]
    public bool Byte128StructUnoptimized_EqualsNotEqual()
        => _b128StructUnoptimized1.Equals(_b128StructUnoptimized3);
    
    [Benchmark]
    public int Byte128StructUnoptimized_GetHashCode()
        => _b128StructUnoptimized1.GetHashCode();
    
    [Benchmark]
    public bool Byte128StructUnoptimized_SetContainsTrue()
        => _b128StructUnoptimizedSet.Contains(_b128StructUnoptimized1);
    
    [Benchmark]
    public bool Byte128StructUnoptimized_SetContainsFalse()
        => _b128StructUnoptimizedSet.Contains(_b128StructUnoptimized2);

    [Benchmark]
    public bool Byte128ReadonlyStructUnoptimized_EqualsEqual()
        => _b128ReadonlyStructUnoptimized1.Equals(_b128ReadonlyStructUnoptimized2);
    
    [Benchmark]
    public bool Byte128ReadonlyStructUnoptimized_EqualsNotEqual()
        => _b128ReadonlyStructUnoptimized1.Equals(_b128ReadonlyStructUnoptimized3);
    
    [Benchmark]
    public int Byte128ReadonlyStructUnoptimized_GetHashCode()
        => _b128ReadonlyStructUnoptimized1.GetHashCode();
    
    [Benchmark]
    public bool Byte128ReadonlyStructUnoptimized_SetContainsTrue()
        => _b128ReadonlyStructUnoptimizedSet.Contains(_b128ReadonlyStructUnoptimized1);
    
    [Benchmark]
    public bool Byte128ReadonlyStructUnoptimized_SetContainsFalse()
        => _b128ReadonlyStructUnoptimizedSet.Contains(_b128ReadonlyStructUnoptimized2);
}