namespace DarkMusicConcepts.Notes;
public partial class Interval
{
    public static Interval Unisson { get; } = new(0, "Unisson", Accident.None);

    public static Interval MinorSecond { get; } = new(1, "Minor 2nd", Accident.Flat);
    public static Interval MajorSecond { get; } = new(2, "Major 2nd", Accident.None);
    public static Interval AugmentedSecond { get; } = new(3, "Augmented 2nd", Accident.Sharp);

    public static Interval MinorThird { get; } = new(3, "Minor 3rd", Accident.Flat);
    public static Interval MajorThird { get; } = new(4, "Major 3rd", Accident.None);

    public static Interval PerfectFourth { get; } = new(5, "Perfect 4th", Accident.None);
    public static Interval AugmentedFourth { get; } = new(6, "Augmented 4th", Accident.Sharp);

    public static Interval DiminishedFifth { get; } = new(6, "Diminished 5th", Accident.Flat);
    public static Interval PerfectFifth { get; } = new(7, "Perfect 5th", Accident.None);
    public static Interval AugmentedFifth { get; } = new(8, "Augmented 5th", Accident.Sharp);

    public static Interval MinorSixth { get; } = new(8, "Minor 6th", Accident.Flat);
    public static Interval MajorSixth { get; } = new(9, "Major 6th", Accident.None);

    public static Interval MinorSeventh { get; } = new(10, "Minor 7th", Accident.Flat);
    public static Interval MajorSeventh { get; } = new(11, "Major 7th", Accident.Sharp);

    public static Interval PerfectOctave { get; } = new(12, "Perfect octave", Accident.None);

    public static Interval MinorNinth { get; } = new(13, "Minor 9th", Accident.Flat);
    public static Interval MajorNinth { get; } = new(14, "Major 9th", Accident.None);
    public static Interval AugmentedNinth { get; } = new(15, "Augmented 9th", Accident.Sharp);

    public static Interval DiminishedEleventh { get; } = new(16, "Diminished 11th", Accident.Flat);
    public static Interval PerfectEleventh { get; } = new(17, "Perfect 11th", Accident.None);
    public static Interval AugmentedEleventh { get; } = new(18, "Augmented 11th", Accident.Sharp);

    public static Interval MinorThirteenth { get; } = new(20, "Minor 13th", Accident.Flat);
    public static Interval MajorThirteenth { get; } = new(21, "Major 13th", Accident.None);
    public static Interval AugmentedThirteenth { get; } = new(22, "Augmented 13th", Accident.Sharp);

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
