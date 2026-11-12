namespace ProCalculator;

/// <summary>Single entry point for all scientific functions.</summary>
public class ScientificOperations
{
    private readonly Trigonometry trig = new();
    private readonly Logarithmic log = new();
    private readonly PowerOperations powerOps = new();

    public double Sqrt(double x)
    {
        if (x < 0)
            throw new ArgumentException("Square root of a negative number is not a real number.");
        return Math.Sqrt(x);
    }

    public double Power(double x, double y) => powerOps.Power(x, y);

    public double Square(double x) => powerOps.Square(x);

    public double Cube(double x) => powerOps.Cube(x);

    public double Sin(double degrees) => trig.Sin(degrees);

    public double Cos(double degrees) => trig.Cos(degrees);

    public double Tan(double degrees) => trig.Tan(degrees);

    public double Log(double x) => log.Log(x);

    public double Ln(double x) => log.Ln(x);

    public double Factorial(double x)
    {
        if (!Validator.IsNonNegativeInteger(x))
            throw new ArgumentException("Factorial is defined only for non-negative whole numbers.");
        if (x > 170)
            throw new OverflowException("Factorial result is too large (the maximum input is 170).");

        double result = 1;
        for (int i = 2; i <= (int)x; i++)
            result *= i;
        return result;
    }
}
