namespace DarkMusicConcepts.Notes;

/// <summary>
/// In music theory, an interval is a difference in pitch between two sounds. An interval may be described as horizontal, linear, or melodic if it refers to successively sounding tones, such as two adjacent pitches in a melody, and vertical or harmonic if it pertains to simultaneously sounding tones, such as in a chord.
/// </summary>
public partial class Interval : IEquatable<Interval>, IComparable<Interval>
{
    public int Distance { get; }

    public string Name { get; }

    public Accident Accident { get; }

    private Interval(int distance, string name, Accident accident)
    {
        Distance = distance;
        Name = name;
        Accident = accident;
    }

    public static Interval CreateIntervalFromDistance(int distance)
    {
        var safeDistance = GetDistanceWithinOneOctave(distance);
        return UniqueIntervals.Single(interval => interval.Distance == safeDistance);
    }

    private static int GetDistanceWithinOneOctave(int distance)
    {
        var safeDistance = Math.Abs(distance % 12);
        return safeDistance;
    }

    #region Equality

    private static bool EqualsInternal(Interval? a, Interval? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Distance.Equals(b.Distance);
    }

    public bool Equals(Interval? other)
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

        if (obj is not Interval other)
        {
            return false;
        }

        return EqualsInternal(this, other);
    }

    public static bool operator ==(Interval? a, Interval? b)
    {
        return EqualsInternal(a, b);
    }

    public static bool operator !=(Interval? a, Interval? b)
    {
        return !EqualsInternal(a, b);
    }

    #endregion

    #region Comparison

    private static int CompareToInteral(Interval? a, Interval? b)
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

        return a.Distance.CompareTo(b.Distance);
    }

    public int CompareTo(Interval? other)
    {
        return CompareToInteral(this, other);
    }

    public static bool operator >(Interval? a, Interval? b)
    {
        return CompareToInteral(a, b) > 0;
    }

    public static bool operator <(Interval? a, Interval? b)
    {
        return CompareToInteral(a, b) < 0;
    }

    public static bool operator >=(Interval? a, Interval? b)
    {
        return CompareToInteral(a, b) >= 0;
    }

    public static bool operator <=(Interval? a, Interval? b)
    {
        return CompareToInteral(a, b) <= 0;
    }

    #endregion

    public override int GetHashCode()
    {
        return Distance.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }
}