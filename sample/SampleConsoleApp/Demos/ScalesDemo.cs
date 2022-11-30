using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Scales;

namespace SampleConsoleApp.Demos;

internal class ScalesDemo : Demo
{
    public override void Run()
    {
        PrintHeader("Scales");

        var gPhrygian = ScaleFormulas.Phrygian.CreateForRoot(Pitch.G);
        var gPhrygianNotes = gPhrygian.Pitches;
        var gPhrygianFourth = gPhrygian.IV;

        Print(gPhrygian);
        Print(string.Join(", ", gPhrygianNotes));
        Print(gPhrygianFourth);
    }
}