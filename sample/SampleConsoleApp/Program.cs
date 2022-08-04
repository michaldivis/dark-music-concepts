﻿using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Scales;

//-------------------------------------------------------------
// Note overview
//-------------------------------------------------------------

var note = new Note(NotePitch.E, Octave.Great);

Console.WriteLine($"Details about the note {note.Name}:");
Console.WriteLine($"Frequency is {note.Frequency}");
Console.WriteLine($"MIDI number is {note.MidiNumber}");

// Output:
// Details about the note E2:
// Frequency is 82,4068892282175 Hz
// MIDI number is 40

//-------------------------------------------------------------
// Note creation
//-------------------------------------------------------------

//create note
var c0 = new Note(NotePitch.C, Octave.SubContra);

//get note by name
var a1 = Note.A1;

//find note by frequency
var e2 = Note.FindByFrequency(82.40);
var foundE2 = Note.TryFindByFrequency(82.40, out var alsoE2);

//find note by MIDI number
var f2 = Note.FindByMidiNumber(41);
var foundF2 = Note.TryFindByMidiNumber(41, out var alsoF2);

//-------------------------------------------------------------
// Note comparison
//-------------------------------------------------------------

var a4 = new Note(NotePitch.A, Octave.OneLine);
var alsoA4 = new Note(NotePitch.A, Octave.OneLine);
var b5 = new Note(NotePitch.B, Octave.TwoLine);

_ = a4 == alsoA4; //true
_ = a4 != alsoA4; //false
_ = a4.Equals(alsoA4); //true
_ = a4 == b5; //false
_ = a4 != b5; //true
_ = a4.Equals(b5); //false

//-------------------------------------------------------------
// Intervals
//-------------------------------------------------------------

var minorSecond = Interval.MinorSecond;
_ = minorSecond.Distance; //2
_ = minorSecond.Name; //Minor Second
_ = minorSecond.Accident; //Flat

var g5 = Note.C5.Transpose(Interval.PerfectFifth); //returns G5
var gSharpOrAFlat2 = Note.CSharpOrDFlat2.Transpose(Interval.PerfectFifth); //returns GSharpOrAFlat2

//-------------------------------------------------------------
// Scales
//-------------------------------------------------------------

var gPhrygian = ScaleFormula.Phrygian.CreateForRoot(NotePitch.G);
var gPhrygianNotes = gPhrygian.Notes;
var gPhrygianFourth = gPhrygian.IV;