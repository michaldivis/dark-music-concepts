namespace DarkMusicConcepts.Scales;

public partial class ScaleFormula
{
    private readonly IEnumerable<Interval> _intervals;

    private ScaleFormula(params Interval[] intervals)
    {
        _intervals = intervals;
    }

    public Scale CreateForRoot(NotePitch root)
    {
        return Scale.Create(_intervals.Select(interval => NoteUtils.TransposePitch(root, interval)));
    }
}
