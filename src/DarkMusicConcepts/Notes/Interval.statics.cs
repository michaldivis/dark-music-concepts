namespace DarkMusicConcepts.Notes;
public partial class Interval
{
    public static Interval Unisson { get; } = new(0, "Unisson", Accident.None);

    public static Interval MinorSecond { get; } = new(1, "Minor second", Accident.Flat);
    public static Interval MajorSecond { get; } = new(2, "Major second", Accident.None);
    public static Interval AugmentedSecond { get; } = new(3, "Augmented second", Accident.Sharp);

    public static Interval MinorThird { get; } = new(3, "Minor third", Accident.Flat);
    public static Interval MajorThird { get; } = new(4, "Major third", Accident.None);

    public static Interval PerfectFourth { get; } = new(5, "Perfect fourth", Accident.None);
    public static Interval AugmentedFourth { get; } = new(6, "Augmented fourth", Accident.Sharp);

    public static Interval DiminishedFifth { get; } = new(6, "Diminished fifth", Accident.Flat);
    public static Interval PerfectFifth { get; } = new(7, "Perfect fifth", Accident.None);
    public static Interval AugmentedFifth { get; } = new(8, "Augmented fifth", Accident.Sharp);

    public static Interval MinorSixth { get; } = new(8, "Minor sixth", Accident.Flat);
    public static Interval MajorSixth { get; } = new(9, "Major sixth", Accident.None);

    public static Interval MinorSeventh { get; } = new(10, "Minor seventh", Accident.Flat);
    public static Interval MajorSeventh { get; } = new(11, "Major seventh", Accident.Sharp);

    public static Interval PerfectOctave { get; } = new(12, "Perfect octave", Accident.None);

    public static Interval MinorNinth { get; } = new(13, "xxx", Accident.Flat);
    public static Interval MajorNinth { get; } = new(14, "xxx", Accident.None);
    public static Interval AugmentedNinth { get; } = new(15, "xxx", Accident.Sharp);

    public static Interval DiminishedEleventh { get; } = new(17, "xxx", Accident.Flat);
    public static Interval PerfectEleventh { get; } = new(17, "xxx", Accident.None);
    public static Interval AugmentedEleventh { get; } = new(17, "xxx", Accident.Sharp);

    public static Interval MinorThirteenth { get; } = new(20, "xxx", Accident.Flat);
    public static Interval MajorThirteenth { get; } = new(21, "xxx", Accident.None);
    public static Interval AugmentedThirteenth { get; } = new(22, "xxx", Accident.Sharp);

    public static IReadOnlyList<Interval> AllIntervals { get; } = new[]
    {
        Unisson,
        MinorSecond,
        MajorSecond,
        AugmentedSecond,
        MinorThird,
        MajorThird,
        PerfectFourth,
        AugmentedFourth,
        DiminishedFifth,
        PerfectFifth,
        AugmentedFifth,
        MinorSixth,
        MajorSixth,
        MinorSeventh,
        MajorSeventh,
        PerfectOctave,
        MinorNinth,
        MajorNinth,
        AugmentedNinth,
        DiminishedEleventh,
        PerfectEleventh,
        AugmentedEleventh,
        MinorThirteenth,
        MajorThirteenth,
        AugmentedThirteenth
    };
}
