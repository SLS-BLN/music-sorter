namespace MusicSorter;
using System.Text.RegularExpressions;

public static class PathBuilder
{
    public static string BuildTargetPath (Album album)
    {
        // create target path
        var artistFolder = Regex.Replace(
            album.Artist, 
            "[<>:/\\|?*]", 
            "_");

        var albumFolder = Regex.Replace (
            album.Title,
            "[<>:/\\|?*]", 
            "_"
        );

        var copyFolder = Path.Combine(Configuration.MusicFolder, artistFolder, albumFolder);
        return copyFolder;
    }
}