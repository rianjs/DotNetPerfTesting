namespace PerfTesting.Types;

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
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
        I = i; J = j; K = k; L = l; M = m; N = n; O = o; P = p;
    }
}