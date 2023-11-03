namespace DarkMusicConcepts;

/// <summary>
/// In music theory, a scale is any set of musical notes ordered by fundamental frequency or pitch. A scale ordered by increasing pitch is an ascending scale, and a scale ordered by decreasing pitch is a descending scale.
/// </summary>
public class Scale
{
    public Pitch Root { get; }
    public ScaleFormula Formula { get; }

    /// <summary>
    /// Create a scale from notes
    /// </summary>
    /// <param name="root">The root pitch</param>
    /// <param name="formula">The scale formula</param>
    /// <param name="pitches">Notes to create the scale from</param>
    /// <returns>A created scale</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    internal static Scale Create(Pitch root, ScaleFormula formula, IEnumerable<Pitch> pitches)
    {
        pitches
            .ThrowIfNull()
            .IfCountLessThan(5);

        return new Scale(root, formula, pitches);
    }
     
    private Scale(Pitch root, ScaleFormula formula, IEnumerable<Pitch> pitches)
    {
        Root = root;
        Formula = formula;
        _pitches = pitches.ToList();
    }

    internal readonly List<Pitch> _pitches;
    public IReadOnlyList<Pitch> Pitches => _pitches;

    public Pitch I => Pitches[0];

    public Pitch II => Pitches[1];

    public Pitch III => Pitches[2];

    public Pitch IV => Pitches[3];

    public Pitch V => Pitches[4];

    public Pitch? VI => Pitches.ElementAtOrDefault(5);

    public Pitch? VII => Pitches.ElementAtOrDefault(6);

    public override string ToString()
    {
        return $"{Root} {Formula.Name}";
    }
}