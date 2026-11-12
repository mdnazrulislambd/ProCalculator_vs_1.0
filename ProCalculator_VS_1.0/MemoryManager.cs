namespace ProCalculator;

public class MemoryManager
{
    private double memory;

    public void Store(double value) => memory = value;

    public double Recall() => memory;

    /// <summary>M+ : adds a value to the stored memory.</summary>
    public void Add(double value) => memory += value;

    /// <summary>M- : subtracts a value from the stored memory.</summary>
    public void Subtract(double value) => memory -= value;

    public void Clear() => memory = 0;
}
