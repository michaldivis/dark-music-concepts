namespace TheoryPlayground.Playback;

public class AudioPlayer
{
    public static AudioPlayer Instance { get; } = new();

    public void Play(Note note)
    {
        throw new NotImplementedException();
    }

    public void Play(Chord chord)
    {
        throw new NotImplementedException();
    }
}
