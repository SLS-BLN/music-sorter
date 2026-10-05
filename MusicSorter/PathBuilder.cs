namespace MusicSorter;
using System.Text.RegularExpressions;

public static class PathBuilder
{
    public static string CopyFolder (string artist, string albumTitle, string musicFolder)
    {
        // create target path
        var artistFolder = Regex.Replace(
            artist, 
            "[<>:/\\|?*]", 
            "_");

        var albumFolder = Regex.Replace (
            albumTitle,
            "[<>:/\\|?*]", 
            "_"
        );

        var copyFolder = Path.Combine(musicFolder, artistFolder, albumFolder);
        return copyFolder;
    }
}