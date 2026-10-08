namespace MusicSorter;

public static class Prompt
{
    public static bool Confirm(string message = "Press 'Y' to confirm, any other key to cancel:")
    {
        Console.Write(message);
        var key = Console.ReadKey(intercept: true);
        Console.WriteLine();
        return key.Key == ConsoleKey.Y;
    }
}