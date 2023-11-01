namespace DarkMusicConcepts;

/// <summary>
/// A chord in progress. Defines and builds a <see cref="Chord"/>
/// </summary>
public class ChordDefinition
{
    private readonly Note _root;
    private readonly HashSet<Note> _notes = new();

    internal ChordDefinition(Note root)
    {
        _root = root;

        _notes.Add(root);
    }

    /// <summary>
    /// Adds a note to the chord definition
    /// </summary>
    /// <param name="chordFunction">Chord function of the added note</param>
    /// <param name="accident">Accident of the added note</param>
    /// <returns>The updated definition</returns>
    /// <exception cref="ArgumentException"></exception>
    public ChordDefinition With(ChordFunction chordFunction, Accident accident = Accident.None)
    {
        var interval = chordFunction.Intervals.FirstOrDefault(x => x.Accident == accident);

        //TODO handle interval not found
        interval.ThrowIfNull("Interval with this accident not found in the specified chord function");

        var note = _root.TransposeUp(interval);

        _notes.Add(note);

        return this;
    }

    /// <summary>
    /// Builds the chord based on the previously defined steps
    /// </summary>
    /// <returns>Resulting chord</returns>
    public Chord Build()
    {
        return Chord.Create(_notes);
    }
}