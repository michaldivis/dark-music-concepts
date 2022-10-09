namespace DarkMusicConcepts.Chords;
public class Chord
{
    private readonly List<ChordNote> _chordNotes = new();

    public IReadOnlyList<Note> Notes { get; }

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

    public override string ToString()
    {
        var noteNames = string.Join(", ", Notes);
        return $"{Name} ({noteNames})";
    }
}