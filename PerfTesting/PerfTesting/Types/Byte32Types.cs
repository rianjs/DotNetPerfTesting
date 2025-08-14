namespace PerfTesting.Types;

public struct Byte32Struct : IEquatable<Byte32Struct>
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    public int D { get; set; }
    public int E { get; set; }
    public int F { get; set; }
    public int G { get; set; }
    public int H { get; set; }

    public Byte32Struct(int a, int b, int c, int d, int e, int f, int g, int h)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
    }

    public override bool Equals(object? obj) => obj is Byte32Struct other && Equals(other);
    public bool Equals(Byte32Struct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H;
    public override int GetHashCode() => HashCode.Combine(A, B, C, D, E, F, G, H);
    public static bool operator ==(Byte32Struct left, Byte32Struct right) => left.Equals(right);
    public static bool operator !=(Byte32Struct left, Byte32Struct right) => !left.Equals(right);
}

public readonly struct Byte32ReadonlyStruct : IEquatable<Byte32ReadonlyStruct>
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }
    public int E { get; }
    public int F { get; }
    public int G { get; }
    public int H { get; }

    public Byte32ReadonlyStruct(int a, int b, int c, int d, int e, int f, int g, int h)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
    }

    public override bool Equals(object? obj) => obj is Byte32ReadonlyStruct other && Equals(other);
    public bool Equals(Byte32ReadonlyStruct other) => A == other.A && B == other.B && C == other.C && D == other.D && E == other.E && F == other.F && G == other.G && H == other.H;
    public override int GetHashCode() => HashCode.Combine(A, B, C, D, E, F, G, H);
    public static bool operator ==(Byte32ReadonlyStruct left, Byte32ReadonlyStruct right) => left.Equals(right);
    public static bool operator !=(Byte32ReadonlyStruct left, Byte32ReadonlyStruct right) => !left.Equals(right);
}

public record Byte32Record(int A, int B, int C, int D, int E, int F, int G, int H);

public readonly record struct Byte32ReadonlyRecordStruct(int A, int B, int C, int D, int E, int F, int G, int H);

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

public readonly struct Byte32ReadonlyStructUnoptimized
{
    public int A { get; }
    public int B { get; }
    public int C { get; }
    public int D { get; }
    public int E { get; }
    public int F { get; }
    public int G { get; }
    public int H { get; }

    public Byte32ReadonlyStructUnoptimized(int a, int b, int c, int d, int e, int f, int g, int h)
    {
        A = a; B = b; C = c; D = d; E = e; F = f; G = g; H = h;
    }
}