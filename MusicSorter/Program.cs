using MusicSorter;

// Get input - album title and artist
var albumTitle = Input.ReadAlbumTitle();
var artist = Input.ReadArtist();

if (AlbumFinder.AlbumExists(artist, albumTitle))
{
    Console.WriteLine("Album already exists. Skipping...");
    return;
}

// Get input - tracks
var tracks = Input.ReadTracks();

var album = new Album(
    Artist: artist,
    Title: albumTitle,
    Tracks: tracks);

// Create a path
var targetPath  = PathBuilder.BuildTargetPath(album);

// Search files
// var trackMatches = Search.FindTracks(Configuration.SourceFolder, tracks);
var trackMatches = Search.FindTracks(album);

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
    FileMover.Move(singleMatches, targetPath );
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
