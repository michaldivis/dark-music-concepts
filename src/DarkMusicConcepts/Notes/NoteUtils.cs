namespace DarkMusicConcepts.Notes;

public static class NoteUtils
{
    public static NotePitch TransposePitch(NotePitch pitch, Interval interval)
    {
        //TODO replace this bad implementation with a Transpose method on the Note class
        var note = new Note(pitch, Octave.OneLine);
        var transposedMidiNumber = note.MidiNumber.Value + interval.Distance;
        var transposedNote = Note.FindByMidiNumber(transposedMidiNumber);
        return transposedNote.BasePitch;
    }
}
