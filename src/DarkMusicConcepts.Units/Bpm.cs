namespace DarkMusicConcepts;

public class Bpm : Unit<double, Bpm>
{
    public const double MinValue = 0;
    public const double MaxValue = double.MaxValue;

    public static Bpm Min { get; } = From(MinValue);
    public static Bpm Max { get; } = From(MaxValue);

    protected override double GetMinValue() => MinValue;
    protected override double GetMaxValue() => MaxValue;
}
