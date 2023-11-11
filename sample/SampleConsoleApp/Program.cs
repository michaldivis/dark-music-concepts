using SampleConsoleApp.Demos;

var demos = new Demo[]
{
    new NotesDemo(),
    new IntervalsDemo(),
    new ScalesDemo(),
    new ChordsDemo(),
    new UnitsDemo()
};

foreach (var demo in demos)
{
    demo.Run();
}