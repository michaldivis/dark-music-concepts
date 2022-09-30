using DarkMusicConcepts.Notes;

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
    public static readonly ChordFormula Sus4 = new("Sus4", Interval.PerfectForth, Interval.PerfectFifth);
    public static readonly ChordFormula Sus4Diminished = new("Sus4Dim", Interval.PerfectForth, Interval.DiminishedFifth);
    public static readonly ChordFormula Sus4Augmented = new("Sus4Aug", Interval.PerfectForth, Interval.AugmentedFifth);
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

    public IEnumerable<Interval> Intervals { get; }

    public static ChordFormula FunctionForIntervals(IEnumerable<Interval> intervals)
    {
        return Functions.First(f => f.Intervals.SequenceEqual(intervals));
    }

    private static IEnumerable<ChordFormula> Functions { get; } = new[]
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

    public static IEnumerable<ChordFormula> GetFunctionsForScale(Scale scale)
    {
        var root = new Note(scale.Root, Octave.OneLine);

        foreach (var function in Functions)
        {
            var allPitchesAreContainedInScale = function.Intervals.All(a => scale.Pitches.Contains(root.TransposeUp(a).BasePitch));

            if (allPitchesAreContainedInScale)
            {
                yield return function;
            }
        }
    }
}