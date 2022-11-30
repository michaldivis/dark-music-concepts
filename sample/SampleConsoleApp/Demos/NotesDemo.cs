using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Units;

namespace SampleConsoleApp.Demos;
internal class NotesDemo : Demo
{
    public override void Run()
    {
        PrintHeader("Note overview");

        var note = new Note(Pitch.E, Octave.Great);

        Print(new Note(Pitch.E, Octave.Great));
        Print(note.Name);
        Print(note.Frequency);
        Print(note.MidiNumber);

        PrintHeader("Note creation");

        PrintSubHeader("Get note by name");

        var a1 = Notes.A1;

        Print(Notes.A1);

        PrintSubHeader("Find note by frequency");

        var e2 = Note.FindByFrequency(Frequency.From(82.40));
        var foundE2 = Note.TryFindByFrequency(Frequency.From(82.40), out var alsoE2);

        Print(Note.FindByFrequency(Frequency.From(82.40)));
        Print(Note.TryFindByFrequency(Frequency.From(82.40), out var alsoAlsoE2));
        Print(alsoAlsoE2);

        PrintSubHeader("Find note by MIDI number");

        var f2 = Note.FindByMidiNumber(MidiNumber.From(41));

        Print(Note.FindByMidiNumber(MidiNumber.From(41)));
        Print(Note.TryFindByMidiNumber(MidiNumber.From(41), out var alsoF2));
        Print(alsoF2);

        PrintHeader("Note comparison");

        var a4 = new Note(Pitch.A, Octave.OneLine);
        var alsoA4 = new Note(Pitch.A, Octave.OneLine);
        var b5 = new Note(Pitch.B, Octave.TwoLine);

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
