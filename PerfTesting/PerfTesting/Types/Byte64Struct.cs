namespace PerfTesting.Types;

public struct Byte64Struct : IEquatable<Byte64Struct>
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    public int D { get; set; }
    public int E { get; set; }
    public int F { get; set; }
    public int G { get; set; }
    public int H { get; set; }
    public int I { get; set; }
    public int J { get; set; }
    public int K { get; set; }
    public int L { get; set; }
    public int M { get; set; }
    public int N { get; set; }
    public int O { get; set; }
    public int P { get; set; }

    public Byte64Struct(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
        I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p;
    }

    public override bool Equals(object? obj) => obj is Byte64Struct other && Equals(other);
    public bool Equals(Byte64Struct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H && I == other.I && J == other.J && K == other.K && L == other.L && M == other.M && N == other.N && O == other.O && P == other.P;
    public override int GetHashCode() => HashCode.Combine(HashCode.Combine(A, B, C, D, E, F, G, H), HashCode.Combine(I, J, K, L, M, N, O, P));
    public static bool operator ==(Byte64Struct left, Byte64Struct right) => left.Equals(right);
    public static bool operator !=(Byte64Struct left, Byte64Struct right) => !left.Equals(right);
}