﻿namespace DarkMusicConcepts.Scales;

/// <summary>
/// In music theory, a scale is any set of musical notes ordered by fundamental frequency or pitch. A scale ordered by increasing pitch is an ascending scale, and a scale ordered by decreasing pitch is a descending scale.
/// </summary>
public class Scale
{
    public NotePitch Root { get; }
    public string Name { get; }

    /// <summary>
    /// Create a scale from notes
    /// </summary>
    /// <param name="notes">Notes to create the scale from</param>
    /// <returns>A created scale</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    internal static Scale Create(NotePitch root, string name, IEnumerable<NotePitch> notes)
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
     
    private Scale(NotePitch root, string name, IEnumerable<NotePitch> notes)
    {
        Root = root;
        Name = name;
        Notes = notes;
    }

    public IEnumerable<NotePitch> Notes { get; }

    public NotePitch I => Notes.ElementAt(0);

    public NotePitch II => Notes.ElementAt(1);

    public NotePitch III => Notes.ElementAt(2);

    public NotePitch IV => Notes.ElementAt(3);

    public NotePitch V => Notes.ElementAt(4);

    public NotePitch? VI => Notes.ElementAtOrDefault(5);

    public NotePitch? VII => Notes.ElementAtOrDefault(6);

    public override string ToString()
    {
        return $"{Root} {Name}";
    }
}