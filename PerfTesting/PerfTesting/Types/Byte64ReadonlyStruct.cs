namespace PerfTesting.Types;

public readonly struct Byte64ReadonlyStruct : IEquatable<Byte64ReadonlyStruct>
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }
    public int E { get; }
    public int F { get; }
    public int G { get; }
    public int H { get; }
    public int I { get; }
    public int J { get; }
    public int K { get; }
    public int L { get; }
    public int M { get; }
    public int N { get; }
    public int O { get; }
    public int P { get; }

    public Byte64ReadonlyStruct(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
        I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p;
    }

    public override bool Equals(object? obj) => obj is Byte64ReadonlyStruct other && Equals(other);
    public bool Equals(Byte64ReadonlyStruct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H && I == other.I && J == other.J && K == other.K && L == other.L && M == other.M && N == other.N && O == other.O && P == other.P;
    public override int GetHashCode() => HashCode.Combine(HashCode.Combine(A, B, C, D, E, F, G, H), HashCode.Combine(I, J, K, L, M, N, O, P));
    public static bool operator ==(Byte64ReadonlyStruct left, Byte64ReadonlyStruct right) => left.Equals(right);
    public static bool operator !=(Byte64ReadonlyStruct left, Byte64ReadonlyStruct right) => !left.Equals(right);
}