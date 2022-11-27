using DarkMusicConcepts.Utils;

namespace DarkMusicConcepts.Chords;
public class Chord
{
    private readonly List<ChordNote> _chordNotes = new();
    private readonly Note _rootBeforeInversion;

    public ChordFormula Formula { get; }
    public int Inversion { get; }
    public string Name { get; }
    public Note Bass { get; }
    public Note Lead { get; }
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

    public Chord Invert()
    {
        var invertedNotes = Notes.Skip(1).ToList();

        invertedNotes.Add(Notes[0].TransposeUp(Interval.PerfectOctave));

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