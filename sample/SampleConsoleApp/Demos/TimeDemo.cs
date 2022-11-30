using DarkMusicConcepts.Units;

namespace SampleConsoleApp.Demos;
internal class TimeDemo : Demo
{
    public override void Run()
    {
        PrintHeader("Time");
        var durationTime = Time.QuarterNote.GetDuration(Bpm.From(155));
        var midiTicks = Time.QuarterNote.Ticks;
        var threeQuarterNotes = Time.QuarterNote * 3;

        Print(Time.QuarterNote);
        Print(Time.WholeNote);
        Print(Time.Bar);
        Print(durationTime);
        Print(midiTicks);
        Print(threeQuarterNotes);
    }
}
