<img src="https://github.com/michaldivis/dark-music-concepts/blob/master/assets/header.png?raw=true">

A code model for western music concepts.

## Status

![Run Tests](https://github.com/michaldivis/dark-music-concepts/actions/workflows/run_tests.yml/badge.svg)

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

# How to use

## Notes

```csharp
var note = Note.Create(Pitch.E, Octave.Two);
// note.Name => E2
// note.Frequency => 82,4068892282175 Hz
// note.MidiNumber => 40

// Get note by name

var a1 = Notes.A1;

// Find note by frequency

var e2 = Note.FindByFrequency(Frequency.From(82.40));
var success = Note.TryFindByFrequency(Frequency.From(82.40), out var alsoE2);

// Find note by MIDI number

var f2 = Note.FindByMidiNumber(MidiNumber.From(41));
Note.TryFindByMidiNumber(MidiNumber.From(41), out var alsoF2);

// Note comparison

var a4 = Notes.A4;
var alsoA4 = Note.FindByMidiNumber(a4.MidiNumber);
var b5 = Notes.B5;

// a4 == alsoA4 => True
// a4 != alsoA4 => False
// a4.Equals(alsoA4) => True
// a4 == b5 => False
// a4 != b5 => True
// a4.Equals(b5) => False
// a4 > b5 => False
// b5 >= a4 => True
```

## Intervals

```csharp
var minorSecond = Intervals.MinorSecond;
// minorSecond.Distance => 1
// minorSecond.Name => Minor 2nd
// minorSecond.Accident => Flat
// Intervals.MajorSeventh > Intervals.PerfectFourth => True

// Transpose up or down

var g5 = Notes.C5.TransposeUp(Intervals.PerfectFifth); //returns G5
var transposeToG5Success = Notes.C5.TryTransposeUp(Intervals.PerfectFifth, out var alsoG5); //returns G5

var cSharp = Notes.F4.TransposeDown(Intervals.MajorThird); //returns CSharpOrDFlat4
var transposeToFSharpSuccess = Notes.C5.TryTransposeDown(Intervals.AugmentedFourth, out var fSharp); //returns FSharpOrGFlat4
```

## Scales

```csharp
var gPhrygian = ScaleFormulas.Phrygian.Create(Pitch.G);

// gPhrygian => G Phrygian
// gPhrygian.Pitches => G, GSharpOrAFlat, ASharpOrBFlat, C, D, DSharpOrEFlat, F
// gPhrygian.IV => C
```

## Chords

```csharp
var chord = Chord.Create(Notes.C2, ChordFormulas.DominantSeventh);

// chord => C2Dom7(C2, E2, G2, A#/Bb2)
// chord.Bass => C2
// chord.Lead => A#/Bb2
// chord.Formula => Dom7
// chord.Notes => C2, E2, G2, A#/Bb2

var chord1stInversion = chord.Invert(); // => C2Dom7(1st inversion)(E2, G2, A#/Bb2, C3)
var chord2ndInversion = chord1stInversion.Invert(); // => C2Dom7(2nd inversion)(G2, A#/Bb2, C3, E3)
var chord3rdInversion = chord2ndInversion.Invert(); // => C2Dom7(3rd inversion)(A#/Bb2, C3, E3, G3)
var chord4thInversion = chord3rdInversion.Invert(); // => C3Dom7(C3, E3, G3, A#/Bb3)


// Chord builder

var customChord = Chord
    .CreateCustom(Notes.G3)
    .With(ChordFunctions.Third)
    .With(ChordFunctions.Fifth, Accident.Sharp)
    .With(ChordFunctions.Eleventh, Accident.Flat)
    .Build();
// => G3Custom(G3, B3, D#/Eb4, B4)


// Chords from scale degrees

var cMajorScale = ScaleFormulas.Ionian.Create(Pitch.C);
var octave = Octave.Four;

Chord.Create(cMajorScale, octave, ScaleDegree.I); // => C4Maj(C4, E4, G4)
Chord.Create (cMajorScale, octave, ScaleDegree.II); //  => D4Custom(D4, F4, A4)
Chord.Create (cMajorScale, octave, ScaleDegree.III); //  => E4Custom(E4, G4, B4)
Chord.Create (cMajorScale, octave, ScaleDegree.IV); //  => F4Maj(F4, A4, C5)
Chord.Create (cMajorScale, octave, ScaleDegree.V); //  => G4Maj(G4, B4, D5)
Chord.Create (cMajorScale, octave, ScaleDegree.VI); //  => A4Custom(A4, C5, E5)
Chord.Create (cMajorScale, octave, ScaleDegree.VII); //  => B4Custom(B4, D5, F5)


// Chords from scale degrees

// The following will create a triad based on the major scale. Starting with the root pitch, then skipping one pitch and taking the next.
Chord.Create(cMajorScale, cMajorScale.Root, octave, ScaleStep.II, ScaleStep.II); //  => C4Maj(C4, E4, G4)


// Chords from types (tertian, quartal, etc.)

Chord.Create(cMajorScale, octave, Pitch.C, ChordType.Tertian, amountOfNotes: 4); //  => C4Maj7(C4, E4, G4, B4)
Chord.Create(cMajorScale, octave, Pitch.C, ChordType.Quartal, amountOfNotes: 4); //  => C4Custom(C4, F4, B4, E5)
Chord.Create(cMajorScale, octave, Pitch.C, ChordType.Quintal, amountOfNotes: 4); //  => C4Custom(C4, G4, D5, A5)
Chord.Create(cMajorScale, octave, Pitch.C, ChordType.Sextal, amountOfNotes: 4); //  => C4Custom(C4, A4, F5, D6)
Chord.Create(cMajorScale, octave, Pitch.C, ChordType.Septimal, amountOfNotes: 4); //  => C4Custom(C4, B4, A5, G6)


// Chords progressions

var chordProgression = ChordProgressions.Pop.I_IV_V_IV; // => I - IV - V - IV

var customChordProgression = ChordProgression.Create(ScaleDegree.I, ScaleDegree.IV, ScaleDegree.V, ScaleDegree.II, ScaleDegree.VI); // => I - IV - V - II - VI

var customChordProgressionChords = customChordProgression.GetChords(cMajorScale, octave);
// =>
//     C4Maj(C4, E4, G4)
//     F4Maj(F4, A4, C5)
//     G4Maj(G4, B4, D5)
//     D4Custom(D4, F4, A4)
//     A4Custom(A4, C5, E5)
```

## Time

```csharp
Time.QuarterNote; // => 960 ticks
Time.WholeNote; // => 3 840 ticks
Time.Bar; // => 15 360 ticks
Time.QuarterNote.GetDuration(Bpm.From(155)); // => 00:00:00.3870967
Time.QuarterNote.Ticks; // => 960
Time.QuarterNote * 3; // => 2 880 ticks
Time.HalfNoteDotted + Time.Bar - (Time.SixteenthNote * 8); // => 16 320 ticks
```

## More

Checkout the sample apps to learn more:
- [Console sample app](/sample/SampleConsoleApp/)
- [WPF sample app](/sample/TheoryPlayground/)
