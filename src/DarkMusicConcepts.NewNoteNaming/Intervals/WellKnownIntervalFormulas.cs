namespace DarkMusicConcepts.NewNoteNaming.Intervals;

public class WellKnownIntervalFormulas
{
    public static IntervalFormula PerfectUnison = new(IntervalQuality.Perfect, WellKnownIntervalQuantities.Unison);
    public static IntervalFormula MinorSecond = new(IntervalQuality.Minor, WellKnownIntervalQuantities.Second);
    public static IntervalFormula MajorSecond = new(IntervalQuality.Major, WellKnownIntervalQuantities.Second);
    public static IntervalFormula MinorThird = new(IntervalQuality.Minor, WellKnownIntervalQuantities.Third);
    public static IntervalFormula MajorThird = new(IntervalQuality.Major, WellKnownIntervalQuantities.Third);
    public static IntervalFormula DiminishedFourth = new(IntervalQuality.Diminished, WellKnownIntervalQuantities.Fourth);
    public static IntervalFormula PerfectFourth = new(IntervalQuality.Perfect, WellKnownIntervalQuantities.Fourth);
    public static IntervalFormula AugmentedFourth = new(IntervalQuality.Augmented, WellKnownIntervalQuantities.Fourth);
    public static IntervalFormula DiminishedFifth = new(IntervalQuality.Diminished, WellKnownIntervalQuantities.Fifth);
    public static IntervalFormula PerfectFifth = new(IntervalQuality.Perfect, WellKnownIntervalQuantities.Fifth);
    public static IntervalFormula MinorSixth = new(IntervalQuality.Minor, WellKnownIntervalQuantities.Sixth);
    public static IntervalFormula MajorSixth = new(IntervalQuality.Major, WellKnownIntervalQuantities.Sixth);
    public static IntervalFormula MinorSeventh = new(IntervalQuality.Minor, WellKnownIntervalQuantities.Seventh);
    public static IntervalFormula MajorSeventh = new(IntervalQuality.Major, WellKnownIntervalQuantities.Seventh);
    public static IntervalFormula PerfectOctave = new(IntervalQuality.Perfect, WellKnownIntervalQuantities.Octave);
    public static IntervalFormula MinorNinth = new(IntervalQuality.Minor, WellKnownIntervalQuantities.Ninth);
    public static IntervalFormula MajorNinth = new(IntervalQuality.Major, WellKnownIntervalQuantities.Ninth);
}
