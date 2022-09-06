namespace DarkMusicConcepts.Chords;

public class Function
{
    public static readonly Function Root = new("R", Interval.Unisson);
    public static readonly Function Third = new("3", Interval.MajorThird, Interval.MinorThird);
    public static readonly Function Fifth = new("5", Interval.PerfectFifth, Interval.AugmentedFifth, Interval.DiminishedFifth);
    public static readonly Function Seventh = new("7", Interval.MinorSeventh, Interval.MajorSeventh);
    public static readonly Function Ninth = new("9", Interval.MinorSecond, Interval.MajorSecond);
    public static readonly Function Eleventh = new("11", Interval.PerfectForth);
    public static readonly Function Thirteenth = new("13", Interval.MajorSixth);

    private readonly IList<Interval> _distanceFromRoot;

    public string Name { get; }

    private Function(string name, params Interval[] distanceFromRoot)
    {
        Name = name;
        _distanceFromRoot = distanceFromRoot;
    }

    public static IEnumerable<Function> Functions { get; } = new[]
    {
        Root,
        Third,
        Fifth,
        Seventh,
        Ninth,
        Eleventh,
        Thirteenth
    };

    public static Function FunctionForInterval(Interval interval)
    {
        return Functions.First(f => f._distanceFromRoot.Contains(interval));
    }
}
