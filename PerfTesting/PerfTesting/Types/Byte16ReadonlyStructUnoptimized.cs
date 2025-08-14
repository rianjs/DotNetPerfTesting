namespace PerfTesting.Types;

public readonly struct Byte16ReadonlyStructUnoptimized
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }

    public Byte16ReadonlyStructUnoptimized(int a, int b, int c, int d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }
}