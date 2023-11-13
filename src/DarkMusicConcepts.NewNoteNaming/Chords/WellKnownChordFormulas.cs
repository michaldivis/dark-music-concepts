using DarkMusicConcepts.NewNoteNaming.Intervals;

namespace DarkMusicConcepts.NewNoteNaming.Chords;

public static class WellKnownChordFormulas
{
    public static class Triads
    {
        public static ChordFormula MajorRootPosition = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.MajorThird, WellKnownIntervalFormulas.MinorThird }
        };

        public static ChordFormula MajorFirstInversion = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.MinorThird, WellKnownIntervalFormulas.PerfectFourth }
        };

        public static ChordFormula MajorSecondInversion = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.PerfectFourth, WellKnownIntervalFormulas.MajorThird }
        };

        public static ChordFormula MinorRootPosition = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.MinorThird, WellKnownIntervalFormulas.MajorThird }
        };

        public static ChordFormula MinorFirstInversion = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.MajorThird, WellKnownIntervalFormulas.PerfectFourth }
        };

        public static ChordFormula MinorSecondInversion = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.PerfectFourth, WellKnownIntervalFormulas.MinorThird }
        };

        public static ChordFormula DiminishedRootPosition = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.MinorThird, WellKnownIntervalFormulas.MinorThird }
        };

        public static ChordFormula DiminishedFirstInversion = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.MinorThird, WellKnownIntervalFormulas.DiminishedFifth }
        };

        public static ChordFormula DiminishedSecondInversion = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.DiminishedFifth, WellKnownIntervalFormulas.MinorThird }
        };

        public static ChordFormula AugmentedRootPosition = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.MajorThird, WellKnownIntervalFormulas.MajorThird }
        };

        public static ChordFormula AugmentedFirstInversion = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.MajorThird, WellKnownIntervalFormulas.DiminishedFourth }
        };

        public static ChordFormula AugmentedSecondInversion = new()
        {
            Intervals = new[] { WellKnownIntervalFormulas.DiminishedFourth, WellKnownIntervalFormulas.MajorThird }
        };
    }

    public static class Seventh
    {
        public static ChordFormula DominantRootPosition = new()
        {
            Intervals = new[]
            {
                WellKnownIntervalFormulas.MajorThird, WellKnownIntervalFormulas.MinorThird, WellKnownIntervalFormulas.MinorThird
            }
        };

        public static ChordFormula DominantFirstInversion = new()
        {
            Intervals = new[]
            {
                WellKnownIntervalFormulas.MinorThird, WellKnownIntervalFormulas.MinorThird, WellKnownIntervalFormulas.MajorSecond
            }
        };

        public static ChordFormula DominantSecondInversion = new()
        {
            Intervals = new[]
            {
                WellKnownIntervalFormulas.MinorThird, WellKnownIntervalFormulas.MajorSecond, WellKnownIntervalFormulas.MajorThird
            }
        };

        public static ChordFormula DominantThirdInversion = new()
        {
            Intervals = new[]
            {
                WellKnownIntervalFormulas.MajorSecond, WellKnownIntervalFormulas.MajorThird, WellKnownIntervalFormulas.MinorThird
            }
        };

        //todo: add more common academic seventh chords here
    }
}
