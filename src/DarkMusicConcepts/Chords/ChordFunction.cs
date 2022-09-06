namespace DarkMusicConcepts.Chords;

public class ChordFunction
{
    public static readonly ChordFunction Major = new("Maj", Interval.MajorThird, Interval.PerfectFifth);
    public static readonly ChordFunction Augmented = new("Aug", Interval.MajorThird, Interval.AugmentedFifth);
    public static readonly ChordFunction Minor = new("Min", Interval.MinorThird, Interval.PerfectFifth);
    public static readonly ChordFunction Diminished = new("Dim", Interval.MinorThird, Interval.DiminishedFifth);
    public static readonly ChordFunction Sus2 = new("Sus2", Interval.MajorSecond, Interval.PerfectFifth);
    public static readonly ChordFunction Sus2Diminished = new("Sus2Dim", Interval.MajorSecond, Interval.DiminishedFifth);
    public static readonly ChordFunction Sus2Augmented = new("Sus2Aug", Interval.MajorSecond, Interval.AugmentedFifth);
    public static readonly ChordFunction Sus4 = new("Sus4", Interval.PerfectForth, Interval.PerfectFifth);
    public static readonly ChordFunction Sus4Diminished = new("Sus4Dim", Interval.PerfectForth, Interval.DiminishedFifth);
    public static readonly ChordFunction Sus4Augmented = new("Sus4Aug", Interval.PerfectForth, Interval.AugmentedFifth);
    public static readonly ChordFunction Major7 = new("Maj7", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh);
    public static readonly ChordFunction Dominant7 = new("Dom7", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh);
    public static readonly ChordFunction Minor7b5 = new("Min7b5", Interval.MinorThird, Interval.DiminishedFifth, Interval.MinorSeventh);
    public static readonly ChordFunction Diminished7 = new("Dim7", Interval.MinorThird, Interval.DiminishedFifth, Interval.MajorSixth);
    public static readonly ChordFunction Minor7 = new("Min7", Interval.MinorThird, Interval.PerfectFifth, Interval.MinorSeventh);
    public static readonly ChordFunction MinorMaj7 = new("MinMaj7", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSeventh);
    public static readonly ChordFunction Augmented7 = new("Aug7", Interval.MajorThird, Interval.AugmentedFifth, Interval.MajorSeventh);

    private ChordFunction(string abreviatedName, params Interval[] intervals)
    {
        AbreviatedName = abreviatedName;
        Intervals = intervals;
    }

    public string AbreviatedName { get; }

    public IEnumerable<Interval> Intervals { get; }

    public static ChordFunction FunctionForIntervals(IEnumerable<Interval> intervals)
    {
        return Functions.First(f => f.Intervals.SequenceEqual(intervals));
    }

    private static IEnumerable<ChordFunction> Functions { get; } = new[]
    {
        Major,
        Augmented,
        Minor,
        Diminished,
        Sus2,
        Sus2Diminished,
        Sus2Augmented,
        Sus4,
        Sus4Diminished,
        Sus4Augmented,
        Major7,
        Dominant7,
        Minor7b5,
        Diminished7,
        Minor7,
        MinorMaj7,
        Augmented7
    };
}