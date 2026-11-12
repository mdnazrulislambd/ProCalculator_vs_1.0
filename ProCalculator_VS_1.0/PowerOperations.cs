namespace ProCalculator;

public class PowerOperations
{
    public double Power(double x, double y)
    {
        if (x == 0 && y < 0)
            throw new DivideByZeroException("Zero cannot be raised to a negative power.");

        double result = Math.Pow(x, y);
        if (double.IsNaN(result))
            throw new ArgumentException("The result is not a real number (negative base with a fractional exponent).");
        return result;
    }

    public double Square(double x) => x * x;

    public double Cube(double x) => x * x * x;
}
