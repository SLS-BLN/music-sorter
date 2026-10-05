namespace MusicSorter;

public static class Output
{
    public static void Summary(int totalTracks, int movedCount, int manualCount)
    {
        Console.WriteLine();
        Console.WriteLine($"Summary:");
        Console.WriteLine($"  Total tracks: {totalTracks}");
        Console.WriteLine($"  Moved automatically: {movedCount}");
        Console.WriteLine($"  Manual action needed: {manualCount}");
    }

    public static void Display(
        Dictionary<string, List<string>> items,
        string title,
        string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine(title);

        foreach (var item in items)
        {
            Console.WriteLine(item.Key);
        }
    }
}

