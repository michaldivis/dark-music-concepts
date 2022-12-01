namespace DarkMusicConcepts.Chords;

/// <summary>
/// A chord formula is a list of intervals which make up a chord
/// </summary>
public class ChordFormula
{   
    internal ChordFormula(string abreviatedName, params Interval[] intervals)
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

        foreach (var formula in ChordFormulas.All)
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
        var root = Note.Create(chordRoot, Octave.OneLine);

        foreach (var function in ChordFormulas.All)
        {
            var allPitchesAreContainedInScale = function.Intervals.All(a => scale.Pitches.Contains(root.TransposeUp(a).BasePitch));

            if (allPitchesAreContainedInScale)
            {
                yield return function;
            }
        }
    }

    public override string ToString()
    {
        return AbreviatedName;
    }
}