namespace DarkMusicConcepts.Notes;

/// <summary>
/// In music, a note is a symbol denoting a musical sound. In English usage, a note is also the sound itself. Notes can represent the pitch and duration of a sound in musical notation. A note can also represent a pitch class.
/// </summary>
public partial class Note : IEquatable<Note?>
{
    private const int MidiMiddleCNumber = 60;
    private const double A4Frequency = 440.0;
    private const int OctaveRange = 12;

    /// <summary>
    /// Internal representation of a Note's pitch
    /// </summary>
    private readonly int _pitch;

    public NotePitch BasePitch { get; }
    public Octave Octave { get; }

    public Note(NotePitch basePitch, Octave octave)
    {
        BasePitch = basePitch;
        Octave = octave;

        _pitch = GetPitch(basePitch, octave);
        Name = GetName(basePitch, octave);
        Frequency = GetFrequency(_pitch);
        MidiNumber = GetMidiNumber(_pitch);
    }

    public string Name { get; }

    public Frequency Frequency { get; }

    public MidiNumber? MidiNumber { get; }

    private static string GetName(NotePitch basePitch, Octave octave)
    {
        return $"{basePitch}{(int)octave}"
            .Replace("Or", "/")
            .Replace("Sharp", "#")
            .Replace("Flat", "b");
    }

    private static int GetPitch(NotePitch basePitch, Octave octave)
    {
        return (int)basePitch + OctaveRange * (int)octave;
    }

    private static Frequency GetFrequency(int pitch)
    {
        var a4Pitch = GetPitch(NotePitch.A, Octave.OneLine);
        var relativePitchToA4 = pitch - a4Pitch;
        var power = (double)relativePitchToA4 / OctaveRange;
        var frequency = Math.Pow(2.0, power) * A4Frequency;
        return Frequency.From(frequency);
    }

    private static MidiNumber? GetMidiNumber(int pitch)
    {
        var middleCPitch = GetPitch(NotePitch.C, DarkMusicConceptsCore.MidiMiddleCOctave);
        var relativePitchToMiddleC = pitch - middleCPitch;
        var midiNumber = MidiMiddleCNumber + relativePitchToMiddleC;

        if (midiNumber < MidiNumber.Min)
        {
            return null;
        }

        if (midiNumber > MidiNumber.Max)
        {
            return null;
        }

        return MidiNumber.From(midiNumber);
    }

    /// <summary>
    /// Find a note by MIDI number
    /// </summary>
    /// <param name="midiNumber">MIDI number to find the note by</param>
    /// <param name="note">A found note that corresponds to that MIDI number</param>
    /// <returns><see langword="true"/> if found</returns>
    public static bool TryFindByMidiNumber(MidiNumber midiNumber, out Note? note)
    {
        var found = AllNotes.FirstOrDefault(a => a.MidiNumber == midiNumber);

        if (found is null)
        {
            note = null;
            return false;
        }

        note = found;
        return true;
    }

    /// <summary>
    /// Find a note by MIDI number
    /// </summary>
    /// <param name="midiNumber">MIDI number to find the note by</param>
    /// <returns>A note that corresponds to that MIDI number</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static Note FindByMidiNumber(MidiNumber midiNumber)
    {
        var success = TryFindByMidiNumber(midiNumber, out var note);

        if (!success)
        {
            throw new ArgumentOutOfRangeException(nameof(midiNumber), midiNumber, "Note with this MIDI number was not found");
        }

        return note!;
    }

    /// <summary>
    /// Find a note by frequency
    /// </summary>
    /// <param name="frequency">Frequency to find the note by</param>
    /// <param name="precision">Comparison precision</param>
    /// <param name="note">A note that corresponds to that frequency</param>
    /// <returns><see langword="true"/> if found</returns>
    public static bool TryFindByFrequency(Frequency frequency, out Note? note, double precision = 0.01)
    {
        var found = AllNotes.FirstOrDefault(a => a.Frequency.EqualsWithPrecision(frequency, precision));

        if (found is null)
        {
            note = null;
            return false;
        }

        note = found;
        return true;
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
        var success = TryFindByFrequency(frequency, out var note, precision);

        if (!success)
        {
            throw new ArgumentOutOfRangeException(nameof(frequency), frequency, "Note with this frequency was not found");
        }

        return note!;
    }

    /// <summary>
    /// Transpose a note by a specific internval
    /// </summary>
    /// <param name="interval">Interval to trasnpose by</param>
    /// <returns>Transposed note</returns>
    /// <exception cref="ArgumentException"></exception>
    public Note Transpose(Interval interval)
    {
        var success = TryTranspose(interval, out var note);

        if (!success)
        {
            throw new ArgumentException("Interval transposes the note out of possible range", nameof(interval));
        }
        
        return note!;
    }

    /// <summary>
    /// Tries to transpose a note by a specific internval
    /// </summary>
    /// <param name="interval">Interval to trasnpose by</param>
    /// <param name="note">Transposed note</param>
    /// <returns><see langword="true"/> if transposed succesfully</returns>
    public bool TryTranspose(Interval interval, out Note? note)
    {
        var transposedPitch = _pitch + interval.Distance;

        var noteExists = TryFindByPitch(transposedPitch, out var found);

        if (!noteExists)
        {
            note = null;
            return false;
        }

        note = found;
        return true;
    }

    private static bool TryFindByPitch(int pitch, out Note? note)
    {
        var found = AllNotes.FirstOrDefault(a => a._pitch == pitch);

        if (found is null)
        {
            note = null;
            return false;
        }

        note = found;
        return true;
    }

    private static Note FindByPitch(int pitch)
    {
        var success = TryFindByPitch(pitch, out var note);

        if (!success)
        {
            throw new ArgumentOutOfRangeException(nameof(pitch), pitch, "Note with this pitch was not found");
        }

        return note!;
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

    public override string ToString()
    {
        return $"{BasePitch}{(int)Octave}";
    }
}
