namespace DarkMusicConcepts.Notes;

public static class NoteUtils
{
    /// <summary>
    /// Transpose a pitch
    /// </summary>
    /// <param name="pitch">Pitch to transpose</param>
    /// <param name="interval">Interval to transpose by</param>
    /// <returns>Transposed pitch</returns>
    public static Pitch TransposePitch(Pitch pitch, Interval interval)
    {
        var note = Note.Create(pitch, Octave.OneLine);
        var transposedNote = note.TransposeUp(interval);
        return transposedNote.BasePitch;
    }
}
