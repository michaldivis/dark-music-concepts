namespace DarkMusicConcepts.Chords;

/// <summary>
/// A chord formula is a list of intervals which make up a chord. The current implementation contains the formulas described at <see href="http://www.smithfowler.org/music/Chord_Formulas.htm"/>
/// </summary>
public class ChordFormula
{
    #region Major

    public static ChordFormula Major { get; } = 
        new("Maj", Interval.MajorThird, Interval.PerfectFifth);
    public static ChordFormula AddedFourth { get; } =
        new("Add4", Interval.MajorThird, Interval.PerfectFourth, Interval.PerfectFifth);
    public static ChordFormula Sixth { get; } =
        new("6", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSixth);
    public static ChordFormula SixNine { get; } =
        new("6/9", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSixth, Interval.MajorNinth);
    public static ChordFormula MajorSeventh { get; } =
        new("Maj7", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh);
    public static ChordFormula MajorNinth { get; } =
        new("Maj9", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh, Interval.MajorNinth);
    public static ChordFormula MajorEleventh { get; } =
        new("Maj11", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh, Interval.MajorNinth, Interval.PerfectEleventh);
    public static ChordFormula MajorThirteenth { get; } =
        new("Maj13", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh, Interval.MajorNinth, Interval.PerfectEleventh, Interval.MajorThirteenth);
    public static ChordFormula MajorSevenSharpEleventh { get; } =
        new("Maj7#11", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh, Interval.DiminishedEleventh);
    public static ChordFormula MajorFlatFive { get; } =
        new("Majb5", Interval.MajorThird, Interval.DiminishedFifth);

    #endregion

    #region Minor

    public static ChordFormula Minor { get; } =
        new("Min", Interval.MinorThird, Interval.PerfectFifth);
    public static ChordFormula MinorAddedFourth { get; } =
        new("MinAdd4", Interval.MinorThird, Interval.PerfectFourth, Interval.PerfectFifth);
    public static ChordFormula MinorSixth { get; } =
        new("Min6", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSixth);
    public static ChordFormula MinorSeventh { get; } =
        new("Min7", Interval.MinorThird, Interval.PerfectFifth, Interval.MinorSeventh);
    public static ChordFormula MinorAddedNinth { get; } =
        new("MinAdd9", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorNinth);
    public static ChordFormula MinorSixAddNine { get; } =
        new("Min6/9", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSixth, Interval.MajorNinth);
    public static ChordFormula MinorNinth { get; } =
        new("Min9", Interval.MinorThird, Interval.PerfectFifth, Interval.MinorSeventh, Interval.MajorNinth);
    public static ChordFormula MinorEleventh { get; } =
        new("Min11", Interval.MinorThird, Interval.PerfectFifth, Interval.MinorSeventh, Interval.MajorNinth, Interval.PerfectEleventh);
    public static ChordFormula MinorThirteenth { get; } =
        new("Min13", Interval.MinorThird, Interval.PerfectFifth, Interval.MinorSeventh, Interval.MajorNinth, Interval.PerfectEleventh, Interval.MajorThirteenth);
    public static ChordFormula MinorMajorSeventh { get; } =
        new("MinMaj7", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSeventh);
    public static ChordFormula MinorMajorNinth { get; } =
        new("MinMaj9", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSeventh, Interval.MajorNinth);
    public static ChordFormula MinorMajorEleventh { get; } =
        new("MinMaj11", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSeventh, Interval.MajorNinth, Interval.PerfectEleventh);
    public static ChordFormula MinorMajorThirteenth { get; } =
        new("MinMaj13", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSeventh, Interval.MajorNinth, Interval.PerfectEleventh, Interval.MajorThirteenth);
    public static ChordFormula MinorSevenFlatFive { get; } =
        new("Min7b5", Interval.MinorThird, Interval.DiminishedFifth, Interval.MinorSeventh);

    #endregion

    #region Dominant

