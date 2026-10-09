namespace MusicSorter;

public static class Search
{
    public static Dictionary<string, List<string>> FindTracks(
        string sourceFolder,
        List<string> tracks)
    {
        Console.WriteLine("Searching...");  

        // Single enumeration for this call
        var allMp3Files = GetAllMp3Files(sourceFolder).ToList();

        var results = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        // Normalize track names: trim whitespace and replace underscores with apostrophes.
        // NOTE: Google Takeout exports track names with underscores, while the accompanying CSV uses apostrophes.
        var normalizedTracks = tracks
            .Select(t => t.Replace("_", "'").Trim())
            .ToList();
        
        foreach (var track in normalizedTracks)
        {
            results[track] = allMp3Files
                .Where(path => ContainsTrack(path, track))
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