namespace PerfTesting.Types;

public struct SmallStructUnoptimized
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    public int D { get; set; }

    public SmallStructUnoptimized(int a, int b, int c, int d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }
}