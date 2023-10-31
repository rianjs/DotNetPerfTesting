namespace PerfTesting.Boxing;

using BenchmarkDotNet.Attributes;

/// <summary>
/// A sanitized string that represents a Tenant.
/// The shape is validated, and the stored value is sanitized.
/// </summary>
public class BoxValue
{
    public string Value { get; }

    public BoxValue(string value)
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

    public BoxValue Append(string v)
    {
        if (string.IsNullOrWhiteSpace(v))
        {
            throw new ArgumentNullException(nameof(v));
        }

        var appended = string.Concat(new[] { Value, " - ", v.Trim() });
        return new BoxValue(appended);
    }
}

[MemoryDiagnoser, ShortRunJob]
public class ClassBoxTests
{
    private const int _limit = 333;

    [Benchmark]
    public void Instantiate()
    {
        var container = new List<BoxValue>(_limit);
        for (var i = 0; i < 50; i++)
        {
            container.Add(new BoxValue($"Struct: {i}"));
        }
    }

    [Benchmark]
    public void ToString()
    {
        var container = new List<string>(_limit);
        for (var i = 0; i < 50; i++)
        {
            var v = new BoxValue($"Struct: {i}");
            container.Add(v.ToString());
        }
    }

    [Benchmark]
    public void ReadValue()
    {
        var container = new List<string>(_limit);
        for (var i = 0; i < 50; i++)
        {
            var v = new BoxValue($"Struct: {i}");
            container.Add(v.Value);
        }
    }

    [Benchmark]
    public void Append()
    {
        var container = new List<BoxValue>(_limit);
        for (var i = 0; i < 50; i++)
        {
            var v = new BoxValue($"Struct: {i}");
            var z = v.Append(Guid.NewGuid().ToString());
            container.Add(z);
        }
    }
}