using System.Collections.ObjectModel;

namespace DarkMusicConcepts.Chords;

public class ChordFormula
{
    public static readonly ChordFormula Major = new("Maj", Interval.MajorThird, Interval.PerfectFifth);
    public static readonly ChordFormula Augmented = new("Aug", Interval.MajorThird, Interval.AugmentedFifth);
    public static readonly ChordFormula Minor = new("Min", Interval.MinorThird, Interval.PerfectFifth);
    public static readonly ChordFormula Diminished = new("Dim", Interval.MinorThird, Interval.DiminishedFifth);
    public static readonly ChordFormula Sus2 = new("Sus2", Interval.MajorSecond, Interval.PerfectFifth);
    public static readonly ChordFormula Sus2Diminished = new("Sus2Dim", Interval.MajorSecond, Interval.DiminishedFifth);
    public static readonly ChordFormula Sus2Augmented = new("Sus2Aug", Interval.MajorSecond, Interval.AugmentedFifth);
    public static readonly ChordFormula Sus4 = new("Sus4", Interval.PerfectFourth, Interval.PerfectFifth);
    public static readonly ChordFormula Sus4Diminished = new("Sus4Dim", Interval.PerfectFourth, Interval.DiminishedFifth);
    public static readonly ChordFormula Sus4Augmented = new("Sus4Aug", Interval.PerfectFourth, Interval.AugmentedFifth);
    public static readonly ChordFormula Major7 = new("Maj7", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh);
    public static readonly ChordFormula Dominant7 = new("Dom7", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh);
    public static readonly ChordFormula Minor7b5 = new("Min7b5", Interval.MinorThird, Interval.DiminishedFifth, Interval.MinorSeventh);
    public static readonly ChordFormula Diminished7 = new("Dim7", Interval.MinorThird, Interval.DiminishedFifth, Interval.MajorSixth);
    public static readonly ChordFormula Minor7 = new("Min7", Interval.MinorThird, Interval.PerfectFifth, Interval.MinorSeventh);
    public static readonly ChordFormula MinorMaj7 = new("MinMaj7", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSeventh);
    public static readonly ChordFormula Augmented7 = new("Aug7", Interval.MajorThird, Interval.AugmentedFifth, Interval.MajorSeventh);

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

        foreach (var formula in Formulas)
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

    private static IReadOnlyList<ChordFormula> Formulas { get; } = new[]
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

    public static IEnumerable<ChordFormula> GetFormulasForScale(Scale scale, Pitch chordRoot)
    {
        var root = new Note(chordRoot, Octave.OneLine);

        foreach (var function in Formulas)
        {
            var allPitchesAreContainedInScale = function.Intervals.All(a => scale.Pitches.Contains(root.TransposeUp(a).BasePitch));

            if (allPitchesAreContainedInScale)
            {
                yield return function;
            }
        }
    }
}