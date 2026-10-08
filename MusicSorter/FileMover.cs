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
            
            // Check if file already exists
            if (File.Exists(destinationPath))
            {
                Console.WriteLine($"File '{fileName}' already exists. Skipping.");
                continue;
            }

            try
            {
                File.Move(sourcePath, destinationPath);
                Console.WriteLine($"Moved '{fileName}' to '{destinationPath}'.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error moving '{fileName}': {ex.Message}");
            }
            
        }
    }
}