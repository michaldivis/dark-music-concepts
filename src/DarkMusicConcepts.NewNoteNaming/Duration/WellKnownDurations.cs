namespace DarkMusicConcepts.NewNoteNaming.Duration;

public class WellKnownDurations
{
    public RelativeDuration Eighth = new() { Beat = 1, BeatType = 8 };
    public RelativeDuration Half = new() { Beat = 1, BeatType = 2 };
    public RelativeDuration Quarter = new() { Beat = 1, BeatType = 4 };
    public RelativeDuration Sixteenth = new() { Beat = 1, BeatType = 16 };
    public RelativeDuration Whole = new() { Beat = 1, BeatType = 1 };
}