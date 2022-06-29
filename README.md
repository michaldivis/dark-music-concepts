<img src="https://github.com/michaldivis/dark-music-concepts/blob/master/assets/icon.png?raw=true" width="200">

# Dark Music Concepts

A code model for western music concepts.

**Roadmap**
| Feature | Implementation status |
| --- | --- |
| Note | ✅ |
| Chord | ❌ |
| Scale | ❌ |

# Note
```csharp
using DarkMusicConcepts;

var note = new Note(NotePitch.E, Octave.Great);

Console.WriteLine($"Details about the note {note.Name}:");
Console.WriteLine($"Frequency is {note.Frequency}");
Console.WriteLine($"MIDI number is {note.MidiNumber}");

// Output:
// Details about the note E2:
// Frequency is 82,4068892282175 Hz
// MIDI number is 40
```

Create or find a note
```csharp
//create note
var c0 = new Note(NotePitch.C, Octave.SubContra);

//get note by name
var a1 = Note.A1;

//find note by frequency
var e2 = Note.FindByFrequency(82.40);

//find note by MIDI number
var f2 = Note.FindByMidiNumber(41);
```

Compare notes
```csharp
var a4 = new Note(NotePitch.A, Octave.OneLine);
var alsoA4 = new Note(NotePitch.A, Octave.OneLine);
var b5 = new Note(NotePitch.B, Octave.TwoLine);

_ = a4 == alsoA4; //true
_ = a4 != alsoA4; //false
_ = a4.Equals(alsoA4); //true
_ = a4 == b5; //false
_ = a4 != b5; //true
_ = a4.Equals(b5); //false
```