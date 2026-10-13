namespace MusicSorter;

public static class Search
{
    public static Dictionary<string, List<string>> FindTracks(Album album)
    {
        Console.WriteLine("Searching...");  

        // Single enumeration for this call
        var allMp3Files = GetAllMp3Files(Configuration.SourceFolder).ToList();

        var results = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        // Normalize track names: trim whitespace and replace underscores with apostrophes.
        // NOTE: Google Takeout exports track names with underscores, while the accompanying CSV uses apostrophes.
        foreach (var track in album.Tracks)
        {
            var normalizedTrack = track
                .Replace("'", "_")
                .Trim();

            results[normalizedTrack] = allMp3Files
                .Where(path => ContainsTrack(path, normalizedTrack))
                .ToList();
        }

        return results;
    }

    // Get all mp3 files from the folder (no subdirectories)
    private static IEnumerable<string> GetAllMp3Files(string folder)
    {
        return Directory.EnumerateFiles(folder, "*.mp3", SearchOption.TopDirectoryOnly);
    }

    private static bool ContainsTrack(string path, string trackTitle)
    {
        var fileName = Path.GetFileNameWithoutExtension(path);
        return fileName.Contains(trackTitle, StringComparison.OrdinalIgnoreCase);
    }
}