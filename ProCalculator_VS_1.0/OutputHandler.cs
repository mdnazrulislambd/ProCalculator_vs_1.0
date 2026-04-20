public class OutputHandler
{
    public void ShowMenu()
    {
        Console.WriteLine("\n--- Welcome Our Scientific Calculator ---");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtact");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");
        Console.WriteLine("5. Square Root");
        Console.WriteLine("6. Power");
        Console.WriteLine("7. Sin");
        Console.WriteLine("8. Cos");
        Console.WriteLine("9. Ten");
        Console.WriteLine("10. Log");
        Console.WriteLine("11. Store Memory");
        Console.WriteLine("12. Recall Memory");
        Console.WriteLine("13. Show History");
        Console.WriteLine("0. Exit");
    }

    public void Print(string messag)
    {
        Console.WriteLine(messag);
    }
}