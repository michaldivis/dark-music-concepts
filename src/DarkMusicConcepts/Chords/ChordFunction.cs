namespace DarkMusicConcepts.Chords;

public class ChordFunction
{
    public string Name { get; }
    public IReadOnlyList<Interval> Intervals { get; }

    internal ChordFunction(string name, params Interval[] intervals)
    {
        Name = name;
        Intervals = intervals;
    }

    public static ChordFunction FunctionForInterval(Interval interval)
    {
        return ChordFunctions.All.First(f => f.Intervals.Contains(interval));
    }
}