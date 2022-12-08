namespace DarkMusicConcepts.Notes;

/// <summary>
/// In music, a note is a symbol denoting a musical sound. In English usage, a note is also the sound itself. Notes can represent the pitch and duration of a sound in musical notation. A note can also represent a pitch class.
/// </summary>
public class Note : IEquatable<Note>, IComparable<Note>
{
    private const int MidiMiddleCNumber = 60;
    private const double A4Frequency = 440.0;
    private const int OctaveRange = 12;

    /// <summary>
    /// Internal representation of Note's absolute pitch. Is always valid unlike <see cref="MidiNumber"/> which can be <see langword="null"/>
    /// </summary>
    public int AbsolutePitch { get; }
    public Pitch BasePitch { get; }
    public Octave Octave { get; }

    private Note(Pitch basePitch, Octave octave)
    {
        BasePitch = basePitch;
        Octave = octave;

        AbsolutePitch = GetAbsolutePitch(basePitch, octave);
        Name = GetName(basePitch, octave);
        Frequency = GetFrequency(AbsolutePitch);
        MidiNumber = GetMidiNumber(AbsolutePitch);
    }

    public static Note Create(Pitch basePitch, Octave octave)
    {
        return new Note(basePitch, octave);
    }

    public string Name { get; }

    public Frequency Frequency { get; }

    public MidiNumber? MidiNumber { get; }

    private static string GetName(Pitch basePitch, Octave octave)
    {
        return $"{basePitch}{(int)octave}"
            .Replace("Or", "/")
            .Replace("Sharp", "#")
            .Replace("Flat", "b");
    }

    private static int GetAbsolutePitch(Pitch basePitch, Octave octave)
    {
        return (int)basePitch + OctaveRange * ((int)octave + 1);
    }

    private static Frequency GetFrequency(int absolutePitch)
    {
        var a4AbsolutePitch = GetAbsolutePitch(Pitch.A, Octave.Four);
        var relativePitchToA4 = absolutePitch - a4AbsolutePitch;
        var power = (double)relativePitchToA4 / OctaveRange;
        var frequency = Math.Pow(2.0, power) * A4Frequency;
        return Frequency.From(frequency);
    }

    private static MidiNumber? GetMidiNumber(int absolutePitch)
    {
        var middleCPitch = GetAbsolutePitch(Pitch.C, DarkMusicConceptsCore.MidiMiddleCOctave);
        var relativePitchToMiddleC = absolutePitch - middleCPitch;
        var midiNumber = MidiMiddleCNumber + relativePitchToMiddleC;

        if (midiNumber < MidiNumber.MinValue)
        {
            return null;
        }

        if (midiNumber > MidiNumber.MaxValue)
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
        var found = Notes.All.FirstOrDefault(a => a.MidiNumber == midiNumber);

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
        var found = Notes.All.FirstOrDefault(a => a.Frequency.EqualsWithPrecision(frequency, precision));

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
    /// Transpose a note up by a specific internval
    /// </summary>
    /// <param name="interval">Interval to trasnpose by</param>
    /// <returns>Transposed note</returns>
    /// <exception cref="ArgumentException"></exception>
    public Note TransposeUp(Interval interval)
    {
        var success = TryTransposeUp(interval, out var note);

        if (!success)
        {
            throw new ArgumentException("Interval transposes the note out of possible range", nameof(interval));
        }

        return note!;
    }

    /// <summary>
    /// Tries to transpose a note up by a specific internval
    /// </summary>
    /// <param name="interval">Interval to trasnpose by</param>
    /// <param name="note">Transposed note</param>
    /// <returns><see langword="true"/> if transposed succesfully</returns>
    public bool TryTransposeUp(Interval interval, out Note? note)
    {
        return TryTranspose(interval.Distance, out note);
    }

    /// <summary>
    /// Transpose a note down by a specific internval
    /// </summary>
    /// <param name="interval">Interval to trasnpose by</param>
    /// <returns>Transposed note</returns>
    /// <exception cref="ArgumentException"></exception>
    public Note TransposeDown(Interval interval)
    {
        var success = TryTransposeDown(interval, out var note);

        if (!success)
        {
            throw new ArgumentException("Interval transposes the note out of possible range", nameof(interval));
        }

        return note!;
    }

    /// <summary>
    /// Tries to transpose a note down by a specific internval
    /// </summary>
    /// <param name="interval">Interval to trasnpose by</param>
    /// <param name="note">Transposed note</param>
    /// <returns><see langword="true"/> if transposed succesfully</returns>
    public bool TryTransposeDown(Interval interval, out Note? note)
    {
        return TryTranspose(-interval.Distance, out note);
    }

    private bool TryTranspose(int distance, out Note? note)
    {
        var transposedPitch = AbsolutePitch + distance;

        var noteExists = TryFindByAbsolutePitch(transposedPitch, out var found);

        if (!noteExists)
        {
            note = null;
            return false;
        }

        note = found;
        return true;
    }

    private static bool TryFindByAbsolutePitch(int pitch, out Note? note)
    {
        var found = Notes.All.FirstOrDefault(a => a.AbsolutePitch == pitch);

        if (found is null)
        {
            note = null;
            return false;
        }

        note = found;
        return true;
    }

    private static Note FindByAbsolutePitch(int absolutePitch)
    {
        var success = TryFindByAbsolutePitch(absolutePitch, out var note);

        if (!success)
        {
            throw new ArgumentOutOfRangeException(nameof(absolutePitch), absolutePitch, "Note with this pitch was not found");
        }

        return note!;
    }

    public Interval IntervalWithOther(Note note)
    {
        var distance = Math.Abs(AbsolutePitch - note.AbsolutePitch);
        var interval = Interval.CreateIntervalFromDistance(distance);
        return interval;
    }

    #region Equality

    private static bool EqualsInternal(Note? a, Note? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.AbsolutePitch.Equals(b.AbsolutePitch);
    }

    public bool Equals(Note? other)
    {
        if (other is null)
        {
            return false;
        }

        return EqualsInternal(this, other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is not Note other)
        {
            return false;
        }

        return EqualsInternal(this, other);
    }

    public static bool operator ==(Note? a, Note? b)
    {
        return EqualsInternal(a, b);
    }

    public static bool operator !=(Note? a, Note? b)
    {
        return !EqualsInternal(a, b);
    }

    #endregion

    #region Comparison

    private static int CompareToInteral(Note? a, Note? b)
    {
        if (a is null && b is null)
        {
            return 0;
        }

        if (a is null)
        {
            return -1;
        }

        if (b is null)
        {
            return 1;
        }

        return a.AbsolutePitch.CompareTo(b.AbsolutePitch);
    }

    public int CompareTo(Note? other)
    {
        return CompareToInteral(this, other);
    }

    public static bool operator >(Note? a, Note? b)
    {
        return CompareToInteral(a, b) > 0;
    }

    public static bool operator <(Note? a, Note? b)
    {
        return CompareToInteral(a, b) < 0;
    }

    public static bool operator >=(Note? a, Note? b)
    {
        return CompareToInteral(a, b) >= 0;
    }

    public static bool operator <=(Note? a, Note? b)
    {
        return CompareToInteral(a, b) <= 0;
    }

    #endregion

    public override int GetHashCode()
    {
        return AbsolutePitch.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }
}
