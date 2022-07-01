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
        return $"{basePitch}{(int)octave}"
            .Replace("Or", "/")
            .Replace("Sharp", "#")
            .Replace("Flat", "b");
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
    public static Note CSharpOrDFlat0 { get; } = new(NotePitch.CSharpOrDFlat, Octave.SubContra);
    public static Note CSharpOrDFlat1 { get; } = new(NotePitch.CSharpOrDFlat, Octave.Contra);
    public static Note CSharpOrDFlat2 { get; } = new(NotePitch.CSharpOrDFlat, Octave.Great);
    public static Note CSharpOrDFlat3 { get; } = new(NotePitch.CSharpOrDFlat, Octave.Small);
    public static Note CSharpOrDFlat4 { get; } = new(NotePitch.CSharpOrDFlat, Octave.OneLine);
    public static Note CSharpOrDFlat5 { get; } = new(NotePitch.CSharpOrDFlat, Octave.TwoLine);
    public static Note CSharpOrDFlat6 { get; } = new(NotePitch.CSharpOrDFlat, Octave.ThreeLine);
    public static Note CSharpOrDFlat7 { get; } = new(NotePitch.CSharpOrDFlat, Octave.FourLine);
    public static Note CSharpOrDFlat8 { get; } = new(NotePitch.CSharpOrDFlat, Octave.FiveLine);
    public static Note CSharpOrDFlat9 { get; } = new(NotePitch.CSharpOrDFlat, Octave.SixLine);
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
    public static Note DSharpOrEFlat0 { get; } = new(NotePitch.DSharpOrEFlat, Octave.SubContra);
    public static Note DSharpOrEFlat1 { get; } = new(NotePitch.DSharpOrEFlat, Octave.Contra);
    public static Note DSharpOrEFlat2 { get; } = new(NotePitch.DSharpOrEFlat, Octave.Great);
    public static Note DSharpOrEFlat3 { get; } = new(NotePitch.DSharpOrEFlat, Octave.Small);
    public static Note DSharpOrEFlat4 { get; } = new(NotePitch.DSharpOrEFlat, Octave.OneLine);
    public static Note DSharpOrEFlat5 { get; } = new(NotePitch.DSharpOrEFlat, Octave.TwoLine);
    public static Note DSharpOrEFlat6 { get; } = new(NotePitch.DSharpOrEFlat, Octave.ThreeLine);
    public static Note DSharpOrEFlat7 { get; } = new(NotePitch.DSharpOrEFlat, Octave.FourLine);
    public static Note DSharpOrEFlat8 { get; } = new(NotePitch.DSharpOrEFlat, Octave.FiveLine);
    public static Note DSharpOrEFlat9 { get; } = new(NotePitch.DSharpOrEFlat, Octave.SixLine);
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
    public static Note FSharpOrGFlat0 { get; } = new(NotePitch.FSharpOrGFlat, Octave.SubContra);
    public static Note FSharpOrGFlat1 { get; } = new(NotePitch.FSharpOrGFlat, Octave.Contra);
    public static Note FSharpOrGFlat2 { get; } = new(NotePitch.FSharpOrGFlat, Octave.Great);
    public static Note FSharpOrGFlat3 { get; } = new(NotePitch.FSharpOrGFlat, Octave.Small);
    public static Note FSharpOrGFlat4 { get; } = new(NotePitch.FSharpOrGFlat, Octave.OneLine);
    public static Note FSharpOrGFlat5 { get; } = new(NotePitch.FSharpOrGFlat, Octave.TwoLine);
    public static Note FSharpOrGFlat6 { get; } = new(NotePitch.FSharpOrGFlat, Octave.ThreeLine);
    public static Note FSharpOrGFlat7 { get; } = new(NotePitch.FSharpOrGFlat, Octave.FourLine);
    public static Note FSharpOrGFlat8 { get; } = new(NotePitch.FSharpOrGFlat, Octave.FiveLine);
    public static Note FSharpOrGFlat9 { get; } = new(NotePitch.FSharpOrGFlat, Octave.SixLine);
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
    public static Note GSharpOrAFlat0 { get; } = new(NotePitch.GSharpOrAFlat, Octave.SubContra);
    public static Note GSharpOrAFlat1 { get; } = new(NotePitch.GSharpOrAFlat, Octave.Contra);
    public static Note GSharpOrAFlat2 { get; } = new(NotePitch.GSharpOrAFlat, Octave.Great);
    public static Note GSharpOrAFlat3 { get; } = new(NotePitch.GSharpOrAFlat, Octave.Small);
    public static Note GSharpOrAFlat4 { get; } = new(NotePitch.GSharpOrAFlat, Octave.OneLine);
    public static Note GSharpOrAFlat5 { get; } = new(NotePitch.GSharpOrAFlat, Octave.TwoLine);
    public static Note GSharpOrAFlat6 { get; } = new(NotePitch.GSharpOrAFlat, Octave.ThreeLine);
    public static Note GSharpOrAFlat7 { get; } = new(NotePitch.GSharpOrAFlat, Octave.FourLine);
    public static Note GSharpOrAFlat8 { get; } = new(NotePitch.GSharpOrAFlat, Octave.FiveLine);
    public static Note GSharpOrAFlat9 { get; } = new(NotePitch.GSharpOrAFlat, Octave.SixLine);
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
    public static Note ASharpOrBFlat0 { get; } = new(NotePitch.ASharpOrBFlat, Octave.SubContra);
    public static Note ASharpOrBFlat1 { get; } = new(NotePitch.ASharpOrBFlat, Octave.Contra);
    public static Note ASharpOrBFlat2 { get; } = new(NotePitch.ASharpOrBFlat, Octave.Great);
    public static Note ASharpOrBFlat3 { get; } = new(NotePitch.ASharpOrBFlat, Octave.Small);
    public static Note ASharpOrBFlat4 { get; } = new(NotePitch.ASharpOrBFlat, Octave.OneLine);
    public static Note ASharpOrBFlat5 { get; } = new(NotePitch.ASharpOrBFlat, Octave.TwoLine);
    public static Note ASharpOrBFlat6 { get; } = new(NotePitch.ASharpOrBFlat, Octave.ThreeLine);
    public static Note ASharpOrBFlat7 { get; } = new(NotePitch.ASharpOrBFlat, Octave.FourLine);
    public static Note ASharpOrBFlat8 { get; } = new(NotePitch.ASharpOrBFlat, Octave.FiveLine);
    public static Note ASharpOrBFlat9 { get; } = new(NotePitch.ASharpOrBFlat, Octave.SixLine);
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
        CSharpOrDFlat0,
        D0,
        DSharpOrEFlat0,
        E0,
        F0,
        FSharpOrGFlat0,
        G0,
        A0,
        ASharpOrBFlat0,
        B0,
        C1,
        CSharpOrDFlat1,
        D1,
        DSharpOrEFlat1,
        E1,
        F1,
        FSharpOrGFlat1,
        G1,
        A1,
        ASharpOrBFlat1,
        B1,
        C2,
        CSharpOrDFlat2,
        D2,
        DSharpOrEFlat2,
        E2,
        F2,
        FSharpOrGFlat2,
        G2,
        A2,
        ASharpOrBFlat2,
        B2,
        C3,
        CSharpOrDFlat3,
        D3,
        DSharpOrEFlat3,
        E3,
        F3,
        FSharpOrGFlat3,
        G3,
        A3,
        ASharpOrBFlat3,
        B3,
        C4,
        CSharpOrDFlat4,
        D4,
        DSharpOrEFlat4,
        E4,
        F4,
        FSharpOrGFlat4,
        G4,
        A4,
        ASharpOrBFlat4,
        B4,
        C5,
        CSharpOrDFlat5,
        D5,
        DSharpOrEFlat5,
        E5,
        F5,
        FSharpOrGFlat5,
        G5,
        A5,
        ASharpOrBFlat5,
        B5,
        C6,
        CSharpOrDFlat6,
        D6,
        DSharpOrEFlat6,
        E6,
        F6,
        FSharpOrGFlat6,
        G6,
        A6,
        ASharpOrBFlat6,
        B6,
        C7,
        CSharpOrDFlat7,
        D7,
        DSharpOrEFlat7,
        E7,
        F7,
        FSharpOrGFlat7,
        G7,
        A7,
        ASharpOrBFlat7,
        B7,
        C8,
        CSharpOrDFlat8,
        D8,
        DSharpOrEFlat8,
        E8,
        F8,
        FSharpOrGFlat8,
        G8,
        A8,
        ASharpOrBFlat8,
        B8,
        C9,
        CSharpOrDFlat9,
        D9,
        DSharpOrEFlat9,
        E9,
        F9,
        FSharpOrGFlat9,
        G9,
        A9,
        ASharpOrBFlat9,
        B9
    };
}
