using DarkMusicConcepts.NewNoteNaming.Extensions;

namespace DarkMusicConcepts.NewNoteNaming.Intervals;

public static class IntervalDetectionTool
{
    private static readonly Dictionary<(IntervalQuantity, int), IntervalQuality> nameAndSemitonesToIntervalQualities = new()
    {
        [(WellKnownIntervalQuantities.Unison, 0)] = IntervalQuality.Perfect,
        //second
        [(WellKnownIntervalQuantities.Second, 1)] = IntervalQuality.Minor,
        [(WellKnownIntervalQuantities.Second, 2)] = IntervalQuality.Major,
        [(WellKnownIntervalQuantities.Second, 3)] = IntervalQuality.Augmented,
        //third
        [(WellKnownIntervalQuantities.Third, 3)] = IntervalQuality.Minor,
        [(WellKnownIntervalQuantities.Third, 4)] = IntervalQuality.Major,
        [(WellKnownIntervalQuantities.Third, 5)] = IntervalQuality.Augmented,
        //fourth
        [(WellKnownIntervalQuantities.Fourth, 4)] = IntervalQuality.Diminished,
        [(WellKnownIntervalQuantities.Fourth, 5)] = IntervalQuality.Perfect,
        [(WellKnownIntervalQuantities.Fourth, 6)] = IntervalQuality.Augmented,
        //fifth
        [(WellKnownIntervalQuantities.Fifth, 6)] = IntervalQuality.Diminished,
        [(WellKnownIntervalQuantities.Fifth, 7)] = IntervalQuality.Perfect,
        [(WellKnownIntervalQuantities.Fifth, 8)] = IntervalQuality.Augmented,
        //sixth
        [(WellKnownIntervalQuantities.Sixth, 7)] = IntervalQuality.Diminished,
        [(WellKnownIntervalQuantities.Sixth, 8)] = IntervalQuality.Minor,
        [(WellKnownIntervalQuantities.Sixth, 9)] = IntervalQuality.Major,
        //seventh
        [(WellKnownIntervalQuantities.Seventh, 9)] = IntervalQuality.Diminished,
        [(WellKnownIntervalQuantities.Seventh, 10)] = IntervalQuality.Minor,
        [(WellKnownIntervalQuantities.Seventh, 11)] = IntervalQuality.Major,
        //octave
        [(WellKnownIntervalQuantities.Octave, 11)] = IntervalQuality.Diminished,
        [(WellKnownIntervalQuantities.Octave, 12)] = IntervalQuality.Perfect,
        [(WellKnownIntervalQuantities.Octave, 13)] = IntervalQuality.Augmented
        //todo: add full set of intervals up to two octaves
    };

    public static IntervalQuantity FindQuantityWithinOctave(Pitch.Pitch lowerPitch, Pitch.Pitch upperPitch)
    {
        if (upperPitch.Step == lowerPitch.Step)
            return WellKnownIntervalQuantities.Unison;

        var steps = ((byte)upperPitch.Step - (byte)lowerPitch.Step + 7) % 7;

        return steps switch
        {
            1 => WellKnownIntervalQuantities.Second,
            2 => WellKnownIntervalQuantities.Third,
            3 => WellKnownIntervalQuantities.Fourth,
            4 => WellKnownIntervalQuantities.Fifth,
            5 => WellKnownIntervalQuantities.Sixth,
            6 => WellKnownIntervalQuantities.Seventh,
            0 => WellKnownIntervalQuantities.Octave,
            // Add more cases as needed
            _ => throw new NotImplementedException("Interval calculation not implemented for the given steps.")
        };
    }

    public static IntervalQuality FindQuality(IntervalQuantity intervalQuantity, int semitones)
    {
        var searchKey = (intervalQuantity, semitones);
        if (!nameAndSemitonesToIntervalQualities.ContainsKey(searchKey))
            throw new ArgumentOutOfRangeException();

        return nameAndSemitonesToIntervalQualities[searchKey];
    }

    public static IntervalFormula FindFormula(Pitch.Pitch lowerPitch, Pitch.Pitch upperPitch)
    {
        var quantityWithinOctave = FindQuantityWithinOctave(lowerPitch, upperPitch);
        var diffSemitones = GetDiffSemitones(lowerPitch, upperPitch);
        var quality = FindQuality(quantityWithinOctave, diffSemitones);

        return new IntervalFormula(quality, quantityWithinOctave);
    }

    public static int GetDiffSemitones(Pitch.Pitch first, Pitch.Pitch second)
    {
        var upperMidiNote = second.CalculateMidiNote();
        var lowerMidiNote = first.CalculateMidiNote();
        return Math.Abs(upperMidiNote - lowerMidiNote);
    }
}
