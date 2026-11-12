namespace ProCalculator;

public class OutputHandler
{
    private const int ColumnWidth = 27;

    public void ShowMenu()
    {
        string[] basicAndOther =
        {
            "BASIC",
            " 1. Add (+)",
            " 2. Subtract (-)",
            " 3. Multiply (*)",
            " 4. Divide (/)",
            "18. Percent (%)",
            "",
            "OTHER",
            "13. History (h)",
            "22. Clear hist. (hc)",
            "23. Theme (t)",
            " 0. Exit (q)"
        };

        string[] scientific =
        {
            "SCIENTIFIC",
            " 5. Sqrt (sqrt)",
            " 6. Power (^)",
            "15. Square (sq)",
            "16. Cube (cube)",
            " 7. Sin (sin)",
            " 8. Cos (cos)",
            " 9. Tan (tan)",
            "10. Log10 (log)",
            "14. Ln (ln)",
            "17. Factorial (!)"
        };

        string[] memory =
        {
            "MEMORY",
            "11. Store (ms)",
            "12. Recall (mr)",
            "19. M+ (m+)",
            "20. M- (m-)",
            "21. Clear (mc)"
        };

        Console.WriteLine("=== ProCalculator VS 1.0 - Scientific Calculator ===");
        Console.WriteLine();

        int rows = Math.Max(basicAndOther.Length, Math.Max(scientific.Length, memory.Length));
        for (int i = 0; i < rows; i++)
        {
            string a = i < basicAndOther.Length ? basicAndOther[i] : "";
            string b = i < scientific.Length ? scientific[i] : "";
            string c = i < memory.Length ? memory[i] : "";
            Console.WriteLine(a.PadRight(ColumnWidth) + b.PadRight(ColumnWidth) + c);
        }

        Console.WriteLine();
        Console.WriteLine("Tip: type a number or a shortcut. For numbers, 'ans' = last result, 'mr' = memory.");
        Console.WriteLine();
    }

    public void Print(string message)
    {
        Console.WriteLine(message);
    }

    public void ShowHistory(IReadOnlyList<string> entries)
    {
        Console.WriteLine("History:");
        if (entries.Count == 0)
        {
            Console.WriteLine("  (empty)");
            return;
        }

        for (int i = 0; i < entries.Count; i++)
            Console.WriteLine($"  {i + 1}. {entries[i]}");
    }

    public void Clear()
    {
        if (Console.IsOutputRedirected)
            return;

        try
        {
            Console.Clear();
            // Also erase the scrollback so old menus do not appear when scrolling up.
            Console.Write("\u001b[3J");
        }
        catch (IOException)
        {
            // No real console available; nothing to clear.
        }
    }
}