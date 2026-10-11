namespace MusicSorter;

public static class AlbumFinder
{
    public static bool AlbumExists(string artist, string albumTitle)
    {
        var path = Path.Combine(
            Configuration.MusicFolder,
            artist,
            albumTitle);

        return (Directory.Exists(path));
    }
}