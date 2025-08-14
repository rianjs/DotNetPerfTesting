namespace PerfTesting.Types;

public struct Byte16Struct : IEquatable<Byte16Struct>
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }

    public Byte16Struct(int a, int b, int c, int d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public override bool Equals(object? obj) => obj is Byte16Struct other && Equals(other);
    public bool Equals(Byte16Struct other) => A == other.A && B == other.B && C == other.C && D == other.D;
    public override int GetHashCode() => HashCode.Combine(A, B, C, D);
    public static bool operator ==(Byte16Struct left, Byte16Struct right) => left.Equals(right);
    public static bool operator !=(Byte16Struct left, Byte16Struct right) => !left.Equals(right);
}

public readonly struct Byte16ReadonlyStruct : IEquatable<Byte16ReadonlyStruct>
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }

    public Byte16ReadonlyStruct(int a, int b, int c, int d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public override bool Equals(object? obj) => obj is Byte16ReadonlyStruct other && Equals(other);
    public bool Equals(Byte16ReadonlyStruct other) => A == other.A && B == other.B && C == other.C && D == other.D;
    public override int GetHashCode() => HashCode.Combine(A, B, C, D);
    public static bool operator ==(Byte16ReadonlyStruct left, Byte16ReadonlyStruct right) => left.Equals(right);
    public static bool operator !=(Byte16ReadonlyStruct left, Byte16ReadonlyStruct right) => !left.Equals(right);
}

public record Byte16Record(int A, int B, int C, int D);

public readonly record struct Byte16ReadonlyRecordStruct(int A, int B, int C, int D);

public struct Byte16StructUnoptimized
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    public int D { get; set; }

    public Byte16StructUnoptimized(int a, int b, int c, int d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }
}

public readonly struct Byte16ReadonlyStructUnoptimized
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }

    public Byte16ReadonlyStructUnoptimized(int a, int b, int c, int d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }
}