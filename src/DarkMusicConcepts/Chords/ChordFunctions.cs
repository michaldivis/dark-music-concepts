namespace DarkMusicConcepts.Chords;

public static class ChordFunctions
{
    public static ChordFunction Root { get; } = new("R", Intervals.Unisson);
    public static ChordFunction Second { get; } = new("2", Intervals.MinorSecond, Intervals.MajorSecond, Intervals.AugmentedSecond);
    public static ChordFunction Third { get; } = new("3", Intervals.MinorThird, Intervals.MajorThird);
    public static ChordFunction Fourth { get; } = new("4", Intervals.PerfectFourth, Intervals.AugmentedFourth);
    public static ChordFunction Fifth { get; } = new("5", Intervals.PerfectFifth, Intervals.AugmentedFifth, Intervals.DiminishedFifth);
    public static ChordFunction Sixth { get; } = new("6", Intervals.MinorSixth, Intervals.MajorSixth);
    public static ChordFunction Seventh { get; } = new("7", Intervals.MinorSeventh, Intervals.MajorSeventh);
    public static ChordFunction Ninth { get; } = new("9", Intervals.MinorNinth, Intervals.MajorNinth, Intervals.AugmentedNinth);
    public static ChordFunction Eleventh { get; } = new("11", Intervals.PerfectEleventh, Intervals.AugmentedEleventh, Intervals.DiminishedEleventh);
    public static ChordFunction Thirteenth { get; } = new("13", Intervals.MinorThirteenth, Intervals.MajorThirteenth, Intervals.AugmentedThirteenth);

    public static IReadOnlyList<ChordFunction> All { get; } = new[]
    {
        Root,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Ninth,
        Eleventh,
        Thirteenth
    };
}
