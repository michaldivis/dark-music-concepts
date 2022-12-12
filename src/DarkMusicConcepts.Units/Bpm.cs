namespace DarkMusicConcepts;

public class Bpm : Unit<int, Bpm>
{
    public const int MinValue = 0;
    public const int MaxValue = int.MaxValue;

    public static Bpm Min { get; } = From(MinValue);
    public static Bpm Max { get; } = From(MaxValue);

    protected override int GetMinValue() => MinValue;
    protected override int GetMaxValue() => MaxValue;
}
