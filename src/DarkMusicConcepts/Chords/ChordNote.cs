namespace DarkMusicConcepts.Chords;

public class ChordNote
{
    public Note Note { get; }

    public ChordFunction Function { get; }

    public ChordNote(Note note, ChordFunction function)
    {
        Function = function;
        Note = note;
    }
}