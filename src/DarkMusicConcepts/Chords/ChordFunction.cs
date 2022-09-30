namespace DarkMusicConcepts.Chords;

public class ChordFunction
{
    public static readonly ChordFunction Root = new("R", Interval.Unisson);
    public static readonly ChordFunction Third = new("3", Interval.MajorThird, Interval.MinorThird);
    public static readonly ChordFunction Fifth = new("5", Interval.PerfectFifth, Interval.AugmentedFifth, Interval.DiminishedFifth);
    public static readonly ChordFunction Seventh = new("7", Interval.MinorSeventh, Interval.MajorSeventh);
    public static readonly ChordFunction Ninth = new("9", Interval.MinorSecond, Interval.MajorSecond);
    public static readonly ChordFunction Eleventh = new("11", Interval.PerfectForth);
    public static readonly ChordFunction Thirteenth = new("13", Interval.MajorSixth);

    private readonly IList<Interval> _distanceFromRoot;

    public string Name { get; }

    private ChordFunction(string name, params Interval[] distanceFromRoot)
    {
        Name = name;
        _distanceFromRoot = distanceFromRoot;
    }

    public static IEnumerable<ChordFunction> Functions { get; } = new[]
    {
        Root,
        Third,
        Fifth,
        Seventh,
        Ninth,
        Eleventh,
        Thirteenth
    };

    public static ChordFunction FunctionForInterval(Interval interval)
    {
        return Functions.First(f => f._distanceFromRoot.Contains(interval));
    }
}
