public class HistoryManager
{
    private List<double> history = new List<double>();

    public void Add(double value)
    {
        history.Add(value);
    }

    public void ShowHistory()
    {
        Console.WriteLine("History: ");
        foreach (var item in history)
        {
            Console.WriteLine(item);
        }
    }
}