using ProCalculator;

namespace ProCalculator_VS_1._0.Tests;

public class BasicOperationsTests
{
    private readonly BasicOperations basic = new();

    [Fact]
    public void Add_ReturnsSum() => Assert.Equal(7, basic.Add(3, 4));

    [Fact]
    public void Subtract_ReturnsDifference() => Assert.Equal(-1, basic.Subtract(3, 4));

    [Fact]
    public void Multiply_ReturnsProduct() => Assert.Equal(12, basic.Multiply(3, 4));

    [Fact]
    public void Divide_ReturnsQuotient() => Assert.Equal(2.5, basic.Divide(5, 2));

    [Fact]
    public void Divide_ByZero_Throws() =>
        Assert.Throws<DivideByZeroException>(() => basic.Divide(5, 0));

    [Fact]
    public void Percent_ReturnsPercentageOfValue() => Assert.Equal(30, basic.Percent(200, 15), 10);
}

public class ScientificOperationsTests
{
    private readonly ScientificOperations sci = new();

    [Fact]
    public void Sqrt_ReturnsRoot() => Assert.Equal(4, sci.Sqrt(16), 10);

    [Fact]
    public void Sqrt_OfNegative_Throws() =>
        Assert.Throws<ArgumentException>(() => sci.Sqrt(-1));

    [Fact]
    public void Power_ReturnsResult() => Assert.Equal(1024, sci.Power(2, 10), 10);

    [Fact]
    public void Power_ZeroToNegative_Throws() =>
        Assert.Throws<DivideByZeroException>(() => sci.Power(0, -1));

    [Fact]
    public void Power_NegativeBaseFractionalExponent_Throws() =>
        Assert.Throws<ArgumentException>(() => sci.Power(-8, 0.5));

    [Fact]
    public void Square_And_Cube()
    {
        Assert.Equal(25, sci.Square(5), 10);
        Assert.Equal(27, sci.Cube(3), 10);
    }

    [Fact]
    public void Sin_UsesDegrees()
    {
        Assert.Equal(0.5, sci.Sin(30), 10);
        Assert.Equal(0.0, sci.Sin(180), 10);
    }

    [Fact]
    public void Cos_UsesDegrees()
    {
        Assert.Equal(0.5, sci.Cos(60), 10);
        Assert.Equal(0.0, sci.Cos(90), 10);
    }

    [Fact]
    public void Tan_UsesDegrees() => Assert.Equal(1.0, sci.Tan(45), 10);

    [Fact]
    public void Tan_At90Degrees_Throws() =>
        Assert.Throws<ArgumentException>(() => sci.Tan(90));

    [Fact]
    public void Log_IsBase10() => Assert.Equal(3, sci.Log(1000), 10);

    [Fact]
    public void Ln_IsNaturalLog() => Assert.Equal(1, sci.Ln(Math.E), 10);

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Log_And_Ln_OfNonPositive_Throw(double x)
    {
        Assert.Throws<ArgumentException>(() => sci.Log(x));
        Assert.Throws<ArgumentException>(() => sci.Ln(x));
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(5, 120)]
    [InlineData(10, 3628800)]
    public void Factorial_ReturnsExpectedValue(double input, double expected) =>
        Assert.Equal(expected, sci.Factorial(input), 10);

    [Theory]
    [InlineData(-1)]
    [InlineData(2.5)]
    public void Factorial_OfInvalidInput_Throws(double x) =>
        Assert.Throws<ArgumentException>(() => sci.Factorial(x));

    [Fact]
    public void Factorial_TooLarge_Throws() =>
        Assert.Throws<OverflowException>(() => sci.Factorial(171));

    [Fact]
    public void Factorial_Of170_IsStillFinite() =>
        Assert.True(double.IsFinite(sci.Factorial(170)));
}
