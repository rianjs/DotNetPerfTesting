namespace PerfTesting.Types;

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