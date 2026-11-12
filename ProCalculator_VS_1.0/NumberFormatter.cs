using System.Globalization;

namespace ProCalculator;

/// <summary>Formats numbers the same way everywhere (screen and history).</summary>
public static class NumberFormatter
{
    // 15 significant digits hides floating point noise such as 0.1 + 0.2 = 0.30000000000000004.
    public static string Format(double value) =>
        value.ToString("G15", CultureInfo.InvariantCulture);
}
