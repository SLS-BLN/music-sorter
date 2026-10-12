namespace MusicSorter;

public sealed record Album(
    string Artist,
    string Title,
    IReadOnlyList<string> Tracks);