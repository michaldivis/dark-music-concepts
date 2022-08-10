namespace DarkMusicConcepts.Scales;

/// <summary>
/// In music theory, a scale is any set of musical notes ordered by fundamental frequency or pitch. A scale ordered by increasing pitch is an ascending scale, and a scale ordered by decreasing pitch is a descending scale.
/// </summary>
public class Scale
{
    public Pitch Root { get; }
    public string Name { get; }

    /// <summary>
    /// Create a scale from notes
    /// </summary>
    /// <param name="pitches">Notes to create the scale from</param>
    /// <returns>A created scale</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    internal static Scale Create(Pitch root, string name, IEnumerable<Pitch> pitches)
    {
        if(pitches is null)
        {
            throw new ArgumentNullException(nameof(pitches), "Pitches cannot be null");
        }

        if(pitches.Count() < 5)
        {
            throw new ArgumentException("At least 5 pitches are required to create a scale", nameof(pitches));
        }

        return new Scale(root, name, pitches);
    }
     
    private Scale(Pitch root, string name, IEnumerable<Pitch> pitches)
    {
        Root = root;
        Name = name;
        Pitches = pitches;
    }

    public IEnumerable<Pitch> Pitches { get; }

    public Pitch I => Pitches.ElementAt(0);

    public Pitch II => Pitches.ElementAt(1);

    public Pitch III => Pitches.ElementAt(2);

    public Pitch IV => Pitches.ElementAt(3);

    public Pitch V => Pitches.ElementAt(4);

    public Pitch? VI => Pitches.ElementAtOrDefault(5);

    public Pitch? VII => Pitches.ElementAtOrDefault(6);

    public override string ToString()
    {
        return $"{Root} {Name}";
    }
}