namespace ProCalculator;

public class OutputHandler
{
    public void ShowMenu()
    {
        Console.WriteLine("=== ProCalculator VS 1.0 - Scientific Calculator ===");
        Console.WriteLine();
        Console.WriteLine("Basic");
        Console.WriteLine("   1. Add              (+)");
        Console.WriteLine("   2. Subtract         (-)");
        Console.WriteLine("   3. Multiply         (*)");
        Console.WriteLine("   4. Divide           (/)");
        Console.WriteLine("  18. Percentage       (%)");
        Console.WriteLine();
        Console.WriteLine("Scientific");
        Console.WriteLine("   5. Square root      (sqrt)");
        Console.WriteLine("   6. Power            (^)");
        Console.WriteLine("  15. Square           (sq)");
        Console.WriteLine("  16. Cube             (cube)");
        Console.WriteLine("   7. Sin (degrees)    (sin)");
        Console.WriteLine("   8. Cos (degrees)    (cos)");
        Console.WriteLine("   9. Tan (degrees)    (tan)");
        Console.WriteLine("  10. Log base 10      (log)");
        Console.WriteLine("  14. Natural log      (ln)");
        Console.WriteLine("  17. Factorial        (!)");
        Console.WriteLine();
        Console.WriteLine("Memory and history");
        Console.WriteLine("  11. Store memory     (ms)");
        Console.WriteLine("  12. Recall memory    (mr)");
        Console.WriteLine("  19. Memory add       (m+)");
        Console.WriteLine("  20. Memory subtract  (m-)");
        Console.WriteLine("  21. Memory clear     (mc)");
        Console.WriteLine("  13. Show history     (h)");
        Console.WriteLine("  22. Clear history    (hc)");
        Console.WriteLine();
        Console.WriteLine("Other");
        Console.WriteLine("  23. Change theme     (t)");
        Console.WriteLine("   0. Exit             (q)");
        Console.WriteLine();
        Console.WriteLine("Tip: when asked for a number you can type 'ans' (last result) or 'mr' (memory).");
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
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            // Output is redirected; there is no screen to clear.
        }
    }
}
