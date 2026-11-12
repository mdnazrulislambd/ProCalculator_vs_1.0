namespace ProCalculator;

/// <summary>Trigonometric functions. Angles are in degrees.</summary>
public class Trigonometry
{
    private const int Digits = 10;

    public double Sin(double degrees) => Clean(Math.Sin(ToRadians(degrees)));

    public double Cos(double degrees) => Clean(Math.Cos(ToRadians(degrees)));

    public double Tan(double degrees)
    {
        double radians = ToRadians(degrees);
        if (Math.Abs(Math.Cos(radians)) < 1e-12)
            throw new ArgumentException("Tangent is undefined for this angle.");
        return Clean(Math.Tan(radians));
    }

    private static double ToRadians(double degrees) => degrees * Math.PI / 180.0;

    // Rounds away tiny errors (sin(180) = 1.2E-16) and turns -0 into 0.
    private static double Clean(double value) => Math.Round(value, Digits) + 0.0;
}
