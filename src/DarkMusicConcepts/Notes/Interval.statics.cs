namespace DarkMusicConcepts.Notes;
public partial class Interval
{
    public static readonly Interval Unisson = new(0, "Unisson", Accident.None);
    public static readonly Interval MinorSecond = new(1, "Minor second", Accident.Flat);
    public static readonly Interval MajorSecond = new(2, "Major second", Accident.None);
    public static readonly Interval AugmentedSecond = new(3, "Augmented second", Accident.Sharp);
    public static readonly Interval MinorThird = new(3, "Minor third", Accident.Flat);
    public static readonly Interval MajorThird = new(4, "Major third", Accident.None);
    public static readonly Interval PerfectFourth = new(5, "Perfect fourth", Accident.None);
    public static readonly Interval AugmentedFourth = new(6, "Augmented fourth", Accident.Sharp);
    public static readonly Interval DiminishedFifth = new(6, "Diminished fifth", Accident.Flat);
    public static readonly Interval PerfectFifth = new(7, "Perfect fifth", Accident.None);
    public static readonly Interval AugmentedFifth = new(8, "Augmented fifth", Accident.Sharp);
    public static readonly Interval MinorSixth = new(8, "Minor sixth", Accident.Flat);
    public static readonly Interval MajorSixth = new(9, "Major sixth", Accident.None);
    public static readonly Interval MinorSeventh = new(10, "Minor seventh", Accident.Flat);
    public static readonly Interval MajorSeventh = new(11, "Major seventh", Accident.Sharp);
    public static readonly Interval PerfectOctave = new(12, "Perfect octave", Accident.None);

    public static IEnumerable<Interval> AllIntervals { get; } = new[]
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
        PerfectOctave
    };

    private static IEnumerable<Interval> UniqueIntervals { get; } = new[]
    {
        Unisson,
        MinorSecond,
        MajorSecond,
        MinorThird,
        MajorThird,
        PerfectFourth,
        DiminishedFifth,
        PerfectFifth,
        AugmentedFifth,
        MajorSixth,
        MinorSeventh,
        MajorSeventh,
        PerfectOctave
    };
}
