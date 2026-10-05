namespace MusicSorter;

// get artist, album title and tracks
public static class Input
{
    public static string ReadAlbumTitle()
    {
        return ReadRequiredInput("Wie heißt das Album?", "Albumtitel darf nicht leer sein.");
    }

    public static string ReadArtist()
    {
        return ReadRequiredInput("Wie heißt der Interpret?", "Interpret darf nicht leer sein.");
    }

    private static string ReadRequiredInput(string prompt, string errorMessage)
    {
        string? input;

        do
        {
            ConsoleUserInterface.Text(prompt);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                ConsoleUserInterface.Error(errorMessage);
            }
        } while (string.IsNullOrWhiteSpace(input));

        return input.Trim();
    }

    public static List<string> ReadTracks()
    {
        ConsoleUserInterface.Text("Bitte alle Songtitel eingeben. Pro Song eine neue Zeile.");
        ConsoleUserInterface.Text("Leerzeile beendet die Eingabe.");

        var tracks = new List<string>();

        while (true)
        {
            var line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
            {
                ConsoleUserInterface.Success("Eingabe beendet.");
                break;
            }

            line = line.Trim();
            tracks.Add(line);
        }

        return tracks;
    }
}