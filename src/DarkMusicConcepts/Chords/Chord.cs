namespace DarkMusicConcepts.Chords;
public class Chord
{
    private readonly List<ChordNote> _chordNotes = new();

    public IEnumerable<Note> Notes => _chordNotes.Select(n => n.Note);

    public Chord(Note root, ChordFunction function)
    {
        _chordNotes.Add(new ChordNote(root, Function.Root));

        foreach (var interval in function.Intervals)
        {
            var note = new ChordNote(root.TransposeUp(interval), Function.FunctionForInterval(interval));
            _chordNotes.Add(note);
        }
    }

    public string Name => NoteForFunction(Function.Root).Name + ChordFunction.FunctionForIntervals(Intervals()).AbreviatedName;

    private Note NoteForFunction(Function function)
    {
        return _chordNotes.First(n => n.Function == function).Note;
    }

    private IEnumerable<Interval> Intervals()
    {
        var root = NoteForFunction(Function.Root);

        return Notes
            .Select(note => root.IntervalWithOther(note))
            .OrderBy(i => i.Distance)
            .Skip(1)
            .ToList();
    }

    public override string ToString()
    {
        return Name;
    }
}