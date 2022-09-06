namespace DarkMusicConcepts.Chords;

public class ChordNote
{
    public Note Note { get; }

    public Function Function { get; }

    public ChordNote(Note note, Function function)
    {
        Function = function;
        Note = note;
    }
}