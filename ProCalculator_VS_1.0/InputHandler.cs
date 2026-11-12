using System.Globalization;

namespace ProCalculator;

/// <summary>Thrown when the input stream ends (Ctrl+Z / Ctrl+D or redirected input).</summary>
public class InputClosedException : Exception
{
    public InputClosedException() : base("The input stream was closed.")
    {
    }
}

public class InputHandler
{
    // Keyboard shortcuts for the menu. Typing the number works too.
    private static readonly Dictionary<string, int> Shortcuts = new(StringComparer.OrdinalIgnoreCase)
    {
        ["+"] = 1, ["add"] = 1,
        ["-"] = 2, ["sub"] = 2, ["subtract"] = 2,
        ["*"] = 3, ["x"] = 3, ["mul"] = 3, ["multiply"] = 3,
        ["/"] = 4, ["div"] = 4, ["divide"] = 4,
        ["sqrt"] = 5,
        ["^"] = 6, ["pow"] = 6, ["power"] = 6,
        ["sin"] = 7,
        ["cos"] = 8,
        ["tan"] = 9,
        ["log"] = 10,
        ["ms"] = 11, ["store"] = 11,
        ["mr"] = 12, ["recall"] = 12,
        ["h"] = 13, ["history"] = 13,
        ["ln"] = 14,
        ["sq"] = 15, ["square"] = 15,
        ["cube"] = 16,
        ["!"] = 17, ["fact"] = 17,
        ["%"] = 18, ["pct"] = 18, ["percent"] = 18,
        ["m+"] = 19,
        ["m-"] = 20,
        ["mc"] = 21,
        ["hc"] = 22,
        ["t"] = 23, ["theme"] = 23,
        ["q"] = 0, ["quit"] = 0, ["exit"] = 0
    };

    /// <summary>Last result, so the user can type "ans" instead of a number.</summary>
    public double LastAnswer { get; set; }

    /// <summary>Stored memory value, so the user can type "mr" instead of a number.</summary>
    public double MemoryValue { get; set; }

    public string ReadLine(string prompt)
    {
        Console.Write(prompt);
        string? line = Console.ReadLine();
        if (line == null)
            throw new InputClosedException();
        return line.Trim();
    }

    /// <summary>Reads a menu choice. Returns -1 when the text is not a valid choice.</summary>
    public int GetMenuChoice()
    {
        string text = ReadLine("Select option (number or shortcut): ");
        return ParseMenuChoice(text);
    }

    public static int ParseMenuChoice(string text)
    {
        if (Shortcuts.TryGetValue(text, out int shortcut))
            return shortcut;

        if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int number))
            return number;

        return -1;
    }

    /// <summary>Keeps asking until the user enters a valid number.</summary>
    public double GetDouble(string label = "Enter number")
    {
        while (true)
        {
            string text = ReadLine(label + ": ");
            if (TryParseNumber(text, LastAnswer, MemoryValue, out double value))
                return value;

            Console.WriteLine("Invalid number. Enter a value like 12.5, or 'ans' / 'mr' to reuse the last result / memory.");
        }
    }

    public static bool TryParseNumber(string text, double lastAnswer, double memoryValue, out double value)
    {
        if (text.Equals("ans", StringComparison.OrdinalIgnoreCase))
        {
            value = lastAnswer;
            return true;
        }

        if (text.Equals("mr", StringComparison.OrdinalIgnoreCase))
        {
            value = memoryValue;
            return true;
        }

        bool parsed =
            double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value) ||
            double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value);

        return parsed && double.IsFinite(value);
    }
}
