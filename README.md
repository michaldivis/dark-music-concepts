<img src="https://github.com/michaldivis/dark-music-concepts/blob/master/assets/icon.png?raw=true" width="200">

# Dark Music Concepts

A code model for western music concepts.

**Status**
| Feature | Status |
| --- | --- |
| Note | ✅ |
| Chord | ❌ |
| Scale | ❌ |

# Note
```csharp
var note = new Note(NotePitch.E, Octave.Contra);

Console.WriteLine($"Details about the note {note.BasePitch}{(int)note.Octave}");
Console.WriteLine($"Frequency is {note.Frequency} Hz");
Console.WriteLine($"MIDI number is {note.MidiNumber}");

// Output:
// Details about the note E1
// Frequency is 41,20344461410875 Hz
// MIDI number is 28
```