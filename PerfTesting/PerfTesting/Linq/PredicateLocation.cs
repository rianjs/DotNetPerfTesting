using BenchmarkDotNet.Attributes;

namespace PerfTesting.Linq;

[MemoryDiagnoser, ShortRunJob]
public class PredicateLocation
{
    public static int[] _largeNumbers = Enumerable.Range(0, 1000).ToArray();
    public static int[] _smallNumbers = Enumerable.Range(0, 50).ToArray();

    [Benchmark]
    public int FirstOrDefaultLarge()
        => _largeNumbers.FirstOrDefault(n => n == 667);

    [Benchmark]
    public int FirstLarge()
        => _largeNumbers.First(n => n == 667);

    [Benchmark]
    public int SingleLarge()
        => _largeNumbers.Single(n => n == 667);

    [Benchmark]
    public int SingleOrDefaultLarge()
        => _largeNumbers.SingleOrDefault(n => n == 667);

    [Benchmark]
    public int WhereFirstLarge()
        => _largeNumbers.Where(n => n == 667).First();

    [Benchmark]
    public int WhereFirstDefaultLarge()
        => _largeNumbers.Where(n => n == 667).FirstOrDefault();

    [Benchmark]
    public int WhereSingleLarge()
        => _largeNumbers.Where(n => n == 667).Single();

    [Benchmark]
    public int WhereSingleDefaultLarge()
        => _largeNumbers.Where(n => n == 667).SingleOrDefault();

    [Benchmark]
    public int FirstOrDefaultSmall()
        => _smallNumbers.FirstOrDefault(n => n == 25);

    [Benchmark]
    public int FirstSmall()
        => _smallNumbers.First(n => n == 25);

    [Benchmark]
    public int SingleSmall()
        => _smallNumbers.Single(n => n == 25);

    [Benchmark]
    public int SingleOrDefaultSmall()
        => _smallNumbers.SingleOrDefault(n => n == 25);

    [Benchmark]
    public int WhereFirstSmall()
        => _smallNumbers.Where(n => n == 25).First();

    [Benchmark]
    public int WhereFirstDefaultSmall()
        => _smallNumbers.Where(n => n == 25).FirstOrDefault();

    [Benchmark]
    public int WhereSingleSmall()
        => _smallNumbers.Where(n => n == 25).Single();

    [Benchmark]
    public int WhereSingleDefaultSmall()
        => _smallNumbers.Where(n => n == 25).SingleOrDefault();
}