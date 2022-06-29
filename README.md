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