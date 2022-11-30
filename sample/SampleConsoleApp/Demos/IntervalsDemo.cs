using DarkMusicConcepts.Notes;

namespace SampleConsoleApp.Demos;
internal class IntervalsDemo : Demo
{
    public override void Run()
    {
        PrintHeader("Intervals");

        var minorSecond = Intervals.MinorSecond;

        Print(minorSecond.Distance); //2
        Print(minorSecond.Name); //Minor Second
        Print(minorSecond.Accident); //Flat

        Print(Intervals.MajorSeventh > Intervals.PerfectFourth); //true

        PrintSubHeader("Transpose up or down");

        var g5 = Notes.C5.TransposeUp(Intervals.PerfectFifth); //returns G5
        var transposeToG5Success = Notes.C5.TryTransposeUp(Intervals.PerfectFifth, out var alsoG5); //returns G5

        var cSharp = Notes.F4.TransposeDown(Intervals.MajorThird); //returns CSharpOrDFlat4
        var transposeToFSharpSuccess = Notes.C5.TryTransposeDown(Intervals.AugmentedFourth, out var fSharp); //returns FSharpOrGFlat4

        Print(g5);
        Print(transposeToG5Success);
        Print(alsoG5);
        Print(cSharp);
        Print(transposeToFSharpSuccess);
        Print(fSharp);
    }
}