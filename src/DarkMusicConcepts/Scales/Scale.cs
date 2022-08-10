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
    /// <param name="notes">Notes to create the scale from</param>
    /// <returns>A created scale</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    internal static Scale Create(Pitch root, string name, IEnumerable<Pitch> notes)
    {
        if(notes is null)
        {
            throw new ArgumentNullException(nameof(notes), "Notes cannot be null");
        }

        if(notes.Count() < 5)
        {
            throw new ArgumentException("At least 5 notes are required to create a scale", nameof(notes));
        }

        return new Scale(root, name, notes);
    }
     
    private Scale(Pitch root, string name, IEnumerable<Pitch> notes)
    {
        Root = root;
        Name = name;
        Notes = notes;
    }

    public IEnumerable<Pitch> Notes { get; }

    public Pitch I => Notes.ElementAt(0);

    public Pitch II => Notes.ElementAt(1);

    public Pitch III => Notes.ElementAt(2);

    public Pitch IV => Notes.ElementAt(3);

    public Pitch V => Notes.ElementAt(4);

    public Pitch? VI => Notes.ElementAtOrDefault(5);

    public Pitch? VII => Notes.ElementAtOrDefault(6);

    public override string ToString()
    {
        return $"{Root} {Name}";
    }
}