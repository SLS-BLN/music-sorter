namespace MusicSorter;

public static class FileMover
{
    public static void Move(
        Dictionary<string, List<string>> singleMatches,
        string destinationFolder)
    {
        Directory.CreateDirectory(destinationFolder);

        foreach (var match in singleMatches)
        {
            var sourcePath = match.Value[0];
            var fileName = Path.GetFileName(sourcePath);
            var destinationPath = Path.Combine(destinationFolder, fileName);

            File.Move(sourcePath, destinationPath);
        }
    }
}