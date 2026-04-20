public class InputHandler
{
    public double GetDouble()
    {
        Console.Write("Enter number: ");
        return Convert.ToDouble(Console.ReadLine());
    }

    public int GetIntInput()
    {
        Console.Write("Select option: ");
        return Convert.ToInt32(Console.ReadLine());
    }
}

