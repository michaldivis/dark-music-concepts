namespace DarkMusicConcepts.NewNoteNaming.Duration;

/// <summary>
///     Standard relative musical duration is fraction: nominator for length of duration and denominator
///     for relative measurement unit like quarter, eighth, sixteenth
/// </summary>
public class RelativeDuration : Duration
{
    public int Beat { get; set; }
    public int BeatType { get; set; }
}