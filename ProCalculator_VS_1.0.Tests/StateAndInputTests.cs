using ProCalculator;

namespace ProCalculator_VS_1._0.Tests;

public class MemoryManagerTests
{
    [Fact]
    public void Store_And_Recall()
    {
        var memory = new MemoryManager();
        memory.Store(42);
        Assert.Equal(42, memory.Recall());
    }

    [Fact]
    public void Add_And_Subtract_ChangeStoredValue()
    {
        var memory = new MemoryManager();
        memory.Store(10);
        memory.Add(5);
        memory.Subtract(3);
        Assert.Equal(12, memory.Recall());
    }

    [Fact]
    public void Clear_ResetsToZero()
    {
        var memory = new MemoryManager();
        memory.Store(9);
        memory.Clear();
        Assert.Equal(0, memory.Recall());
    }
}

public class HistoryManagerTests
{
    [Fact]
    public void Add_KeepsEntriesInOrder()
    {
        var history = new HistoryManager();
        history.Add("1 + 1 = 2");
        history.Add("2 * 3 = 6");

        Assert.Equal(2, history.Count);
        Assert.Equal("1 + 1 = 2", history.Entries[0]);
        Assert.Equal("2 * 3 = 6", history.Entries[1]);
    }

    [Fact]
    public void Clear_RemovesAllEntries()
    {
        var history = new HistoryManager();
        history.Add("1 + 1 = 2");
        history.Clear();

        Assert.Equal(0, history.Count);
    }
}

public class InputHandlerTests
{
    [Theory]
    [InlineData("1", 1)]
    [InlineData("13", 13)]
    [InlineData("0", 0)]
    [InlineData("+", 1)]
    [InlineData("-", 2)]
    [InlineData("SQRT", 5)]
    [InlineData("m+", 19)]
    [InlineData("q", 0)]
    [InlineData("abc", -1)]
    [InlineData("", -1)]
    public void ParseMenuChoice_AcceptsNumbersAndShortcuts(string text, int expected) =>
        Assert.Equal(expected, InputHandler.ParseMenuChoice(text));

    [Theory]
    [InlineData("12.5", 12.5)]
    [InlineData("-3", -3)]
    [InlineData("1e3", 1000)]
    public void TryParseNumber_ParsesValidNumbers(string text, double expected)
    {
        Assert.True(InputHandler.TryParseNumber(text, 0, 0, out double value));
        Assert.Equal(expected, value, 10);
    }

    [Fact]
    public void TryParseNumber_Ans_ReturnsLastAnswer()
    {
        Assert.True(InputHandler.TryParseNumber("ans", 7.5, 0, out double value));
        Assert.Equal(7.5, value);
    }

    [Fact]
    public void TryParseNumber_Mr_ReturnsMemory()
    {
        Assert.True(InputHandler.TryParseNumber("MR", 0, 3.25, out double value));
        Assert.Equal(3.25, value);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("")]
    [InlineData("NaN")]
    [InlineData("Infinity")]
    public void TryParseNumber_RejectsInvalidInput(string text) =>
        Assert.False(InputHandler.TryParseNumber(text, 0, 0, out _));
}

public class NumberFormatterTests
{
    [Fact]
    public void Format_HidesFloatingPointNoise() =>
        Assert.Equal("0.3", NumberFormatter.Format(0.1 + 0.2));

    [Fact]
    public void Format_WholeNumberHasNoDecimals() =>
        Assert.Equal("5", NumberFormatter.Format(5));
}

public class ValidatorTests
{
    [Theory]
    [InlineData(0, true)]
    [InlineData(5, true)]
    [InlineData(-1, false)]
    [InlineData(2.5, false)]
    public void IsNonNegativeInteger_Works(double x, bool expected) =>
        Assert.Equal(expected, Validator.IsNonNegativeInteger(x));

    [Fact]
    public void IsFinite_RejectsNaNAndInfinity()
    {
        Assert.False(Validator.IsFinite(double.NaN));
        Assert.False(Validator.IsFinite(double.PositiveInfinity));
        Assert.True(Validator.IsFinite(1.5));
    }
}
