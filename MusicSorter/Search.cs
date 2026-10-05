namespace MusicSorter;

public class Search
{
    public static Dictionary<string, List<string>> FindTracks(
        string sourceFolder,
        List<string> tracks)
    {
        Console.WriteLine("Searching...");  

        // Single enumeration for this call
        var allMp3Tracks = GetAllMp3Files(sourceFolder).ToList();

        var results = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        foreach (var track in tracks)
        {
            var matches = allMp3Tracks
                              .Where(path => ContainsTrack(path, track))
                              .ToList();
            results[track] = matches;
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