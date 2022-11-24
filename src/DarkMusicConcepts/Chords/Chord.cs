namespace DarkMusicConcepts.Chords;
public class Chord
{
    private readonly List<ChordNote> _chordNotes = new();

    public IReadOnlyList<Note> Notes { get; }

    private Chord(IEnumerable<Note> notes)
    {
        var root = notes.First();
        _chordNotes.Add(new ChordNote(root, ChordFunction.Root));

        foreach (var note in notes.Skip(1))
        {
            var interval = root.IntervalWithOther(note);
            var chordNote = new ChordNote(note, ChordFunction.FunctionForInterval(interval));
            _chordNotes.Add(chordNote);
        }

        Notes = _chordNotes
            .Select(n => n.Note)
            .ToList();
    }

    public Chord(Note root, ChordFormula function)
    {
        _chordNotes.Add(new ChordNote(root, ChordFunction.Root));

        foreach (var interval in function.Intervals)
        {
            var note = new ChordNote(root.TransposeUp(interval), ChordFunction.FunctionForInterval(interval));
            _chordNotes.Add(note);
        }

        Notes = _chordNotes
            .Select(n => n.Note)
            .ToList();
    }

    public Note Bass => Notes[0];
    public Note Lead => Notes[Notes.Count - 1];

    public string Name => NoteForFunction(ChordFunction.Root).Name + ChordFormula.FunctionForIntervals(Intervals()).AbreviatedName;

    private Note NoteForFunction(ChordFunction function)
    {
        return _chordNotes.First(n => n.Function == function).Note;
    }

    private IEnumerable<Interval> Intervals()
    {
        var root = NoteForFunction(ChordFunction.Root);

        return Notes
            .Select(note => root.IntervalWithOther(note))
            .OrderBy(i => i.Distance)
            .Skip(1)
            .ToList();
    }

    public Chord Invert()
    {
        var notesExceptRoot = Notes
            .Skip(1)
            .ToList();
        var rootOctaveAbove = Notes[0].TransposeUp(Interval.PerfectOctave);
        notesExceptRoot.Add(rootOctaveAbove);
        return new Chord(notesExceptRoot);
    }

    public override string ToString()
    {
        var noteNames = string.Join(", ", Notes);
        return $"{Name} ({noteNames})";
    }
}