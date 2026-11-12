namespace ProCalculator;

public class BasicOperations
{
    public double Add(double a, double b) => a + b;

    public double Subtract(double a, double b) => a - b;

    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (!Validator.IsNonZero(b))
            throw new DivideByZeroException("Division by zero is not allowed.");
        return a / b;
    }

    /// <summary>Returns <paramref name="percent"/> percent of <paramref name="value"/>.</summary>
    public double Percent(double value, double percent) => value * percent / 100.0;
}
