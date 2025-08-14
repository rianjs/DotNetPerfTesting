namespace PerfTesting.Types;

public readonly struct Byte32ReadonlyStruct : IEquatable<Byte32ReadonlyStruct>
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }
    public int E { get; }
    public int F { get; }
    public int G { get; }
    public int H { get; }

    public Byte32ReadonlyStruct(int a, int b, int c, int d, int e, int f, int g, int h)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
    }

    public override bool Equals(object? obj) => obj is Byte32ReadonlyStruct other && Equals(other);
    public bool Equals(Byte32ReadonlyStruct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H;
    public override int GetHashCode() => HashCode.Combine(A, B, C, D, E, F, G, H);
    public static bool operator ==(Byte32ReadonlyStruct left, Byte32ReadonlyStruct right) => left.Equals(right);
    public static bool operator !=(Byte32ReadonlyStruct left, Byte32ReadonlyStruct right) => !left.Equals(right);
}