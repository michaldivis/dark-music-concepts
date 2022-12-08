using Throw;

namespace DarkMusicConcepts.Chords;

/// <summary>
/// A chord in progress. Defines and builds a <see cref="Chord"/>
/// </summary>
public class ChordDefinition
{
    private readonly Note _root;
    private readonly List<Interval> _intervals = new();

    internal ChordDefinition(Note root)
    {
        _root = root;
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

        _intervals.Add(interval);

        return this;
    }

    /// <summary>
    /// Builds the chord based on the previously defined steps
    /// </summary>
    /// <returns>Resulting chord</returns>
    public Chord Build()
    {
        var existingFormula = ChordFormulas.All.FirstOrDefault(x => x.Intervals.SequenceEqual(_intervals));

        if (existingFormula is null)
        {
            var customFormula = new ChordFormula("Custom", _intervals.ToArray());
            return Chord.Create(_root, customFormula);
        }

        return Chord.Create(_root, existingFormula);
    }
}