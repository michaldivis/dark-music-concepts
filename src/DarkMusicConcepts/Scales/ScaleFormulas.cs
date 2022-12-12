namespace DarkMusicConcepts;
public static class ScaleFormulas
{
    public static ScaleFormula Ionian { get; } = new("Ionian",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MajorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MajorSixth,
        Intervals.MajorSeventh
    );

    public static ScaleFormula Dorian { get; } = new("Dorian",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MajorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula Phrygian { get; } = new("Phrygian",
        Intervals.Unisson,
        Intervals.MinorSecond,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MinorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula Lydian { get; } = new("Lydian",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MajorThird,
        Intervals.AugmentedFourth,
        Intervals.PerfectFifth,
        Intervals.MajorSixth,
        Intervals.MajorSeventh
    );

    public static ScaleFormula Mixolydian { get; } = new("Mixolydian",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MajorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MajorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula Aolian { get; } = new("Aolian",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MinorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula Locrian { get; } = new("Locrian",
        Intervals.Unisson,
        Intervals.MinorSecond,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.DiminishedFifth,
        Intervals.MinorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula MajorPentatonic { get; } = new("Major pentatonic",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MajorThird,
        Intervals.PerfectFifth,
        Intervals.MajorSixth
    );

    public static ScaleFormula MinorPentatonic { get; } = new("Minor pentatonic",
        Intervals.Unisson,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula Blues { get; } = new("Blues",
        Intervals.Unisson,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.DiminishedFifth,
        Intervals.PerfectFifth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula HarmonicMinor { get; } = new("Harmonic minor",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MinorSixth,
        Intervals.MajorSeventh
    );

    public static ScaleFormula DoubleHarmonicMinor { get; } = new("Double Harmonic minor",
        Intervals.Unisson,
        Intervals.MinorSecond,
        Intervals.MajorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MinorSixth,
        Intervals.MajorSeventh
    );

    public static ScaleFormula MelodicMinor { get; } = new("Melodic minor",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MajorSixth,
        Intervals.MajorSeventh
    );

    public static ScaleFormula Dorianb2 { get; } = new("Dorian b2",
        Intervals.Unisson,
        Intervals.MinorSecond,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MajorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula LydianAugmented { get; } = new("Lydian augmented",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MajorThird,
        Intervals.AugmentedFourth,
        Intervals.AugmentedFifth,
        Intervals.MajorSixth,
        Intervals.MajorSeventh
    );

    public static ScaleFormula LydianDominant { get; } = new("Lydian dominant",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MajorThird,
        Intervals.AugmentedFourth,
        Intervals.PerfectFifth,
        Intervals.MajorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula PhrygianDominant { get; } = new("Phrygian dominant",
       Intervals.Unisson,
       Intervals.MinorSecond,
       Intervals.MajorThird,
       Intervals.PerfectFourth,
       Intervals.PerfectFifth,
       Intervals.MinorSixth,
       Intervals.MinorSeventh
   );

    public static ScaleFormula Mixolydianb6 { get; } = new("Mixolydian b6",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MajorThird,
        Intervals.PerfectFourth,
        Intervals.PerfectFifth,
        Intervals.MinorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula LocrianSharp2 { get; } = new("Locrian #2",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MinorThird,
        Intervals.PerfectFourth,
        Intervals.DiminishedFifth,
        Intervals.MinorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula AlteredDominant { get; } = new("Altered dominant",
        Intervals.Unisson,
        Intervals.MinorSecond,
        Intervals.AugmentedSecond,
        Intervals.MajorThird,
        Intervals.DiminishedFifth,
        Intervals.AugmentedFifth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula HalfWholeDiminished { get; } = new("Half whole diminished",
        Intervals.Unisson,
        Intervals.MinorSecond,
        Intervals.MinorThird,
        Intervals.MajorThird,
        Intervals.AugmentedFourth,
        Intervals.PerfectFifth,
        Intervals.MajorSixth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula WholeTone { get; } = new("Whole tone",
        Intervals.Unisson,
        Intervals.MajorSecond,
        Intervals.MajorThird,
        Intervals.DiminishedFifth,
        Intervals.AugmentedFifth,
        Intervals.MinorSeventh
    );

    public static ScaleFormula MaqamHijaz { get; } = new("Maqam Hijaz",
       Intervals.Unisson,
       Intervals.MajorSecond,
       Intervals.MinorThird,
       Intervals.PerfectFourth,
       Intervals.PerfectFifth,
       Intervals.MinorSixth,
       Intervals.MajorSixth,
       Intervals.MinorSeventh
   );

    public static ScaleFormula MaqamSaba { get; } = new("Maqam Saba",
       Intervals.Unisson,
       Intervals.MinorSecond,
       Intervals.MajorSecond,
       Intervals.MinorThird,
       Intervals.MajorThird,
       Intervals.PerfectFourth,
       Intervals.PerfectFifth,
       Intervals.MinorSixth,
       Intervals.MajorSixth,
       Intervals.MinorSeventh
   );

    public static ScaleFormula MaqamBayati { get; } = new("Maqam Bayati",
       Intervals.Unisson,
       Intervals.MajorSecond,
       Intervals.MinorThird,
       Intervals.MajorThird,
       Intervals.PerfectFourth,
       Intervals.PerfectFifth,
       Intervals.MinorSixth,
       Intervals.MajorSixth
   );

    public static ScaleFormula MaqamJiharkah { get; } = new("Maqam Jiharkah",
       Intervals.Unisson,
       Intervals.MinorSecond,
       Intervals.MajorSecond,
       Intervals.MinorThird,
       Intervals.MajorThird,
       Intervals.PerfectFourth,
       Intervals.PerfectFifth,
       Intervals.MinorSixth,
       Intervals.MinorSeventh
    );

    public static ScaleFormula MaqamAtharKurd { get; } = new("Maqam Athar Kurd",
       Intervals.Unisson,
       Intervals.MajorSecond,
       Intervals.MinorThird,
       Intervals.MajorThird,
       Intervals.PerfectFourth,
       Intervals.PerfectFifth,
       Intervals.MajorSixth,
       Intervals.MinorSeventh
   );

    public static ScaleFormula MaqamShawqAfza { get; } = new("Maqam Shawq Afza",
       Intervals.Unisson,
       Intervals.MinorSecond,
       Intervals.MinorThird,
       Intervals.MajorThird,
       Intervals.PerfectFourth,
       Intervals.PerfectFifth,
       Intervals.MinorSixth,
       Intervals.MajorSixth
   );

    public static IReadOnlyList<ScaleFormula> All { get; } = new[]
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
        WholeTone,
        MaqamHijaz,
        MaqamSaba,
        MaqamBayati,
        MaqamJiharkah,
        MaqamAtharKurd,
        MaqamShawqAfza
    };
}
