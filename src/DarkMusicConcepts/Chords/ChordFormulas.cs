namespace DarkMusicConcepts;

/// <summary>
/// Chord formulas. The current implementation contains the formulas described at <see href="http://www.smithfowler.org/music/Chord_Formulas.htm"/> and some custom ones
/// </summary>
public static class ChordFormulas
{
    #region Major

    public static ChordFormula Major { get; } =
        new("Maj", Intervals.MajorThird, Intervals.PerfectFifth);
    public static ChordFormula AddedFourth { get; } =
        new("Add4", Intervals.MajorThird, Intervals.PerfectFourth, Intervals.PerfectFifth);
    public static ChordFormula Sixth { get; } =
        new("6", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MajorSixth);
    public static ChordFormula SixNine { get; } =
        new("6/9", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MajorSixth, Intervals.MajorNinth);
    public static ChordFormula MajorSeventh { get; } =
        new("Maj7", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MajorSeventh);
    public static ChordFormula MajorNinth { get; } =
        new("Maj9", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MajorSeventh, Intervals.MajorNinth);
    public static ChordFormula MajorEleventh { get; } =
        new("Maj11", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MajorSeventh, Intervals.MajorNinth, Intervals.PerfectEleventh);
    public static ChordFormula MajorThirteenth { get; } =
        new("Maj13", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MajorSeventh, Intervals.MajorNinth, Intervals.PerfectEleventh, Intervals.MajorThirteenth);
    public static ChordFormula MajorSevenSharpEleventh { get; } =
        new("Maj7#11", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MajorSeventh, Intervals.DiminishedEleventh);
    public static ChordFormula MajorFlatFive { get; } =
        new("Majb5", Intervals.MajorThird, Intervals.DiminishedFifth);

    #endregion

    #region Minor

    public static ChordFormula Minor { get; } =
        new("Min", Intervals.MinorThird, Intervals.PerfectFifth);
    public static ChordFormula MinorAddedFourth { get; } =
        new("MinAdd4", Intervals.MinorThird, Intervals.PerfectFourth, Intervals.PerfectFifth);
    public static ChordFormula MinorSixth { get; } =
        new("Min6", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MajorSixth);
    public static ChordFormula MinorSeventh { get; } =
        new("Min7", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MinorSeventh);
    public static ChordFormula MinorAddedNinth { get; } =
        new("MinAdd9", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MajorNinth);
    public static ChordFormula MinorSixAddNine { get; } =
        new("Min6/9", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MajorSixth, Intervals.MajorNinth);
    public static ChordFormula MinorNinth { get; } =
        new("Min9", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MinorSeventh, Intervals.MajorNinth);
    public static ChordFormula MinorEleventh { get; } =
        new("Min11", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MinorSeventh, Intervals.MajorNinth, Intervals.PerfectEleventh);
    public static ChordFormula MinorThirteenth { get; } =
        new("Min13", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MinorSeventh, Intervals.MajorNinth, Intervals.PerfectEleventh, Intervals.MajorThirteenth);
    public static ChordFormula MinorMajorSeventh { get; } =
        new("MinMaj7", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MajorSeventh);
    public static ChordFormula MinorMajorNinth { get; } =
        new("MinMaj9", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MajorSeventh, Intervals.MajorNinth);
    public static ChordFormula MinorMajorEleventh { get; } =
        new("MinMaj11", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MajorSeventh, Intervals.MajorNinth, Intervals.PerfectEleventh);
    public static ChordFormula MinorMajorThirteenth { get; } =
        new("MinMaj13", Intervals.MinorThird, Intervals.PerfectFifth, Intervals.MajorSeventh, Intervals.MajorNinth, Intervals.PerfectEleventh, Intervals.MajorThirteenth);
    public static ChordFormula MinorSevenFlatFive { get; } =
        new("Min7b5", Intervals.MinorThird, Intervals.DiminishedFifth, Intervals.MinorSeventh);

    #endregion

    #region Dominant

