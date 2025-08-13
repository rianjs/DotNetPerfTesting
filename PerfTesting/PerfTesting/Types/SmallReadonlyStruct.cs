namespace PerfTesting.Types;

public readonly struct SmallReadonlyStruct : IEquatable<SmallReadonlyStruct>
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }

    public SmallReadonlyStruct(int a, int b, int c, int d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public override bool Equals(object? obj) => obj is SmallReadonlyStruct other && Equals(other);
    public bool Equals(SmallReadonlyStruct other) => A == other.A && B == other.B && C == other.C && D == other.D;
    public override int GetHashCode() => HashCode.Combine(A, B, C, D);
    public static bool operator ==(SmallReadonlyStruct left, SmallReadonlyStruct right) => left.Equals(right);
    public static bool operator !=(SmallReadonlyStruct left, SmallReadonlyStruct right) => !left.Equals(right);
}