using BenchmarkDotNet.Attributes;

namespace PerfTesting.Boxing;

/// <summary>
/// A sanitized string that represents a Tenant.
/// The shape is validated, and the stored value is sanitized.
/// </summary>
public readonly struct StructValue
{
    public string Value { get; }

    public StructValue(string value)
    {
        if (!IsValid(value))
        {
            throw new ArgumentException(@"Tenant shape is not valid.", nameof(value));
        }

        Value = value.Trim();
    }

    public override string ToString() => Value;

    public static bool IsValid(string value)
        => !string.IsNullOrWhiteSpace(value) && value.Length <= 128;

    public StructValue Append(string v)
    {
        if (string.IsNullOrWhiteSpace(v))
        {
            throw new ArgumentNullException(nameof(v));
        }

        var appended = string.Concat(new[] { Value, " - ", v.Trim() });
        return new StructValue(appended);
    }
}

[MemoryDiagnoser, ShortRunJob]
public class StructBoxTests
{
    private const int _limit = 333;
    [Benchmark]
    public void Instantiate()
    {
        var container = new List<StructValue>(_limit);
        for (var i = 0; i < 50; i++)
        {
            container.Add(new StructValue($"Struct: {i}"));
        }
    }

    [Benchmark]
    public void ToString()
    {
        var container = new List<string>(_limit);
        for (var i = 0; i < 50; i++)
        {
            var v = new StructValue($"Struct: {i}");
            container.Add(v.ToString());
        }
    }

    [Benchmark]
    public void ReadValue()
    {
        var container = new List<string>(_limit);
        for (var i = 0; i < 50; i++)
        {
            var v = new StructValue($"Struct: {i}");
            container.Add(v.Value);
        }
    }

    [Benchmark]
    public void Append()
    {
        var container = new List<StructValue>(_limit);
        for (var i = 0; i < 50; i++)
        {
            var v = new StructValue($"Struct: {i}");
            var z = v.Append(Guid.NewGuid().ToString());
            container.Add(z);
        }
    }
}