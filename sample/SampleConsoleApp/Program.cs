using DarkMusicConcepts;

var note = new Note(NotePitch.E, Octave.Contra);

Console.WriteLine($"Details about the note {note.BasePitch}{(int)note.Octave}");
Console.WriteLine($"Frequency is {note.Frequency} Hz");
Console.WriteLine($"MIDI number is {note.MidiNumber}");

// Output:
// Details about the note E1
// Frequency is 41,20344461410875 Hz
// MIDI number is 28