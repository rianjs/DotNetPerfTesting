// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

public class Program
{
    const string haystack = "this is a short string that won't be on the large object heap";
    private static readonly string[] needles = haystack
        .Split(' ', StringSplitOptions.TrimEntries)
        .Select(s => $"\\b{s}\\b")
        .ToArray();

    public static async Task Main(string[] args)
    {
        var limit = 10;
        for (var i = 0; i < limit; i++)
        {
            RunTest(RegexOptions.Compiled);
        }

        limit = 1000;
        var uncompiledResults = new List<(long, long)>(limit);
        for (var i = 0; i < limit; i++)
        {
            uncompiledResults.Add(RunTest(null));
        }

        var compiledResults = new List<(long, long)>(limit);
        for (var i = 0; i < limit; i++)
        {
            compiledResults.Add(RunTest(RegexOptions.Compiled));
        }

        GetStats(uncompiledResults, "Uncompiled results");
        GetStats(compiledResults, "Compiled results");
    }

    private static (long start, long end) RunTest(RegexOptions? opts)
    {
        var d = new Dictionary<string, Regex>(needles.Length, StringComparer.OrdinalIgnoreCase);
        var startMemory = GC.GetTotalMemory(forceFullCollection: true);

        foreach (var needle in needles)
        {
            var r = opts is null
                ? new Regex(needle)
                : new Regex(needle, opts.Value);
            d[needle] = r;
        }

        d.TrimExcess();

        var endMemory = GC.GetTotalMemory(forceFullCollection: true);

        // Call this here to prevent the GC from cleaning up an unused object
        var _ = d.Count;
        return (startMemory, endMemory);
    }

    private static void GetStats(IReadOnlyCollection<(long, long)> ranges, string label)
    {
        var sum = 0L;
        var count = 0;

        var biggest = long.MinValue;
        var smallest = long.MaxValue;
        foreach (var (start, end) in ranges)
        {
            var diff = end - start;
            if (diff <= 0)
            {
                continue;
            }

            if (start < smallest)
            {
                smallest = start;
            }

            if (end > biggest)
            {
                biggest = end;
            }

            count++;
            sum += diff;
        }

        Console.WriteLine("------------------");
        Console.WriteLine(label);
        Console.WriteLine($"Biggest: {biggest:N0}");
        Console.WriteLine($"Smallest: {smallest:N0}");
        Console.WriteLine($"Mean: {sum / count:N0}");
        Console.WriteLine("------------------");
    }
}