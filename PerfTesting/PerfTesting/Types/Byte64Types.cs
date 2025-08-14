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
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h; I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p;
    }

    public override bool Equals(object? obj) => obj is Byte64Struct other && Equals(other);
    public bool Equals(Byte64Struct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H && I == other.I && J == other.J && K == other.K && L == other.L && M == other.M && N == other.N && O == other.O && P == other.P;
    public override int GetHashCode() => HashCode.Combine(HashCode.Combine(A, B, C, D, E, F, G, H), HashCode.Combine(I, J, K, L, M, N, O, P));
    public static bool operator ==(Byte64Struct left, Byte64Struct right) => left.Equals(right);
    public static bool operator !=(Byte64Struct left, Byte64Struct right) => !left.Equals(right);
}

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
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h; I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p;
    }

    public override bool Equals(object? obj) => obj is Byte64ReadonlyStruct other && Equals(other);
    public bool Equals(Byte64ReadonlyStruct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H && I == other.I && J == other.J && K == other.K && L == other.L && M == other.M && N == other.N && O == other.O && P == other.P;
    public override int GetHashCode() => HashCode.Combine(HashCode.Combine(A, B, C, D, E, F, G, H), HashCode.Combine(I, J, K, L, M, N, O, P));
    public static bool operator ==(Byte64ReadonlyStruct left, Byte64ReadonlyStruct right) => left.Equals(right);
    public static bool operator !=(Byte64ReadonlyStruct left, Byte64ReadonlyStruct right) => !left.Equals(right);
}

public record Byte64Record(int A, int B, int C, int D, int E, int F, int G, int H, int I, int J, int K, int L, int M, int N, int O, int P);

public readonly record struct Byte64ReadonlyRecordStruct(int A, int B, int C, int D, int E, int F, int G, int H, int I, int J, int K, int L, int M, int N, int O, int P);

public struct Byte64StructUnoptimized
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

    public Byte64StructUnoptimized(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h; I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p;
    }
}

public readonly struct Byte64ReadonlyStructUnoptimized
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

    public Byte64ReadonlyStructUnoptimized(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h; I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p;
    }
}