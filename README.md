﻿<img src="https://github.com/michaldivis/dark-music-concepts/blob/master/assets/icon.png?raw=true" width="200">

# Dark Music Concepts

A code model for western music concepts.

**Roadmap**
| Feature | Implementation status |
| --- | --- |
| Note | ✅ |
| Chord | ❌ |
| Scale | 🚧 (work in progress) |

## Status

![Build and Run Tests](https://github.com/michaldivis/dark-music-concepts/actions/workflows/build_and_test.yml/badge.svg)

## Nuget

### The core package

This is the main package. Contains all the music stuff, like notes, scales, etc.

[![Nuget](https://img.shields.io/nuget/v/Divis.DarkMusicConcepts?label=DarkMusicConcepts)](https://www.nuget.org/packages/Divis.DarkMusicConcepts/)

DarkMusicConcepts is available using [nuget](https://www.nuget.org/packages/Divis.DarkMusicConcepts/). To install DarkMusicConcepts, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

```Powershell
PM> Install-Package Divis.DarkMusicConcepts
```

### Units package

Units only. This tiny package only contains the `Frequency`, `MidiNumber` and `MidiVelocity` types.

[![Nuget](https://img.shields.io/nuget/v/Divis.DarkMusicConcepts.Units?label=DarkMusicConcepts.Units)](https://www.nuget.org/packages/Divis.DarkMusicConcepts.Units/)

DarkMusicConcepts.Units is available using [nuget](https://www.nuget.org/packages/Divis.DarkMusicConcepts.Units/). To install DarkMusicConcepts.Units, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

```Powershell
PM> Install-Package Divis.DarkMusicConcepts.Units
```

# Notes
```csharp
var note = Note.Create(Pitch.E, Octave.Great);

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
var c0 = Note.Create(Pitch.C, Octave.SubContra);

//get note by name
var a1 = Note.A1;

//find note by frequency
var e2 = Note.FindByFrequency(82.40);
var foundE2 = Note.TryFindByFrequency(82.40, out var alsoE2);

//find note by MIDI number
var f2 = Note.FindByMidiNumber(41);
var foundF2 = Note.TryFindByMidiNumber(41, out var alsoF2);
```

Compare notes
```csharp
var a4 = Note.Create(Pitch.A, Octave.OneLine);
var alsoA4 = Note.Create(Pitch.A, Octave.OneLine);
var b5 = Note.Create(Pitch.B, Octave.TwoLine);

_ = a4 == alsoA4; //true
_ = a4 != alsoA4; //false
_ = a4.Equals(alsoA4); //true
_ = a4 == b5; //false
_ = a4 != b5; //true
_ = a4.Equals(b5); //false
```

# Intervals

```csharp
var minorSecond = Interval.MinorSecond;
_ = minorSecond.Distance; //2
_ = minorSecond.Name; //Minor Second
_ = minorSecond.Accident; //Flat
```

Transpose up or down

```csharp
var g5 = Note.C5.TransposeUp(Interval.PerfectFifth); //returns G5
var transposeToG5Success = Note.C5.TryTransposeUp(Interval.PerfectFifth, out var alsoG5); //returns G5

var cSharp = Note.F4.TransposeDown(Interval.MajorThird); //returns CSharpOrDFlat4
var transposeToFSharpSuccess = Note.C5.TryTransposeDown(Interval.AugmentedForth, out var fSharp); //returns FSharpOrGFlat4
```

# Scales

```csharp
var gPhrygian = ScaleFormula.Phrygian.CreateForRoot(Pitch.G);
var gPhrygianPitches = gPhrygian.Pitches; //G, GSharpOrAFlat, ASharpOrBFlat, C, D, DSharpOrEFlat, F
var gPhrygianFourth = gPhrygian.IV; //C
```