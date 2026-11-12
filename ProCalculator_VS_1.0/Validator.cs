namespace ProCalculator;

/// <summary>Small helpers for checking numbers before they are used in a calculation.</summary>
public static class Validator
{
    public static bool IsPositive(double x) => x > 0;

    public static bool IsNonZero(double x) => x != 0;

    public static bool IsFinite(double x) => double.IsFinite(x);

    public static bool IsNonNegativeInteger(double x) =>
        x >= 0 && !double.IsInfinity(x) && x == Math.Floor(x);
}
