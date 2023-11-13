using DarkMusicConcepts.NewNoteNaming.Intervals;

namespace DarkMusicConcepts.NewNoteNaming.Chords;

public class ChordFormula
{
    public string Name { get; internal set; }

    public IReadOnlyList<IntervalFormula> Intervals { get; internal set; }
}
