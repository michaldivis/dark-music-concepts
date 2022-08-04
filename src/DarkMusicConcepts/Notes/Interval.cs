namespace DarkMusicConcepts.Notes;

/// <summary>
/// In music theory, an interval is a difference in pitch between two sounds. An interval may be described as horizontal, linear, or melodic if it refers to successively sounding tones, such as two adjacent pitches in a melody, and vertical or harmonic if it pertains to simultaneously sounding tones, such as in a chord.
/// </summary>
public partial class Interval : IComparable<Interval>
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
        return UniqueIntervals.Single(interval => interval.Distance == distance);
    }

    public static Interval operator -(Interval intervalA, Interval intervalB)
    {
        var difference = Math.Abs(intervalA.Distance - intervalB.Distance);
        return UniqueIntervals.Single(interval => interval.Distance == difference);
    }

    public static bool operator >(Interval intervalA, Interval intervalB)
    {
        return intervalA.Distance > intervalB.Distance;
    }

    public static bool operator <(Interval intervalA, Interval intervalB)
    {
        return intervalA.Distance < intervalB.Distance;
    }

    public static bool operator >(Interval intervalA, int distance)
    {
        return intervalA.Distance > distance;
    }

    public static bool operator <(Interval intervalA, int distance)
    {
        return intervalA.Distance < distance;
    }

    public int CompareTo(Interval? other)
    {
        return Distance.CompareTo(other?.Distance);
    }

    public override string ToString()
    {
        return Name;
    }
}