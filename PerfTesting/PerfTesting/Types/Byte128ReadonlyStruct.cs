namespace PerfTesting.Types;

public readonly struct Byte128ReadonlyStruct : IEquatable<Byte128ReadonlyStruct>
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
    public int Q { get; }
    public int R { get; }
    public int S { get; }
    public int T { get; }
    public int U { get; }
    public int V { get; }
    public int W { get; }
    public int X { get; }
    public int Y { get; }
    public int Z { get; }
    public int AA { get; }
    public int BB { get; }
    public int CC { get; }
    public int DD { get; }
    public int EE { get; }
    public int FF { get; }

    public Byte128ReadonlyStruct(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p, int q, int r, int s, int t, int u, int v, int w, int x, int y, int z, int aa, int bb, int cc, int dd, int ee, int ff)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
        I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p;
        Q = q; R = r; S = s; T = t; U = u; V = v; W = w; X = x;
        Y = y; Z = z; AA = aa; BB = bb; CC = cc; DD = dd; EE = ee; FF = ff;
    }

    public override bool Equals(object? obj) => obj is Byte128ReadonlyStruct other && Equals(other);
    public bool Equals(Byte128ReadonlyStruct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H && I == other.I && J == other.J && K == other.K && L == other.L && M == other.M && N == other.N && O == other.O && P == other.P && Q == other.Q && R == other.R && S == other.S && T == other.T && U == other.U && V == other.V && W == other.W && X == other.X && Y == other.Y && Z == other.Z && AA == other.AA && BB == other.BB && CC == other.CC && DD == other.DD && EE == other.EE && FF == other.FF;
    public override int GetHashCode() => HashCode.Combine(HashCode.Combine(A, B, C, D, E, F, G, H), HashCode.Combine(I, J, K, L, M, N, O, P), HashCode.Combine(Q, R, S, T, U, V, W, X), HashCode.Combine(Y, Z, AA, BB, CC, DD, EE, FF));
    public static bool operator ==(Byte128ReadonlyStruct left, Byte128ReadonlyStruct right) => left.Equals(right);
    public static bool operator !=(Byte128ReadonlyStruct left, Byte128ReadonlyStruct right) => !left.Equals(right);
}