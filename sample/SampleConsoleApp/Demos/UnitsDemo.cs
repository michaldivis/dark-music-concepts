using DarkMusicConcepts;

namespace SampleConsoleApp.Demos;
internal class UnitsDemo : Demo
{
    public override void Run()
    {
        PrintHeader("Units");

        PrintSubHeader("Overview");

        Print(MidiNumber.Min);
        Print(MidiNumber.Max);
        Print(MidiNumber.From(127));
        Print(MidiNumber.IsValidValue(666));
        Print(MidiNumber.From(127) > MidiNumber.From(60));
        Print(MidiNumber.From(127) >= MidiNumber.From(60));
        Print(MidiNumber.From(127) < MidiNumber.From(60));
        Print(MidiNumber.From(127) <= MidiNumber.From(60));

        PrintSubHeader("Time");

        Print(Time.QuarterNote);
        Print(Time.WholeNote);
        Print(Time.Bar);
        Print(Time.QuarterNote.GetDuration(Bpm.From(155)));
        Print(Time.QuarterNote.Ticks);
        Print(Time.QuarterNote * 3);
        Print(Time.HalfNoteDotted + Time.Bar - (Time.SixteenthNote * 8));
    }
}
