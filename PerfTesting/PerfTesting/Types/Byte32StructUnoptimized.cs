namespace PerfTesting.Types;

public struct Byte32StructUnoptimized
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    public int D { get; set; }
    public int E { get; set; }
    public int F { get; set; }
    public int G { get; set; }
    public int H { get; set; }

    public Byte32StructUnoptimized(int a, int b, int c, int d, int e, int f, int g, int h)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
    }
}