    public static ChordFormula DominantSeventh { get; } =
        new("Dom7", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MinorSeventh);
    public static ChordFormula DominantNinth { get; } =
        new("Dom9", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MinorSeventh, Intervals.MajorNinth);
    public static ChordFormula DominantEleventh { get; } =
        new("Dom11", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MinorSeventh, Intervals.MajorNinth, Intervals.PerfectEleventh);
    public static ChordFormula DominantThirteenth { get; } =
        new("Dom13", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MinorSeventh, Intervals.MajorNinth, Intervals.PerfectEleventh, Intervals.MajorThirteenth);
    public static ChordFormula DominantSevenSharpFive { get; } =
        new("Dom7#5", Intervals.MajorThird, Intervals.AugmentedFifth, Intervals.MinorSeventh);
    public static ChordFormula DominantSevenFlatFive { get; } =
        new("Dom7b5", Intervals.MajorThird, Intervals.DiminishedFifth, Intervals.MinorSeventh);
    public static ChordFormula DominantSevenFlatNine { get; } =
        new("Dom7b9", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MinorSeventh, Intervals.MinorNinth);
    public static ChordFormula DominantSevenSharpNine { get; } =
        new("Dom7#9", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MinorSeventh, Intervals.AugmentedNinth);
    public static ChordFormula DominantNineSharpFive { get; } =
        new("Dom9#5", Intervals.MajorThird, Intervals.AugmentedFifth, Intervals.MinorSeventh, Intervals.MajorNinth);
    public static ChordFormula DominantNineFlatFive { get; } =
        new("Dom9b5", Intervals.MajorThird, Intervals.DiminishedFifth, Intervals.MinorSeventh, Intervals.MajorNinth);
    public static ChordFormula DominantSevenSharpFiveSharpNine { get; } =
        new("Dom7#5#9", Intervals.MajorThird, Intervals.AugmentedFifth, Intervals.MinorSeventh, Intervals.AugmentedNinth);
    public static ChordFormula DominantSevenSharpFiveFlatNine { get; } =
        new("Dom7#5b9", Intervals.MajorThird, Intervals.AugmentedFifth, Intervals.MinorSeventh, Intervals.MinorNinth);
    public static ChordFormula DominantSevenFlatFiveSharpNine { get; } =
        new("Dom7b5#9", Intervals.MajorThird, Intervals.DiminishedFifth, Intervals.MinorSeventh, Intervals.AugmentedNinth);
    public static ChordFormula DominantSevenFlatFiveFlatNine { get; } =
        new("Dom7b5b9", Intervals.MajorThird, Intervals.DiminishedFifth, Intervals.MinorSeventh, Intervals.MinorNinth);
    public static ChordFormula DominantSeventhSharpEleventh { get; } =
        new("Dom7#11", Intervals.MajorThird, Intervals.PerfectFifth, Intervals.MinorSeventh, Intervals.AugmentedEleventh);

    #endregion

    #region Symmetrical

    public static ChordFormula Diminished { get; } =
       new("Dim", Intervals.MinorThird, Intervals.DiminishedFifth);
    public static ChordFormula DiminishedSeventh { get; } =
       new("Dim7", Intervals.MinorThird, Intervals.DiminishedFifth, Intervals.MajorSixth);
    public static ChordFormula Augmented { get; } =
       new("Aug", Intervals.MajorThird, Intervals.AugmentedFifth);

    #endregion

    #region Miscellaneous

    public static ChordFormula SuspendedFourth { get; } =
       new("Sus4", Intervals.PerfectFourth, Intervals.PerfectFifth);
    public static ChordFormula SuspendedSecond { get; } =
       new("Sus2", Intervals.MajorSecond, Intervals.PerfectFifth);
    public static ChordFormula SharpEleven { get; } =
       new("#11", Intervals.PerfectFifth, Intervals.AugmentedEleventh);

    #endregion

    #region Guitar oriented chords
    public static ChordFormula TwoNotePowerChord { get; } =
       new("PowTwo", Intervals.PerfectFifth);
    public static ChordFormula ThreeNotePowerChord { get; } =
       new("PowThree", Intervals.PerfectFifth, Intervals.PerfectOctave);
    public static ChordFormula FourNotePowerChord { get; } =
       new("PowFour", Intervals.PerfectFifth, Intervals.PerfectOctave, Intervals.PerfectTwelfth);
    public static ChordFormula OctaveChord { get; } =
       new("Oct", Intervals.PerfectOctave);

    #endregion

    public static IReadOnlyList<ChordFormula> All { get; } = new[]
    {
        Major,
        AddedFourth,
        Sixth,
        SixNine,
        MajorSeventh,
        MajorNinth,
        MajorEleventh,
        MajorThirteenth,
        MajorSevenSharpEleventh,
        MajorFlatFive,
        Minor,
        MinorAddedFourth,
        MinorSixth,
        MinorSeventh,
        MinorAddedNinth,
        MinorSixAddNine,
        MinorNinth,
        MinorEleventh,
        MinorThirteenth,
        MinorMajorSeventh,
        MinorMajorNinth,
        MinorMajorEleventh,
        MinorMajorThirteenth,
        MinorSevenFlatFive,
        DominantSeventh,
        DominantNinth,
        DominantEleventh,
        DominantThirteenth,
        DominantSevenSharpFive,
        DominantSevenFlatFive,
        DominantSevenFlatNine,
        DominantSevenSharpNine,
        DominantNineSharpFive,
        DominantNineFlatFive,
        DominantSevenSharpFiveSharpNine,
        DominantSevenSharpFiveFlatNine,
        DominantSevenFlatFiveSharpNine,
        DominantSevenFlatFiveFlatNine,
        DominantSeventhSharpEleventh,
        Diminished,
        DiminishedSeventh,
        Augmented,
        SuspendedFourth,
        SuspendedSecond,
        SharpEleven,
        TwoNotePowerChord,
        ThreeNotePowerChord,
        FourNotePowerChord,
        OctaveChord
    };
}