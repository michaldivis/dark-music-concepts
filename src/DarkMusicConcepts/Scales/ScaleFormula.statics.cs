namespace DarkMusicConcepts.Scales;
public partial class ScaleFormula
{
    public static readonly ScaleFormula Ionian = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula Dorian = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Phrygian = new(
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Lydian = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.AugmentedForth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula Mixolydian = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Aolian = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Locrian = new(
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.DiminishedFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula MajorPentatonic = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFifth,
        Interval.MajorSixth
    );

    public static readonly ScaleFormula MinorPentatonic = new(
        Interval.Unisson,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Blues = new(
        Interval.Unisson,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.DiminishedFifth,
        Interval.PerfectFifth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula HarmonicMinor = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula MelodicMinor = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula Dorianb2 = new(
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula LydianAugmented = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.AugmentedForth,
        Interval.AugmentedFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula LydianDominant = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.AugmentedForth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula PhrygianDominant = new(
       Interval.Unisson,
       Interval.MinorSecond,
       Interval.MajorThird,
       Interval.PerfectForth,
       Interval.PerfectFifth,
       Interval.MinorSixth,
       Interval.MinorSeventh
   );

    public static readonly ScaleFormula Mixolydianb6 = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectForth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula LocrianSharp2 = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectForth,
        Interval.DiminishedFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula AlteredDominant = new(
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.AugmentedSecond,
        Interval.MajorThird,
        Interval.DiminishedFifth,
        Interval.AugmentedFifth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula HalfWholeDiminished = new(
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.MajorThird,
        Interval.AugmentedForth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula WholeTone = new(
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.DiminishedFifth,
        Interval.AugmentedFifth,
        Interval.MinorSeventh
    );

    public static IEnumerable<ScaleFormula> AllScaleFormulas { get; } = new[]
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
