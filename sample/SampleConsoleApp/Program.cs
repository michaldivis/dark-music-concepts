using Colorful;
using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Scales;
using System.Drawing;
using System.Runtime.CompilerServices;
using Console = Colorful.Console;

PrintHeader("Note overview");

var note = new Note(Pitch.E, Octave.Great);

Print(new Note(Pitch.E, Octave.Great));
Print(note.Name);
Print(note.Frequency);
Print(note.MidiNumber);

PrintHeader("Note creation");

PrintSubHeader("Get note by name");

var a1 = Note.A1;

Print(Note.A1);

PrintSubHeader("Find note by frequency");

var e2 = Note.FindByFrequency(82.40);
var foundE2 = Note.TryFindByFrequency(82.40, out var alsoE2);

Print(Note.FindByFrequency(82.40));
Print(Note.TryFindByFrequency(82.40, out var alsoAlsoE2));
Print(alsoAlsoE2);

PrintSubHeader("Find note by MIDI number");

var f2 = Note.FindByMidiNumber(41);

Print(Note.FindByMidiNumber(41));
Print(Note.TryFindByMidiNumber(41, out var alsoF2));
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

PrintHeader("Intervals");

var minorSecond = Interval.MinorSecond;

Print(minorSecond.Distance); //2
Print(minorSecond.Name); //Minor Second
Print(minorSecond.Accident); //Flat

PrintSubHeader("Transpose up or down");

var g5 = Note.C5.TransposeUp(Interval.PerfectFifth); //returns G5
var transposeToG5Success = Note.C5.TryTransposeUp(Interval.PerfectFifth, out var alsoG5); //returns G5

var cSharp = Note.F4.TransposeDown(Interval.MajorThird); //returns CSharpOrDFlat4
var transposeToFSharpSuccess = Note.C5.TryTransposeDown(Interval.AugmentedForth, out var fSharp); //returns FSharpOrGFlat4

Print(g5);
Print(transposeToG5Success);
Print(alsoG5);
Print(cSharp);
Print(transposeToFSharpSuccess);
Print(fSharp);

PrintHeader("Scales");

var gPhrygian = ScaleFormula.Phrygian.CreateForRoot(Pitch.G);
var gPhrygianNotes = gPhrygian.Notes;
var gPhrygianFourth = gPhrygian.IV;

Print(gPhrygian);
Print(string.Join(", ", gPhrygianNotes));
Print(gPhrygianFourth);

static void PrintHeader(string headerText)
{
    Console.WriteLine();
    Console.WriteLine($"*** {headerText.ToUpper()} ***", Color.Gray);
    Console.WriteLine();
}

static void PrintSubHeader(string subHeaderText)
{
    Console.WriteLine($"--- {subHeaderText}", Color.Gray);
}

static void Print(object? expression, [CallerArgumentExpression("expression")] string expressionText = null!)
{
    var parts = new Formatter[]
    {
        new Formatter(expressionText, Color.LightGreen),
        new Formatter(expression, Color.White)
    };

    Console.WriteLineFormatted("{0} => {1}", Color.LightGray, parts);
}