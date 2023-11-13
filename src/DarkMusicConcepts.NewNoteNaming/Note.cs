namespace DarkMusicConcepts.NewNoteNaming;

public class Note
{
    public Note(Pitch.Pitch pitch, Duration.Duration duration)
    {
        Pitch = pitch;
        Duration = duration;
    }

    public Pitch.Pitch Pitch { get; set; }
    public Duration.Duration Duration { get; set; }
}
