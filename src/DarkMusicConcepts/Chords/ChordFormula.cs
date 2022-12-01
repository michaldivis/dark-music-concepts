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