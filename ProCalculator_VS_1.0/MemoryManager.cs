public class MemoryManager
{
    private double memory;

    public void Store(double value)
    {
        memory = value;
    }

    public double Recall()
    {
        return memory;
    }

    public void Clear()
    {
        memory = 0;
    }
}