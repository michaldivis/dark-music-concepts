namespace DarkMusicConcepts.NewNoteNaming.Intervals;

public class Interval
{
    internal Interval(Pitch.Pitch lowerPitch, Pitch.Pitch upperPitch, IntervalFormula intervalFormula)
    {
        UpperPitch = upperPitch ?? throw new ArgumentNullException(nameof(upperPitch));
        LowerPitch = lowerPitch ?? throw new ArgumentNullException(nameof(lowerPitch));
        IntervalFormula = intervalFormula ?? throw new ArgumentNullException(nameof(intervalFormula));
    }

    public Pitch.Pitch UpperPitch { get; }
    public Pitch.Pitch LowerPitch { get; }
    public IntervalFormula IntervalFormula { get; }
}
