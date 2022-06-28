namespace DarkMusicConcepts;

/// <summary>
/// Representation of a western musical note
/// </summary>
public class Note
{
    private const int A4MidiNumber = 69;
    private const double A4Frequency = 440.0;
    private const int OctaveRange = 12;

    public NotePitch BaseNotePitch { get; }
    public Octave Octave { get; }

    public Note(NotePitch baseNotePitch, Octave octave)
    {
        BaseNotePitch = baseNotePitch;
        Octave = octave;
    }

    public int Pitch => GetPitch();

    private int GetPitch()
    {
        return (int)BaseNotePitch + (OctaveRange * (int)Octave);
    }

    /// <summary>
    /// <para>A frequency of a note in Herz.</para>
    /// <para>A musical note emits a sound. Sound is a wave measured using its frequency (<see href="http://en.wikipedia.org/wiki/Frequency"/>). Hertz is the unit used to measure frequency of waves. If we want our Note to emit a sound we need to add a frequency value to it. Octaves affect frequency by doubling it or dividing it by two. So far we defined sound as pitch, but in reality pitch is more of a sound id. Frequency is the real sound.</para>
    /// <para>Note frequencies are mathematically related to each other, and are defined around the central note, A4 (A @ OneLine octave) <see href="http://en.wikipedia.org/wiki/Piano_key_frequencies"/>. The current "standard pitch" or modern "concert pitch" for this note is 440 Hz. The formula for frequency calculatio is:</para>
    /// <para>f = 2^n/12 * 440Hz(n is the pitch distance to A4 or A @ OneLine).</para>
    /// </summary>
    public double Frequency => GetFrequency();    

    private double GetFrequency()
    {
        var a4Pitch = new Note(NotePitch.A, Octave.OneLine).Pitch;
        var relativePitchToA4 = Pitch - a4Pitch;
        var power = (double)relativePitchToA4 / OctaveRange;
        return Math.Pow(2.0, power) * A4Frequency;
    }

    public int MidiNumber => GetMidiNumber();

    private int GetMidiNumber()
    {
        var midiNumber = Pitch + 24;
        return midiNumber;
    }
}