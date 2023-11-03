namespace DarkMusicConcepts;

public class Bpm : Unit<double, Bpm>
{
    public const double MinValue = 0;
    public const double MaxValue = double.MaxValue;

    public static Bpm Min { get; } = From(MinValue);
    public static Bpm Max { get; } = From(MaxValue);

    private Bpm(double value) : base(value)
    {        
    }

    protected override double GetMinValue() => MinValue;
    protected override double GetMaxValue() => MaxValue;

    public static Bpm From(double value)
    {
        var bpm = new Bpm(value);

        bpm.Validate();

        return bpm;
    }

    public static bool TryFrom(double value, out Bpm bpm)
    {
        var x = new Bpm(value);

        bpm = x.TryValidate()
            ? x
            : null!;

        return bpm is not null;
    }
}