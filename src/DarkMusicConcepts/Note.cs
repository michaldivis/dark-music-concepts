namespace DarkMusicConcepts;

/// <summary>
/// Representation of a musical note
/// </summary>
public class Note : IEquatable<Note?>
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
        return $"{basePitch}{(int)octave}".Replace("Sharp", "#").Replace("Flat", "b");
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

    /// <summary>
    /// Find a note by MIDI number
    /// </summary>
    /// <param name="midiNumber">MIDI number to find the note by</param>
    /// <returns>A note that corresponds to that MIDI number</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static Note FindByMidiNumber(MidiNumber midiNumber)
    {
        var note = AllNotes.FirstOrDefault(a => a.MidiNumber == midiNumber);

        if (note is null)
        {
            throw new ArgumentOutOfRangeException(nameof(midiNumber), midiNumber, "Note with this MIDI number was not found");
        }

        return note;
    }

    /// <summary>
    /// Find a note by frequency
    /// </summary>
    /// <param name="frequency">Frequency to find the note by</param>
    /// <param name="precision">Comparison precision</param>
    /// <returns>A note that corresponds to that frequency</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static Note FindByFrequency(Frequency frequency, double precision = 0.01)
    {
        var note = AllNotes.FirstOrDefault(a => a.Frequency.EqualsWithPrecision(frequency, precision));

        if (note is null)
        {
            throw new ArgumentOutOfRangeException(nameof(frequency), frequency, "Note with this frequency was not found");
        }

        return note;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Note);
    }

    public bool Equals(Note? other)
    {
        return other is not null &&
               BasePitch == other.BasePitch &&
               Octave == other.Octave;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(BasePitch, Octave);
    }

    public static bool operator ==(Note note1, Note note2)
    {
        if (ReferenceEquals(note1, note2))
            return true;
        if (ReferenceEquals(note1, null))
            return false;
        if (ReferenceEquals(note2, null))
            return false;
        return note1.Equals(note2);
    }

    public static bool operator !=(Note note1, Note note2)
    {
        return !(note1 == note2);
    }

    public static Note C0 { get; } = new(NotePitch.C, Octave.SubContra);
    public static Note C1 { get; } = new(NotePitch.C, Octave.Contra);
    public static Note C2 { get; } = new(NotePitch.C, Octave.Great);
    public static Note C3 { get; } = new(NotePitch.C, Octave.Small);
    public static Note C4 { get; } = new(NotePitch.C, Octave.OneLine);
    public static Note C5 { get; } = new(NotePitch.C, Octave.TwoLine);
    public static Note C6 { get; } = new(NotePitch.C, Octave.ThreeLine);
    public static Note C7 { get; } = new(NotePitch.C, Octave.FourLine);
    public static Note C8 { get; } = new(NotePitch.C, Octave.FiveLine);
    public static Note C9 { get; } = new(NotePitch.C, Octave.SixLine);
    public static Note CSharp0 { get; } = new(NotePitch.CSharp, Octave.SubContra);
    public static Note CSharp1 { get; } = new(NotePitch.CSharp, Octave.Contra);
    public static Note CSharp2 { get; } = new(NotePitch.CSharp, Octave.Great);
    public static Note CSharp3 { get; } = new(NotePitch.CSharp, Octave.Small);
    public static Note CSharp4 { get; } = new(NotePitch.CSharp, Octave.OneLine);
    public static Note CSharp5 { get; } = new(NotePitch.CSharp, Octave.TwoLine);
    public static Note CSharp6 { get; } = new(NotePitch.CSharp, Octave.ThreeLine);
    public static Note CSharp7 { get; } = new(NotePitch.CSharp, Octave.FourLine);
    public static Note CSharp8 { get; } = new(NotePitch.CSharp, Octave.FiveLine);
    public static Note CSharp9 { get; } = new(NotePitch.CSharp, Octave.SixLine);
    public static Note DFlat0 { get; } = new(NotePitch.DFlat, Octave.SubContra);
    public static Note DFlat1 { get; } = new(NotePitch.DFlat, Octave.Contra);
    public static Note DFlat2 { get; } = new(NotePitch.DFlat, Octave.Great);
    public static Note DFlat3 { get; } = new(NotePitch.DFlat, Octave.Small);
    public static Note DFlat4 { get; } = new(NotePitch.DFlat, Octave.OneLine);
    public static Note DFlat5 { get; } = new(NotePitch.DFlat, Octave.TwoLine);
    public static Note DFlat6 { get; } = new(NotePitch.DFlat, Octave.ThreeLine);
    public static Note DFlat7 { get; } = new(NotePitch.DFlat, Octave.FourLine);
    public static Note DFlat8 { get; } = new(NotePitch.DFlat, Octave.FiveLine);
    public static Note DFlat9 { get; } = new(NotePitch.DFlat, Octave.SixLine);
    public static Note D0 { get; } = new(NotePitch.D, Octave.SubContra);
    public static Note D1 { get; } = new(NotePitch.D, Octave.Contra);
    public static Note D2 { get; } = new(NotePitch.D, Octave.Great);
    public static Note D3 { get; } = new(NotePitch.D, Octave.Small);
    public static Note D4 { get; } = new(NotePitch.D, Octave.OneLine);
    public static Note D5 { get; } = new(NotePitch.D, Octave.TwoLine);
    public static Note D6 { get; } = new(NotePitch.D, Octave.ThreeLine);
    public static Note D7 { get; } = new(NotePitch.D, Octave.FourLine);
    public static Note D8 { get; } = new(NotePitch.D, Octave.FiveLine);
    public static Note D9 { get; } = new(NotePitch.D, Octave.SixLine);
    public static Note DSharp0 { get; } = new(NotePitch.DSharp, Octave.SubContra);
    public static Note DSharp1 { get; } = new(NotePitch.DSharp, Octave.Contra);
    public static Note DSharp2 { get; } = new(NotePitch.DSharp, Octave.Great);
    public static Note DSharp3 { get; } = new(NotePitch.DSharp, Octave.Small);
    public static Note DSharp4 { get; } = new(NotePitch.DSharp, Octave.OneLine);
    public static Note DSharp5 { get; } = new(NotePitch.DSharp, Octave.TwoLine);
    public static Note DSharp6 { get; } = new(NotePitch.DSharp, Octave.ThreeLine);
    public static Note DSharp7 { get; } = new(NotePitch.DSharp, Octave.FourLine);
    public static Note DSharp8 { get; } = new(NotePitch.DSharp, Octave.FiveLine);
    public static Note DSharp9 { get; } = new(NotePitch.DSharp, Octave.SixLine);
    public static Note EFlat0 { get; } = new(NotePitch.EFlat, Octave.SubContra);
    public static Note EFlat1 { get; } = new(NotePitch.EFlat, Octave.Contra);
    public static Note EFlat2 { get; } = new(NotePitch.EFlat, Octave.Great);
    public static Note EFlat3 { get; } = new(NotePitch.EFlat, Octave.Small);
    public static Note EFlat4 { get; } = new(NotePitch.EFlat, Octave.OneLine);
    public static Note EFlat5 { get; } = new(NotePitch.EFlat, Octave.TwoLine);
    public static Note EFlat6 { get; } = new(NotePitch.EFlat, Octave.ThreeLine);
    public static Note EFlat7 { get; } = new(NotePitch.EFlat, Octave.FourLine);
    public static Note EFlat8 { get; } = new(NotePitch.EFlat, Octave.FiveLine);
    public static Note EFlat9 { get; } = new(NotePitch.EFlat, Octave.SixLine);
    public static Note E0 { get; } = new(NotePitch.E, Octave.SubContra);
    public static Note E1 { get; } = new(NotePitch.E, Octave.Contra);
    public static Note E2 { get; } = new(NotePitch.E, Octave.Great);
    public static Note E3 { get; } = new(NotePitch.E, Octave.Small);
    public static Note E4 { get; } = new(NotePitch.E, Octave.OneLine);
    public static Note E5 { get; } = new(NotePitch.E, Octave.TwoLine);
    public static Note E6 { get; } = new(NotePitch.E, Octave.ThreeLine);
    public static Note E7 { get; } = new(NotePitch.E, Octave.FourLine);
    public static Note E8 { get; } = new(NotePitch.E, Octave.FiveLine);
    public static Note E9 { get; } = new(NotePitch.E, Octave.SixLine);
    public static Note F0 { get; } = new(NotePitch.F, Octave.SubContra);
    public static Note F1 { get; } = new(NotePitch.F, Octave.Contra);
    public static Note F2 { get; } = new(NotePitch.F, Octave.Great);
    public static Note F3 { get; } = new(NotePitch.F, Octave.Small);
    public static Note F4 { get; } = new(NotePitch.F, Octave.OneLine);
    public static Note F5 { get; } = new(NotePitch.F, Octave.TwoLine);
    public static Note F6 { get; } = new(NotePitch.F, Octave.ThreeLine);
    public static Note F7 { get; } = new(NotePitch.F, Octave.FourLine);
    public static Note F8 { get; } = new(NotePitch.F, Octave.FiveLine);
    public static Note F9 { get; } = new(NotePitch.F, Octave.SixLine);
    public static Note FSharp0 { get; } = new(NotePitch.FSharp, Octave.SubContra);
    public static Note FSharp1 { get; } = new(NotePitch.FSharp, Octave.Contra);
    public static Note FSharp2 { get; } = new(NotePitch.FSharp, Octave.Great);
    public static Note FSharp3 { get; } = new(NotePitch.FSharp, Octave.Small);
    public static Note FSharp4 { get; } = new(NotePitch.FSharp, Octave.OneLine);
    public static Note FSharp5 { get; } = new(NotePitch.FSharp, Octave.TwoLine);
    public static Note FSharp6 { get; } = new(NotePitch.FSharp, Octave.ThreeLine);
    public static Note FSharp7 { get; } = new(NotePitch.FSharp, Octave.FourLine);
    public static Note FSharp8 { get; } = new(NotePitch.FSharp, Octave.FiveLine);
    public static Note FSharp9 { get; } = new(NotePitch.FSharp, Octave.SixLine);
    public static Note GFlat0 { get; } = new(NotePitch.GFlat, Octave.SubContra);
    public static Note GFlat1 { get; } = new(NotePitch.GFlat, Octave.Contra);
    public static Note GFlat2 { get; } = new(NotePitch.GFlat, Octave.Great);
    public static Note GFlat3 { get; } = new(NotePitch.GFlat, Octave.Small);
    public static Note GFlat4 { get; } = new(NotePitch.GFlat, Octave.OneLine);
    public static Note GFlat5 { get; } = new(NotePitch.GFlat, Octave.TwoLine);
    public static Note GFlat6 { get; } = new(NotePitch.GFlat, Octave.ThreeLine);
    public static Note GFlat7 { get; } = new(NotePitch.GFlat, Octave.FourLine);
    public static Note GFlat8 { get; } = new(NotePitch.GFlat, Octave.FiveLine);
    public static Note GFlat9 { get; } = new(NotePitch.GFlat, Octave.SixLine);
    public static Note G0 { get; } = new(NotePitch.G, Octave.SubContra);
    public static Note G1 { get; } = new(NotePitch.G, Octave.Contra);
    public static Note G2 { get; } = new(NotePitch.G, Octave.Great);
    public static Note G3 { get; } = new(NotePitch.G, Octave.Small);
    public static Note G4 { get; } = new(NotePitch.G, Octave.OneLine);
    public static Note G5 { get; } = new(NotePitch.G, Octave.TwoLine);
    public static Note G6 { get; } = new(NotePitch.G, Octave.ThreeLine);
    public static Note G7 { get; } = new(NotePitch.G, Octave.FourLine);
    public static Note G8 { get; } = new(NotePitch.G, Octave.FiveLine);
    public static Note G9 { get; } = new(NotePitch.G, Octave.SixLine);
    public static Note GSharp0 { get; } = new(NotePitch.GSharp, Octave.SubContra);
    public static Note GSharp1 { get; } = new(NotePitch.GSharp, Octave.Contra);
    public static Note GSharp2 { get; } = new(NotePitch.GSharp, Octave.Great);
    public static Note GSharp3 { get; } = new(NotePitch.GSharp, Octave.Small);
    public static Note GSharp4 { get; } = new(NotePitch.GSharp, Octave.OneLine);
    public static Note GSharp5 { get; } = new(NotePitch.GSharp, Octave.TwoLine);
    public static Note GSharp6 { get; } = new(NotePitch.GSharp, Octave.ThreeLine);
    public static Note GSharp7 { get; } = new(NotePitch.GSharp, Octave.FourLine);
    public static Note GSharp8 { get; } = new(NotePitch.GSharp, Octave.FiveLine);
    public static Note GSharp9 { get; } = new(NotePitch.GSharp, Octave.SixLine);
    public static Note AFlat0 { get; } = new(NotePitch.AFlat, Octave.SubContra);
    public static Note AFlat1 { get; } = new(NotePitch.AFlat, Octave.Contra);
    public static Note AFlat2 { get; } = new(NotePitch.AFlat, Octave.Great);
    public static Note AFlat3 { get; } = new(NotePitch.AFlat, Octave.Small);
    public static Note AFlat4 { get; } = new(NotePitch.AFlat, Octave.OneLine);
    public static Note AFlat5 { get; } = new(NotePitch.AFlat, Octave.TwoLine);
    public static Note AFlat6 { get; } = new(NotePitch.AFlat, Octave.ThreeLine);
    public static Note AFlat7 { get; } = new(NotePitch.AFlat, Octave.FourLine);
    public static Note AFlat8 { get; } = new(NotePitch.AFlat, Octave.FiveLine);
    public static Note AFlat9 { get; } = new(NotePitch.AFlat, Octave.SixLine);
    public static Note A0 { get; } = new(NotePitch.A, Octave.SubContra);
    public static Note A1 { get; } = new(NotePitch.A, Octave.Contra);
    public static Note A2 { get; } = new(NotePitch.A, Octave.Great);
    public static Note A3 { get; } = new(NotePitch.A, Octave.Small);
    public static Note A4 { get; } = new(NotePitch.A, Octave.OneLine);
    public static Note A5 { get; } = new(NotePitch.A, Octave.TwoLine);
    public static Note A6 { get; } = new(NotePitch.A, Octave.ThreeLine);
    public static Note A7 { get; } = new(NotePitch.A, Octave.FourLine);
    public static Note A8 { get; } = new(NotePitch.A, Octave.FiveLine);
    public static Note A9 { get; } = new(NotePitch.A, Octave.SixLine);
    public static Note ASharp0 { get; } = new(NotePitch.ASharp, Octave.SubContra);
    public static Note ASharp1 { get; } = new(NotePitch.ASharp, Octave.Contra);
    public static Note ASharp2 { get; } = new(NotePitch.ASharp, Octave.Great);
    public static Note ASharp3 { get; } = new(NotePitch.ASharp, Octave.Small);
    public static Note ASharp4 { get; } = new(NotePitch.ASharp, Octave.OneLine);
    public static Note ASharp5 { get; } = new(NotePitch.ASharp, Octave.TwoLine);
    public static Note ASharp6 { get; } = new(NotePitch.ASharp, Octave.ThreeLine);
    public static Note ASharp7 { get; } = new(NotePitch.ASharp, Octave.FourLine);
    public static Note ASharp8 { get; } = new(NotePitch.ASharp, Octave.FiveLine);
    public static Note ASharp9 { get; } = new(NotePitch.ASharp, Octave.SixLine);
    public static Note BFlat0 { get; } = new(NotePitch.BFlat, Octave.SubContra);
    public static Note BFlat1 { get; } = new(NotePitch.BFlat, Octave.Contra);
    public static Note BFlat2 { get; } = new(NotePitch.BFlat, Octave.Great);
    public static Note BFlat3 { get; } = new(NotePitch.BFlat, Octave.Small);
    public static Note BFlat4 { get; } = new(NotePitch.BFlat, Octave.OneLine);
    public static Note BFlat5 { get; } = new(NotePitch.BFlat, Octave.TwoLine);
    public static Note BFlat6 { get; } = new(NotePitch.BFlat, Octave.ThreeLine);
    public static Note BFlat7 { get; } = new(NotePitch.BFlat, Octave.FourLine);
    public static Note BFlat8 { get; } = new(NotePitch.BFlat, Octave.FiveLine);
    public static Note BFlat9 { get; } = new(NotePitch.BFlat, Octave.SixLine);
    public static Note B0 { get; } = new(NotePitch.B, Octave.SubContra);
    public static Note B1 { get; } = new(NotePitch.B, Octave.Contra);
    public static Note B2 { get; } = new(NotePitch.B, Octave.Great);
    public static Note B3 { get; } = new(NotePitch.B, Octave.Small);
    public static Note B4 { get; } = new(NotePitch.B, Octave.OneLine);
    public static Note B5 { get; } = new(NotePitch.B, Octave.TwoLine);
    public static Note B6 { get; } = new(NotePitch.B, Octave.ThreeLine);
    public static Note B7 { get; } = new(NotePitch.B, Octave.FourLine);
    public static Note B8 { get; } = new(NotePitch.B, Octave.FiveLine);
    public static Note B9 { get; } = new(NotePitch.B, Octave.SixLine);

    public static List<Note> AllNotes { get; } = new()
    {
        C0,
        CSharp0,
        DFlat0,
        D0,
        DSharp0,
        EFlat0,
        E0,
        F0,
        FSharp0,
        GFlat0,
        G0,
        AFlat0,
        A0,
        ASharp0,
        BFlat0,
        B0,
        C1,
        CSharp1,
        DFlat1,
        D1,
        DSharp1,
        EFlat1,
        E1,
        F1,
        FSharp1,
        GFlat1,
        G1,
        AFlat1,
        A1,
        ASharp1,
        BFlat1,
        B1,
        C2,
        CSharp2,
        DFlat2,
        D2,
        DSharp2,
        EFlat2,
        E2,
        F2,
        FSharp2,
        GFlat2,
        G2,
        AFlat2,
        A2,
        ASharp2,
        BFlat2,
        B2,
        C3,
        CSharp3,
        DFlat3,
        D3,
        DSharp3,
        EFlat3,
        E3,
        F3,
        FSharp3,
        GFlat3,
        G3,
        AFlat3,
        A3,
        ASharp3,
        BFlat3,
        B3,
        C4,
        CSharp4,
        DFlat4,
        D4,
        DSharp4,
        EFlat4,
        E4,
        F4,
        FSharp4,
        GFlat4,
        G4,
        AFlat4,
        A4,
        ASharp4,
        BFlat4,
        B4,
        C5,
        CSharp5,
        DFlat5,
        D5,
        DSharp5,
        EFlat5,
        E5,
        F5,
        FSharp5,
        GFlat5,
        G5,
        AFlat5,
        A5,
        ASharp5,
        BFlat5,
        B5,
        C6,
        CSharp6,
        DFlat6,
        D6,
        DSharp6,
        EFlat6,
        E6,
        F6,
        FSharp6,
        GFlat6,
        G6,
        AFlat6,
        A6,
        ASharp6,
        BFlat6,
        B6,
        C7,
        CSharp7,
        DFlat7,
        D7,
        DSharp7,
        EFlat7,
        E7,
        F7,
        FSharp7,
        GFlat7,
        G7,
        AFlat7,
        A7,
        ASharp7,
        BFlat7,
        B7,
        C8,
        CSharp8,
        DFlat8,
        D8,
        DSharp8,
        EFlat8,
        E8,
        F8,
        FSharp8,
        GFlat8,
        G8,
        AFlat8,
        A8,
        ASharp8,
        BFlat8,
        B8,
        C9,
        CSharp9,
        DFlat9,
        D9,
        DSharp9,
        EFlat9,
        E9,
        F9,
        FSharp9,
        GFlat9,
        G9,
        AFlat9,
        A9,
        ASharp9,
        BFlat9,
        B9
    };
}
