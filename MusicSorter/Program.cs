using MusicSorter;

// Get input
var albumTitle = Input.ReadAlbumTitle();
var artist = Input.ReadArtist();
var tracks = Input.ReadTracks();

// Create a path
var copyFolder = PathBuilder.CopyFolder(artist, albumTitle, Configuration.MusicFolder);

// Search files
var trackMatches = Search.FindTracks(Configuration.SourceFolder, tracks);

// Split into two lists
var singleMatches = trackMatches
    .Where(match => match.Value.Count == 1)
    .ToDictionary(match => match.Key, match => match.Value);

var restMatches = trackMatches
    .Where(match => match.Value.Count != 1)
    .ToDictionary(match => match.Key, match => match.Value);

// Ask for confirmation before moving files
if (Prompt.Confirm($"Do you want to move {singleMatches.Count} tracks automatically? Press 'Y' to move, any other key to skip:"))
{
    FileMover.Move(singleMatches, copyFolder);
}
else
{
    Console.WriteLine("Skipping...");
    restMatches = restMatches
        .Concat(singleMatches)
        .ToDictionary(match => match.Key, match => match.Value);
}

// Create a summary
Output.Summary(tracks.Count, singleMatches.Count, restMatches.Count);

// Display files that need manual handling (0 or >1 matches)
Output.Display(
    restMatches,
    "Tracks requiring manual action",
    "The following tracks could not be moved automatically:");
