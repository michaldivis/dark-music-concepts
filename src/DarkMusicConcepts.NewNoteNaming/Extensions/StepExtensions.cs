using System.Diagnostics;

namespace DarkMusicConcepts.NewNoteNaming.Extensions;

public static class StepExtensions
{
    public static int GetStepValue(this Step step)
    {
        return step switch
        {
            Step.C => 0,
            Step.D => 2,
            Step.E => 4,
            Step.F => 5,
            Step.G => 7,
            Step.A => 9,
            Step.B => 11,
            _ => throw new ArgumentOutOfRangeException(nameof(step), step, null)
        };
    }
}
