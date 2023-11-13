using DarkMusicConcepts.NewNoteNaming.Exceptions;
using DarkMusicConcepts.NewNoteNaming.Extensions;

namespace DarkMusicConcepts.NewNoteNaming.Intervals;

using Pitch = Pitch.Pitch;

public class IntervalFactory
{
    public Interval Create(Pitch lowerPitch, Pitch upperPitch)
    {
        if (lowerPitch > upperPitch)
            throw new PitchRelationException();

        var formula = IntervalDetectionTool.FindFormula(lowerPitch, upperPitch);
        return new Interval(lowerPitch, upperPitch, formula);
    }
}
