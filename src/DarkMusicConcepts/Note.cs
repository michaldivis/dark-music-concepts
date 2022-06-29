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
        Name = GetName(basePitch, octave);
        Frequency = GetFrequency(pitch);
        MidiNumber = GetMidiNumber(pitch);
    }

    public string Name { get; }

    public Frequency Frequency { get; }

    public MidiNumber MidiNumber { get; }

    private static string GetName(NotePitch basePitch, Octave octave)
    {
        return $"{basePitch}{(int)octave}";
    }

    private static int GetPitch(NotePitch basePitch, Octave octave)
    {
        return (int)basePitch + (OctaveRange * (int)octave);
    }

    private static Frequency GetFrequency(int pitch)
    {
        var a4Pitch = GetPitch(NotePitch.A, Octave.OneLine);
        var relativePitchToA4 = pitch - a4Pitch;
        var power = (double)relativePitchToA4 / OctaveRange;
        var frequency = Math.Pow(2.0, power) * A4Frequency;
        return Frequency.From(frequency);
    }    

    private static MidiNumber GetMidiNumber(int pitch)
    {
        var middleCPitch = GetPitch(NotePitch.C, DarkMusicConceptsCore.MidiMiddleCOctave);
        var relativePitchToMiddleC = pitch - middleCPitch;
        var midiNumber = MidiMiddleMidiNumber + relativePitchToMiddleC;
        return MidiNumber.From(midiNumber);
    }
}
