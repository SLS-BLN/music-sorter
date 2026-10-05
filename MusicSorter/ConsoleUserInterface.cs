namespace MusicSorter;

public static class ConsoleUserInterface
{
    public static void Text(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ResetColor();
    }   
    
    public static void Success(string success)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(success);
        Console.ResetColor();
    }  
    
    public static void Error(string warning)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(warning);
        Console.ResetColor();   
    }
}