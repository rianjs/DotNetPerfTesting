namespace PerfTesting.Types;

public struct SmallStruct : IEquatable<SmallStruct>
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    public int D { get; set; }

    public SmallStruct(int a, int b, int c, int d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public override bool Equals(object? obj) => obj is SmallStruct other && Equals(other);
    public bool Equals(SmallStruct other) => A == other.A && B == other.B && C == other.C && D == other.D;
    public override int GetHashCode() => HashCode.Combine(A, B, C, D);
    public static bool operator ==(SmallStruct left, SmallStruct right) => left.Equals(right);
    public static bool operator !=(SmallStruct left, SmallStruct right) => !left.Equals(right);
}