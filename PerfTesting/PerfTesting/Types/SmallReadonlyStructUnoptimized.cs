namespace PerfTesting.Types;

public readonly struct SmallReadonlyStructUnoptimized
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }

    public SmallReadonlyStructUnoptimized(int a, int b, int c, int d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }
}