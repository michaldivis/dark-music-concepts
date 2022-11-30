namespace DarkMusicConcepts.Scales;

public class ScaleFormula
{
    private readonly Interval[] _intervals;

    public string Name { get; }

    internal ScaleFormula(string name, params Interval[] intervals)
    {
        Name = name;
        _intervals = intervals;
    }

    public Scale CreateForRoot(Pitch root)
    {
        return Scale.Create(root, this, _intervals.Select(interval => NoteUtils.TransposePitch(root, interval)));
    }

    public override string ToString()
    {
        return Name;
    }
}
