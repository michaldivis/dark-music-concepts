namespace DarkMusicConcepts.Chords;

public class ChordFormula
{
    public static ChordFormula Major { get; } = new("Maj", Interval.MajorThird, Interval.PerfectFifth);
    public static ChordFormula Augmented { get; } = new("Aug", Interval.MajorThird, Interval.AugmentedFifth);
    public static ChordFormula Minor { get; } = new("Min", Interval.MinorThird, Interval.PerfectFifth);
    public static ChordFormula Diminished { get; } = new("Dim", Interval.MinorThird, Interval.DiminishedFifth);
    public static ChordFormula Sus2 { get; } = new("Sus2", Interval.MajorSecond, Interval.PerfectFifth);
    public static ChordFormula Sus2Diminished { get; } = new("Sus2Dim", Interval.MajorSecond, Interval.DiminishedFifth);
    public static ChordFormula Sus2Augmented { get; } = new("Sus2Aug", Interval.MajorSecond, Interval.AugmentedFifth);
    public static ChordFormula Sus4 { get; } = new("Sus4", Interval.PerfectFourth, Interval.PerfectFifth);
    public static ChordFormula Sus4Diminished { get; } = new("Sus4Dim", Interval.PerfectFourth, Interval.DiminishedFifth);
    public static ChordFormula Sus4Augmented { get; } = new("Sus4Aug", Interval.PerfectFourth, Interval.AugmentedFifth);
    public static ChordFormula Major7 { get; } = new("Maj7", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh);
    public static ChordFormula Dominant7 { get; } = new("Dom7", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh);
    public static ChordFormula Minor7b5 { get; } = new("Min7b5", Interval.MinorThird, Interval.DiminishedFifth, Interval.MinorSeventh);
    public static ChordFormula Diminished7 { get; } = new("Dim7", Interval.MinorThird, Interval.DiminishedFifth, Interval.MajorSixth);
    public static ChordFormula Minor7 { get; } = new("Min7", Interval.MinorThird, Interval.PerfectFifth, Interval.MinorSeventh);
    public static ChordFormula MinorMaj7 { get; } = new("MinMaj7", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSeventh);
    public static ChordFormula Augmented7 { get; } = new("Aug7", Interval.MajorThird, Interval.AugmentedFifth, Interval.MajorSeventh);

    private ChordFormula(string abreviatedName, params Interval[] intervals)
    {
        AbreviatedName = abreviatedName;
        Intervals = intervals;
    }

    public string AbreviatedName { get; }

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

        //TODO handle this case better
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
        Augmented,
        Minor,
        Diminished,
        Sus2,
        Sus2Diminished,
        Sus2Augmented,
        Sus4,
        Sus4Diminished,
        Sus4Augmented,
        Major7,
        Dominant7,
        Minor7b5,
        Diminished7,
        Minor7,
        MinorMaj7,
        Augmented7
    };
}