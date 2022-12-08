using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Units;

namespace SampleConsoleApp.Demos;
internal class NotesDemo : Demo
{
    public override void Run()
    {
        PrintHeader("Notes");

        var note = Note.Create(Pitch.E, Octave.Two);

        Print(Note.Create(Pitch.E, Octave.Two));
        Print(note.Name);
        Print(note.Frequency);
        Print(note.MidiNumber);

        PrintSubHeader("Get note by name");

        Print(Notes.A1);

        PrintSubHeader("Find note by frequency");

        Print(Note.FindByFrequency(Frequency.From(82.40)));
        Print(Note.TryFindByFrequency(Frequency.From(82.40), out var alsoE2));
        Print(alsoE2);

        PrintSubHeader("Find note by MIDI number");

        Print(Note.FindByMidiNumber(MidiNumber.From(41)));
        Print(Note.TryFindByMidiNumber(MidiNumber.From(41), out var alsoF2));
        Print(alsoF2);

        PrintSubHeader("Note comparison");

        var a4 = Note.Create(Pitch.A, Octave.Four);
        var alsoA4 = Note.Create(Pitch.A, Octave.Four);
        var b5 = Note.Create(Pitch.B, Octave.Five);

        Print(a4);
        Print(alsoA4);
        Print(b5);

        Print(a4 == alsoA4); //true
        Print(a4 != alsoA4); //false
        Print(a4.Equals(alsoA4)); //true
        Print(a4 == b5); //false
        Print(a4 != b5); //true
        Print(a4.Equals(b5)); //false

        Print(a4 > b5); //false
        Print(b5 >= a4); //true
    }
}
