﻿namespace DarkMusicConcepts;

public class ScaleFormula
{
    private readonly Interval[] _intervals;
    public IReadOnlyList<Interval> Intervals => _intervals;

    public string Name { get; }

    internal ScaleFormula(string name, params Interval[] intervals)
    {
        Name = name;
        _intervals = intervals;
    }

    public Scale Create(Pitch root)
    {
        return Scale.Create(root, this, _intervals.Select(interval => NoteUtils.TransposePitch(root, interval)));
    }

    public override string ToString()
    {
        return Name;
    }
}
