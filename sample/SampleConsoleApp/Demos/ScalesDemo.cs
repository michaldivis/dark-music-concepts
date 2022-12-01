using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Scales;

namespace SampleConsoleApp.Demos;

internal class ScalesDemo : Demo
{
    public override void Run()
    {
        PrintHeader("Scales");

        var gPhrygian = ScaleFormulas.Phrygian.Create(Pitch.G);

        Print(gPhrygian);
        PrintCollection(gPhrygian.Pitches, false);
        Print(gPhrygian.IV);
    }
}