    public static ChordFormula DominantSeventh { get; } =
        new("Dom7", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh);
    public static ChordFormula DominantNinth { get; } =
        new("Dom9", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh, Interval.MajorNinth);
    public static ChordFormula DominantEleventh { get; } =
        new("Dom11", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh, Interval.MajorNinth, Interval.PerfectEleventh);
    public static ChordFormula DominantThirteenth { get; } =
        new("Dom13", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh, Interval.MajorNinth, Interval.PerfectEleventh, Interval.MajorThirteenth);
    public static ChordFormula DominantSevenSharpFive { get; } =
        new("Dom7#5", Interval.MajorThird, Interval.AugmentedFifth, Interval.MinorSeventh);
    public static ChordFormula DominantSevenFlatFive { get; } =
        new("Dom7b5", Interval.MajorThird, Interval.DiminishedFifth, Interval.MinorSeventh);
    public static ChordFormula DominantSevenFlatNine { get; } =
        new("Dom7b9", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh, Interval.MinorNinth);
    public static ChordFormula DominantSevenSharpNine { get; } =
        new("Dom7#9", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh, Interval.AugmentedNinth);
    public static ChordFormula DominantNineSharpFive { get; } =
        new("Dom9#5", Interval.MajorThird, Interval.AugmentedFifth, Interval.MinorSeventh, Interval.MajorNinth);
    public static ChordFormula DominantNineFlatFive { get; } =
        new("Dom9b5", Interval.MajorThird, Interval.DiminishedFifth, Interval.MinorSeventh, Interval.MajorNinth);
    public static ChordFormula DominantSevenSharpFiveSharpNine { get; } =
        new("Dom7#5#9", Interval.MajorThird, Interval.AugmentedFifth, Interval.MinorSeventh, Interval.AugmentedNinth);
    public static ChordFormula DominantSevenSharpFiveFlatNine { get; } =
        new("Dom7#5b9", Interval.MajorThird, Interval.AugmentedFifth, Interval.MinorSeventh, Interval.MinorNinth);
    public static ChordFormula DominantSevenFlatFiveSharpNine { get; } =
        new("Dom7b5#9", Interval.MajorThird, Interval.DiminishedFifth, Interval.MinorSeventh, Interval.AugmentedNinth);
    public static ChordFormula DominantSevenFlatFiveFlatNine { get; } =
        new("Dom7b5b9", Interval.MajorThird, Interval.DiminishedFifth, Interval.MinorSeventh, Interval.MinorNinth);
    public static ChordFormula DominantSeventhSharpEleventh { get; } =
        new("Dom7#11", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh, Interval.AugmentedEleventh);

    #endregion

    #region Symmetrical

    public static ChordFormula Diminished { get; } =
       new("Dim", Interval.MinorThird, Interval.DiminishedFifth);
    public static ChordFormula DiminishedSeventh { get; } =
       new("Dim7", Interval.MinorThird, Interval.DiminishedFifth, Interval.MajorSixth);
    public static ChordFormula Augmented { get; } =
       new("Aug", Interval.MajorThird, Interval.AugmentedFifth);

    #endregion

    #region Miscellaneous

    public static ChordFormula SuspendedFourth { get; } =
       new("Sus4", Interval.PerfectFourth, Interval.PerfectFifth);
    public static ChordFormula SuspendedSecond { get; } =
       new("Sus2", Interval.MajorSecond, Interval.PerfectFifth);
    public static ChordFormula SharpEleven { get; } =
       new("#11", Interval.PerfectFifth, Interval.AugmentedEleventh);

    #endregion

    #region Guitar oriented chords
    public static ChordFormula TwoNotePowerChord { get; } =
       new("2Pow", Interval.PerfectFifth);
    public static ChordFormula ThreeNotePowerChord { get; } =
       new("3Pow", Interval.PerfectFifth, Interval.PerfectOctave);
    public static ChordFormula FourNotePowerChord { get; } =
       new("4Pow", Interval.PerfectFifth, Interval.PerfectOctave, Interval.PerfectTwelfth);
    public static ChordFormula OctaveChord { get; } =
       new("Oct", Interval.PerfectOctave);

    #endregion

    private ChordFormula(string abreviatedName, params Interval[] intervals)
    {
        AbreviatedName = abreviatedName;
        Intervals = intervals;
    }

    /// <summary>
    /// The short (abreviated) name of the formula
    /// </summary>
    public string AbreviatedName { get; }

    /// <summary>
    /// The list of intervals that make up the formula
    /// </summary>
    public IReadOnlyList<Interval> Intervals { get; }

    public static ChordFormula FunctionForIntervals(IEnumerable<Interval> intervals, int inversion)
    {
        if(inversion < 0 || inversion > intervals.Count())
        {
            throw new ArgumentOutOfRangeException(nameof(inversion), inversion, "Inversion number is invalid");
        }

        foreach (var formula in AllFormulas)
        {
            if(intervals.Count() != formula.Intervals.Count)
            {
                continue;
            }

            if(IsIntervalSequenceEqual(intervals, formula.Intervals, inversion))
            {
                return formula;
            }
        }

        //this should never occur
        throw new ArgumentException("No matching formula found for these intervals and inversion");
    }

    private static bool IsIntervalSequenceEqual(IEnumerable<Interval> source, IReadOnlyList<Interval> target, int sourceInversion)
    {
        static int GetInvertedIndex(int index, int count, int inversion)
        {
            var wantedIndex = index + inversion;

            if (wantedIndex > count - 1)
            {
                return wantedIndex - count;
            }

            return wantedIndex;
        }

        for (int i = 0; i < target.Count; i++)
        {
            var index = GetInvertedIndex(i, target.Count, sourceInversion);

            if (source.ElementAt(index) != target[i])
            {
                return false;
            }
        }

        return true;
    }

    public static IEnumerable<ChordFormula> GetFormulasForScale(Scale scale, Pitch chordRoot)
    {
        var root = new Note(chordRoot, Octave.OneLine);

        foreach (var function in AllFormulas)
        {
            var allPitchesAreContainedInScale = function.Intervals.All(a => scale.Pitches.Contains(root.TransposeUp(a).BasePitch));

            if (allPitchesAreContainedInScale)
            {
                yield return function;
            }
        }
    }

    public static IReadOnlyList<ChordFormula> AllFormulas { get; } = new[]
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

    public override string ToString()
    {
        return AbreviatedName;
    }
}