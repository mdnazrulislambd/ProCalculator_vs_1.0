namespace ProCalculator;

public class Logarithmic
{
    /// <summary>Base-10 logarithm.</summary>
    public double Log(double x)
    {
        if (!Validator.IsPositive(x))
            throw new ArgumentException("Log is defined only for positive numbers.");
        return Math.Log10(x);
    }

    /// <summary>Natural logarithm (base e).</summary>
    public double Ln(double x)
    {
        if (!Validator.IsPositive(x))
            throw new ArgumentException("Ln is defined only for positive numbers.");
        return Math.Log(x);
    }
}
