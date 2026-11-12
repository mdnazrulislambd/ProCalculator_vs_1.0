namespace ProCalculator;

public class CalculatorEngine
{
    private readonly InputHandler input = new();
    private readonly OutputHandler output = new();
    private readonly BasicOperations basic = new();
    private readonly ScientificOperations scientific = new();
    private readonly MemoryManager memory = new();
    private readonly HistoryManager history = new();
    private readonly ThemeManager theme = new();

    private double lastResult;

    public void Run()
    {
        try
        {
            while (true)
            {
                output.Clear();
                output.ShowMenu();

                input.LastAnswer = lastResult;
                input.MemoryValue = memory.Recall();

                int choice = input.GetMenuChoice();

                if (choice == 0)
                {
                    output.Print("Thank you for using ProCalculator!");
                    break;
                }

                try
                {
                    Execute(choice);
                }
                catch (Exception ex) when (ex is not InputClosedException)
                {
                    output.Print("Error: " + ex.Message);
                }

                WaitForUser();
            }
        }
        catch (InputClosedException)
        {
            output.Print("Input closed. Exiting calculator.");
        }
        finally
        {
            theme.Reset();
        }
    }

    private void Execute(int choice)
    {
        switch (choice)
        {
            case 1: Binary("+", basic.Add); break;
            case 2: Binary("-", basic.Subtract); break;
            case 3: Binary("*", basic.Multiply); break;
            case 4: Binary("/", basic.Divide); break;
            case 5: Unary("sqrt", scientific.Sqrt); break;
            case 6: Binary("^", scientific.Power); break;
            case 7: Unary("sin", scientific.Sin, "Angle in degrees"); break;
            case 8: Unary("cos", scientific.Cos, "Angle in degrees"); break;
            case 9: Unary("tan", scientific.Tan, "Angle in degrees"); break;
            case 10: Unary("log", scientific.Log); break;
            case 11: StoreMemory(); break;
            case 12: Record("MR", memory.Recall()); break;
            case 13: output.ShowHistory(history.Entries); break;
            case 14: Unary("ln", scientific.Ln); break;
            case 15: Unary("sq", scientific.Square); break;
            case 16: Unary("cube", scientific.Cube); break;
            case 17: Unary("fact", scientific.Factorial, "Whole number"); break;
            case 18: Percentage(); break;
            case 19: MemoryAdd(); break;
            case 20: MemorySubtract(); break;
            case 21: ClearMemory(); break;
            case 22: ClearHistory(); break;
            case 23: ChangeTheme(); break;
            default:
                output.Print("Invalid choice. Enter a number from the menu or a shortcut (for example +, sqrt, q).");
                break;
        }
    }

    private void Binary(string symbol, Func<double, double, double> operation)
    {
        double a = input.GetDouble("First number");
        double b = input.GetDouble("Second number");
        Record($"{NumberFormatter.Format(a)} {symbol} {NumberFormatter.Format(b)}", operation(a, b));
    }

    private void Unary(string name, Func<double, double> operation, string label = "Number")
    {
        double x = input.GetDouble(label);
        Record($"{name}({NumberFormatter.Format(x)})", operation(x));
    }

    private void Percentage()
    {
        double percent = input.GetDouble("Percentage");
        double value = input.GetDouble("Of number");
        Record($"{NumberFormatter.Format(percent)}% of {NumberFormatter.Format(value)}", basic.Percent(value, percent));
    }

    private void StoreMemory()
    {
        double value = input.GetDouble("Value to store");
        memory.Store(value);
        output.Print("Stored in memory: " + NumberFormatter.Format(value));
    }

    private void MemoryAdd()
    {
        double value = input.GetDouble("Value to add to memory");
        memory.Add(value);
        output.Print("Memory is now: " + NumberFormatter.Format(memory.Recall()));
    }

    private void MemorySubtract()
    {
        double value = input.GetDouble("Value to subtract from memory");
        memory.Subtract(value);
        output.Print("Memory is now: " + NumberFormatter.Format(memory.Recall()));
    }

    private void ClearMemory()
    {
        memory.Clear();
        output.Print("Memory cleared.");
    }

    private void ClearHistory()
    {
        history.Clear();
        output.Print("History cleared.");
    }

    private void ChangeTheme()
    {
        theme.Toggle();
        output.Print("Theme: " + theme.Name);
    }

    private void Record(string expression, double result)
    {
        if (!Validator.IsFinite(result))
            throw new ArithmeticException("The result is too large or is not a real number.");

        lastResult = result;
        string formatted = NumberFormatter.Format(result);
        output.Print("Result: " + formatted);
        history.Add($"{expression} = {formatted}");
    }

    private void WaitForUser()
    {
        output.Print("");
        output.Print("Press Enter to return to the menu...");
        input.ReadLine("");
    }
}
