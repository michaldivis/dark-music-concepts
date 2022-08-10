namespace DarkMusicConcepts.Scales;

public partial class ScaleFormula
{
    private readonly IEnumerable<Interval> _intervals;

    public string Name { get; }

    private ScaleFormula(string name, params Interval[] intervals)
    {
        Name = name;
        _intervals = intervals;
    }

    public Scale CreateForRoot(Pitch root)
    {
        return Scale.Create(root, Name, _intervals.Select(interval => NoteUtils.TransposePitch(root, interval)));
    }

    public override string ToString()
    {
        return Name;
    }
}
