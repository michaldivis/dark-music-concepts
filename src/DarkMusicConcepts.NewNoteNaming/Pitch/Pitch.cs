using DarkMusicConcepts.NewNoteNaming.Extensions;

namespace DarkMusicConcepts.NewNoteNaming.Pitch;

public class Pitch : IComparable<Pitch>, IComparable
{
    public Pitch(Step step, int alter, int octave)
    {
        Step = step;
        Octave = octave;
        Alter = alter;
    }

    public Step Step { get; set; }
    public int Octave { get; set; }
    public int Alter { get; set; } // Number of semitones up (+) or down (-)

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return 1;
        if (ReferenceEquals(this, obj))
            return 0;
        return obj is Pitch other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Pitch)}");
    }

    public int CompareTo(Pitch? other)
    {
        if (other is null)
            throw new ArgumentNullException(nameof(other));

        var thisMidiNote = this.CalculateMidiNote();
        var otherMidiNote = other.CalculateMidiNote();

        return thisMidiNote.CompareTo(otherMidiNote);
    }

    public override string ToString()
    {
        return $"{Step}{AlterToString(Alter)}";
    }

    private static string AlterToString(int alter)
    {
        return alter switch
        {
            2 => "##",
            1 => "#",
            0 => string.Empty,
            -1 => "b",
            -2 => "bb",
            _ => throw new ArgumentOutOfRangeException()
        };
    }


    public static bool operator <(Pitch? left, Pitch? right)
    {
        return Comparer<Pitch>.Default.Compare(left, right) < 0;
    }

    public static bool operator >(Pitch? left, Pitch? right)
    {
        return Comparer<Pitch>.Default.Compare(left, right) > 0;
    }

    public static bool operator <=(Pitch? left, Pitch? right)
    {
        return Comparer<Pitch>.Default.Compare(left, right) <= 0;
    }

    public static bool operator >=(Pitch? left, Pitch? right)
    {
        return Comparer<Pitch>.Default.Compare(left, right) >= 0;
    }
}
