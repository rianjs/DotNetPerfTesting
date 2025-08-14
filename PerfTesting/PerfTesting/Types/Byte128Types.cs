namespace PerfTesting.Types;

public struct Byte128Struct : IEquatable<Byte128Struct>
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
    public int Q { get; set; }
    public int R { get; set; }
    public int S { get; set; }
    public int T { get; set; }
    public int U { get; set; }
    public int V { get; set; }
    public int W { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int AA { get; set; }
    public int BB { get; set; }
    public int CC { get; set; }
    public int DD { get; set; }
    public int EE { get; set; }
    public int FF { get; set; }

    public Byte128Struct(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p, int q, int r, int s, int t, int u, int v, int w, int x, int y, int z, int aa, int bb, int cc, int dd, int ee, int ff)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h; I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p; Q = q; R = r; S = s; T = t; U = u; V = v; W = w; X = x; Y = y; Z = z; AA = aa; BB = bb; CC = cc; DD = dd; EE = ee; FF = ff;
    }

    public override bool Equals(object? obj) => obj is Byte128Struct other && Equals(other);
    public bool Equals(Byte128Struct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H && I == other.I && J == other.J && K == other.K && L == other.L && M == other.M && N == other.N && O == other.O && P == other.P && Q == other.Q && R == other.R && S == other.S && T == other.T && U == other.U && V == other.V && W == other.W && X == other.X && Y == other.Y && Z == other.Z && AA == other.AA && BB == other.BB && CC == other.CC && DD == other.DD && EE == other.EE && FF == other.FF;
    public override int GetHashCode() => HashCode.Combine(HashCode.Combine(A, B, C, D, E, F, G, H), HashCode.Combine(I, J, K, L, M, N, O, P), HashCode.Combine(Q, R, S, T, U, V, W, X), HashCode.Combine(Y, Z, AA, BB, CC, DD, EE, FF));
    public static bool operator ==(Byte128Struct left, Byte128Struct right) => left.Equals(right);
    public static bool operator !=(Byte128Struct left, Byte128Struct right) => !left.Equals(right);
}

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
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h; I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p; Q = q; R = r; S = s; T = t; U = u; V = v; W = w; X = x; Y = y; Z = z; AA = aa; BB = bb; CC = cc; DD = dd; EE = ee; FF = ff;
    }

    public override bool Equals(object? obj) => obj is Byte128ReadonlyStruct other && Equals(other);
    public bool Equals(Byte128ReadonlyStruct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H && I == other.I && J == other.J && K == other.K && L == other.L && M == other.M && N == other.N && O == other.O && P == other.P && Q == other.Q && R == other.R && S == other.S && T == other.T && U == other.U && V == other.V && W == other.W && X == other.X && Y == other.Y && Z == other.Z && AA == other.AA && BB == other.BB && CC == other.CC && DD == other.DD && EE == other.EE && FF == other.FF;
    public override int GetHashCode() => HashCode.Combine(HashCode.Combine(A, B, C, D, E, F, G, H), HashCode.Combine(I, J, K, L, M, N, O, P), HashCode.Combine(Q, R, S, T, U, V, W, X), HashCode.Combine(Y, Z, AA, BB, CC, DD, EE, FF));
    public static bool operator ==(Byte128ReadonlyStruct left, Byte128ReadonlyStruct right) => left.Equals(right);
    public static bool operator !=(Byte128ReadonlyStruct left, Byte128ReadonlyStruct right) => !left.Equals(right);
}

public record Byte128Record(int A, int B, int C, int D, int E, int F, int G, int H, int I, int J, int K, int L, int M, int N, int O, int P, int Q, int R, int S, int T, int U, int V, int W, int X, int Y, int Z, int AA, int BB, int CC, int DD, int EE, int FF);

public readonly record struct Byte128ReadonlyRecordStruct(int A, int B, int C, int D, int E, int F, int G, int H, int I, int J, int K, int L, int M, int N, int O, int P, int Q, int R, int S, int T, int U, int V, int W, int X, int Y, int Z, int AA, int BB, int CC, int DD, int EE, int FF);

public struct Byte128StructUnoptimized
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
    public int Q { get; set; }
    public int R { get; set; }
    public int S { get; set; }
    public int T { get; set; }
    public int U { get; set; }
    public int V { get; set; }
    public int W { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int AA { get; set; }
    public int BB { get; set; }
    public int CC { get; set; }
    public int DD { get; set; }
    public int EE { get; set; }
    public int FF { get; set; }

    public Byte128StructUnoptimized(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p, int q, int r, int s, int t, int u, int v, int w, int x, int y, int z, int aa, int bb, int cc, int dd, int ee, int ff)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h; I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p; Q = q; R = r; S = s; T = t; U = u; V = v; W = w; X = x; Y = y; Z = z; AA = aa; BB = bb; CC = cc; DD = dd; EE = ee; FF = ff;
    }
}

public readonly struct Byte128ReadonlyStructUnoptimized
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

    public Byte128ReadonlyStructUnoptimized(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p, int q, int r, int s, int t, int u, int v, int w, int x, int y, int z, int aa, int bb, int cc, int dd, int ee, int ff)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h; I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p; Q = q; R = r; S = s; T = t; U = u; V = v; W = w; X = x; Y = y; Z = z; AA = aa; BB = bb; CC = cc; DD = dd; EE = ee; FF = ff;
    }
}