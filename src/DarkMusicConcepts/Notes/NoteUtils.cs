namespace DarkMusicConcepts.Notes;

public static class NoteUtils
{
    public static NotePitch TransposePitch(NotePitch pitch, Interval interval)
    {
        var note = new Note(pitch, Octave.OneLine);
        var transposedNote = note.Transpose(interval);
        return transposedNote.BasePitch;
    }
}
