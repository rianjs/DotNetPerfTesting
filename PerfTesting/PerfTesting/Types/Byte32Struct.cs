namespace PerfTesting.Types;

public struct Byte32Struct : IEquatable<Byte32Struct>
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    public int D { get; set; }
    public int E { get; set; }
    public int F { get; set; }
    public int G { get; set; }
    public int H { get; set; }

    public Byte32Struct(int a, int b, int c, int d, int e, int f, int g, int h)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
    }

    public override bool Equals(object? obj) => obj is Byte32Struct other && Equals(other);
    public bool Equals(Byte32Struct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H;
    public override int GetHashCode() => HashCode.Combine(A, B, C, D, E, F, G, H);
    public static bool operator ==(Byte32Struct left, Byte32Struct right) => left.Equals(right);
    public static bool operator !=(Byte32Struct left, Byte32Struct right) => !left.Equals(right);
}