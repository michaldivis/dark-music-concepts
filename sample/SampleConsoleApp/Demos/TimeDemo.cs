using DarkMusicConcepts.Units;

namespace SampleConsoleApp.Demos;
internal class TimeDemo : Demo
{
    public override void Run()
    {
        PrintHeader("Time");

        Print(Time.QuarterNote);
        Print(Time.WholeNote);
        Print(Time.Bar);
        Print(Time.QuarterNote.GetDuration(Bpm.From(155)));
        Print(Time.QuarterNote.Ticks);
        Print(Time.QuarterNote * 3);
    }
}
