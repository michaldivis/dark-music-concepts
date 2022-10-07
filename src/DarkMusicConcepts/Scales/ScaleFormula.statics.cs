namespace DarkMusicConcepts.Scales;
public partial class ScaleFormula
{
    public static readonly ScaleFormula Ionian = new("Ionian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula Dorian = new("Dorian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Phrygian = new("Phrygian",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Lydian = new("Lydian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.AugmentedFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula Mixolydian = new("Mixolydian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Aolian = new("Aolian",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Locrian = new("Locrian",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.DiminishedFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula MajorPentatonic = new("Major pentatonic",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFifth,
        Interval.MajorSixth
    );

    public static readonly ScaleFormula MinorPentatonic = new("Minor pentatonic",
        Interval.Unisson,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula Blues = new("Blues",
        Interval.Unisson,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.DiminishedFifth,
        Interval.PerfectFifth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula HarmonicMinor = new("Harmonic minor",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula DoubleHarmonicMinor = new("Double Harmonic minor",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MajorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula MelodicMinor = new("Melodic minor",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula Dorianb2 = new("Dorian b2",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula LydianAugmented = new("Lydian augmented",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.AugmentedFourth,
        Interval.AugmentedFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh
    );

    public static readonly ScaleFormula LydianDominant = new("Lydian dominant",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.AugmentedFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula PhrygianDominant = new("Phrygian dominant",
       Interval.Unisson,
       Interval.MinorSecond,
       Interval.MajorThird,
       Interval.PerfectFourth,
       Interval.PerfectFifth,
       Interval.MinorSixth,
       Interval.MinorSeventh
   );

    public static readonly ScaleFormula Mixolydianb6 = new("Mixolydian b6",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula LocrianSharp2 = new("Locrian #2",
        Interval.Unisson,
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.DiminishedFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula AlteredDominant = new("Altered dominant",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.AugmentedSecond,
        Interval.MajorThird,
        Interval.DiminishedFifth,
        Interval.AugmentedFifth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula HalfWholeDiminished = new("Half whole diminished",
        Interval.Unisson,
        Interval.MinorSecond,
        Interval.MinorThird,
        Interval.MajorThird,
        Interval.AugmentedFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MinorSeventh
    );

    public static readonly ScaleFormula WholeTone = new("Whole tone",
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
