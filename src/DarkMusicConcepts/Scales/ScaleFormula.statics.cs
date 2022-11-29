namespace DarkMusicConcepts.Scales;
public partial class ScaleFormula
{
    public static ScaleFormula Ionian { get; } = new("Ionian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static ScaleFormula Dorian { get; } = new("Dorian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula Phrygian { get; } = new("Phrygian",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula Lydian { get; } = new("Lydian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.AugmentedFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static ScaleFormula Mixolydian { get; } = new("Mixolydian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula Aolian { get; } = new("Aolian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula Locrian { get; } = new("Locrian",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.DiminishedFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula MajorPentatonic { get; } = new("Major pentatonic",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFifth,
        Interval.MajorSixth
    );

    public static ScaleFormula MinorPentatonic { get; } = new("Minor pentatonic",
        Interval.Unisson,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSeventh
    );

    public static ScaleFormula Blues { get; } = new("Blues",
        Interval.Unisson,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.DiminishedFifth,
        Interval.PerfectFifth,
        Interval.MinorSeventh
    );

    public static ScaleFormula HarmonicMinor { get; } = new("Harmonic minor",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MajorSeventh
    );

    public static ScaleFormula DoubleHarmonicMinor { get; } = new("Double Harmonic minor",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MajorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MajorSeventh
    );

    public static ScaleFormula MelodicMinor { get; } = new("Melodic minor",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static ScaleFormula Dorianb2 { get; } = new("Dorian b2",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula LydianAugmented { get; } = new("Lydian augmented",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.AugmentedFourth,
        Interval.AugmentedFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static ScaleFormula LydianDominant { get; } = new("Lydian dominant",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.AugmentedFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula PhrygianDominant { get; } = new("Phrygian dominant",
       Interval.Unisson,
       Interval.MinorSecond,
       Interval.MajorThird,
       Interval.PerfectFourth,
       Interval.PerfectFifth,
       Interval.MinorSixth,
       Interval.MinorSeventh
   );

    public static ScaleFormula Mixolydianb6 { get; } = new("Mixolydian b6",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula LocrianSharp2 { get; } = new("Locrian #2",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.DiminishedFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula AlteredDominant { get; } = new("Altered dominant",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.AugmentedSecond,
        Interval.MajorThird,
        Interval.DiminishedFifth,
        Interval.AugmentedFifth,
        Interval.MinorSeventh
    );

    public static ScaleFormula HalfWholeDiminished { get; } = new("Half whole diminished",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.MajorThird,
        Interval.AugmentedFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static ScaleFormula WholeTone { get; } = new("Whole tone",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.DiminishedFifth,
        Interval.AugmentedFifth,
        Interval.MinorSeventh
    );

    public static IReadOnlyList<ScaleFormula> AllScaleFormulas { get; } = new[]
    {
        Ionian,
        Dorian,
        Phrygian,
        Lydian,
        Mixolydian,
        Aolian,
        Locrian,
        MajorPentatonic,
        MinorPentatonic,
        Blues,
        HarmonicMinor,
        DoubleHarmonicMinor,
        MelodicMinor,
        Dorianb2,
        LydianAugmented,
        LydianDominant,
        PhrygianDominant,
        Mixolydianb6,
        LocrianSharp2,
        AlteredDominant,
        HalfWholeDiminished,
        WholeTone
    };
}
