namespace ProCalculator;

/// <summary>Keeps the list of finished calculations, e.g. "12 + 5 = 17".</summary>
public class HistoryManager
{
    private readonly List<string> entries = new();

    public IReadOnlyList<string> Entries => entries;

    public int Count => entries.Count;

    public void Add(string entry) => entries.Add(entry);

    public void Clear() => entries.Clear();
}
