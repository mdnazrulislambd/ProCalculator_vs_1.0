namespace ProCalculator;

public enum Theme
{
    Default,
    Dark,
    Light
}

/// <summary>Switches the console between its default colors, a dark theme and a light theme.</summary>
public class ThemeManager
{
    public Theme Current { get; private set; } = Theme.Default;

    public string Name => Current.ToString();

    public void Toggle()
    {
        Current = Current switch
        {
            Theme.Default => Theme.Dark,
            Theme.Dark => Theme.Light,
            _ => Theme.Default
        };
        Apply();
    }

    public void Apply()
    {
        try
        {
            switch (Current)
            {
                case Theme.Dark:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Theme.Light:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
        catch (IOException)
        {
            // Output is redirected; colors do not apply.
        }
    }

    public void Reset()
    {
        try
        {
            Console.ResetColor();
        }
        catch (IOException)
        {
        }
    }
}
