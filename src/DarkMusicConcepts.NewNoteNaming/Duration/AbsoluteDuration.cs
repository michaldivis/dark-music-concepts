namespace DarkMusicConcepts.NewNoteNaming.Duration;

/// <summary>
///     Absolute duration
/// </summary>
public class AbsoluteDuration : Duration
{
    public int MidiTicks { get; set; }
    public double Seconds { get; set; }
}