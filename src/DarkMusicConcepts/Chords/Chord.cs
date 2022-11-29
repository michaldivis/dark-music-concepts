using DarkMusicConcepts.Utils;

namespace DarkMusicConcepts.Chords;
/// <summary>
/// A chord is any harmonic set of pitches/frequencies consisting of multiple notes (also called "pitches") that are heard as if sounding simultaneously.
/// </summary>
public class Chord
{
    private readonly List<ChordNote> _chordNotes = new();
    private readonly Note _rootBeforeInversion;

    /// <summary>
    /// The formula used to created the chord
    /// </summary>
    public ChordFormula Formula { get; }

    /// <summary>
    /// The inversion. This will be 0 if the chord hasn't been inverted, or greater than 0 if it has.
    /// </summary>
    public int Inversion { get; }

    /// <summary>
    /// The name of the chord containing the note name and number + the type/quality
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The root note of the chord
    /// </summary>
    public Note Bass { get; }

    /// <summary>
    /// The leading (highest) note of the chord
    /// </summary>
    public Note Lead { get; }

    /// <summary>
    /// All the notes contained in the chord
    /// </summary>
    public IReadOnlyList<Note> Notes { get; }

    private Chord(IReadOnlyList<Note> notes, Note rootBeforeInversion, ChordFormula chordFormula, int inversion)
    {
        _rootBeforeInversion = rootBeforeInversion;

        Notes = notes;
        Inversion = inversion;
        Formula = chordFormula;

        var root = notes[0];

        _chordNotes.Add(new ChordNote(root, ChordFunction.Root));

        foreach (var note in notes)
        {
            var interval = root.IntervalWithOther(note);
            var chordNote = new ChordNote(note, ChordFunction.FunctionForInterval(interval));
            _chordNotes.Add(chordNote);
        }

        Name = GetName(_rootBeforeInversion, chordFormula, inversion);

        Bass = notes[0];
        Lead = notes[notes.Count - 1];
    }

    public static Chord Create(Note root, ChordFormula formula)
    {
        var notes = new List<Note>();

        notes.Add(root);

        foreach (var interval in formula.Intervals)
        {
            notes.Add(root.TransposeUp(interval));
        }

        return new Chord(notes, root, formula, 0);
    }

    /// <summary>
    /// Perform a chord inversion 
    /// </summary>
    /// <returns>Returns the next inversion of the chord, or if the maximum number of inversions has been reached, returns the base chord but an octave up</returns>
    public Chord Invert()
    {
        var invertedNotes = new List<Note>();
        invertedNotes.AddRange(Notes.Skip(1));
        invertedNotes.Add(Notes[0].TransposeUp(Interval.PerfectOctave));
        invertedNotes.Sort();

        if(Inversion >= invertedNotes.Count - 1)
        {
            return new Chord(invertedNotes, _rootBeforeInversion.TransposeUp(Interval.PerfectOctave), Formula, 0);
        }

        return new Chord(invertedNotes, _rootBeforeInversion, Formula, Inversion + 1);   
    }

    private static string GetName(Note root, ChordFormula formula, int inversion)
    {
        if(inversion == 0)
        {
            return root.Name + formula.AbreviatedName;
        }

        return $"{root.Name}{formula.AbreviatedName} ({Humanizer.AddOrdinal(inversion)} inversion)";
    }

    public override string ToString()
    {
        var noteNames = string.Join(", ", Notes);
        return $"{Name} ({noteNames})";
    }
}