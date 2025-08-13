namespace PerfTesting.Types;

public readonly struct LargeReadonlyStructUnoptimized
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }
    public int E { get; }
    public int F { get; }
    public int G { get; }
    public int H { get; }

    public LargeReadonlyStructUnoptimized(int a, int b, int c, int d, int e, int f, int g, int h)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
    }
}