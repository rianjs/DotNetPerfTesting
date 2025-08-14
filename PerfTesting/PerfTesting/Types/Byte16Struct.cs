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