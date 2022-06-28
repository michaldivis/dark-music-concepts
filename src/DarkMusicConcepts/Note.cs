namespace DarkMusicConcepts;

/// <summary>
/// Representation of a musical note
/// </summary>
public class Note
{
    private const int MidiMiddleMidiNumber = 60;
    private const double A4Frequency = 440.0;
    private const int OctaveRange = 12;

    public NotePitch BasePitch { get; }
    public Octave Octave { get; }

    public Note(NotePitch basePitch, Octave octave)
    {
        BasePitch = basePitch;
        Octave = octave;

        var pitch = GetPitch(basePitch, octave);
        Frequency = GetFrequency(pitch);
        MidiNumber = GetMidiNumber(pitch);
    }

    /// <summary>
    /// <para>A frequency of a note in Herz.</para>
    /// <para>A musical note emits a sound. Sound is a wave measured using its frequency (<see href="http://en.wikipedia.org/wiki/Frequency"/>). Hertz is the unit used to measure frequency of waves. If we want our Note to emit a sound we need to add a frequency value to it. Octaves affect frequency by doubling it or dividing it by two. So far we defined sound as pitch, but in reality pitch is more of a sound id. Frequency is the real sound.</para>
    /// <para>Note frequencies are mathematically related to each other, and are defined around the central note, A4 (A @ OneLine octave) <see href="http://en.wikipedia.org/wiki/Piano_key_frequencies"/>. The current "standard pitch" or modern "concert pitch" for this note is 440 Hz. The formula for frequency calculatio is:</para>
    /// <para>f = 2^n/12 * 440Hz(n is the pitch distance to A4 or A @ OneLine).</para>
    /// </summary>
    public double Frequency { get; }

    /// <summary>
    /// <para>MIDI number of a note.</para>
    /// <para>In MIDI, each note is assigned a numeric value, which is transmitted with any Note-On/Off message. Middle C has a reference value of 60. The MIDI standard only says that the note number 60 is a C, it does not say of which octave.</para>
    /// <para>The octave of middle C can be configured using the <see cref="DarkMusicConceptsCore.Configure(DarkMusicConceptsSettings)"/> method to specify a custom <see cref="DarkMusicConceptsSettings.MidiMiddleCOctave"/> value. Default value is <see cref="Octave.OneLine"/></para>
    /// </summary>
    public int MidiNumber { get; }

    private static int GetPitch(NotePitch basePitch, Octave octave)
    {
        return (int)basePitch + (OctaveRange * (int)octave);
    }

    private static double GetFrequency(int pitch)
    {
        var a4Pitch = GetPitch(NotePitch.A, Octave.OneLine);
        var relativePitchToA4 = pitch - a4Pitch;
        var power = (double)relativePitchToA4 / OctaveRange;
        return Math.Pow(2.0, power) * A4Frequency;
    }    

    private static int GetMidiNumber(int pitch)
    {
        var middleCPitch = GetPitch(NotePitch.C, DarkMusicConceptsCore.MidiMiddleCOctave);
        var relativePitchToMiddleC = pitch - middleCPitch;
        var midiNumber = MidiMiddleMidiNumber + relativePitchToMiddleC;
        return midiNumber;
    }
}
