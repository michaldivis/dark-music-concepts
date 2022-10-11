namespace DarkMusicConcepts.Units;

public class Bpm : Unit<int, Bpm>
{
    public const int Min = 0;
    public const int Max = int.MaxValue;

    protected override int MinValue { get; } = Min;
    protected override int MaxValue { get; } = Max;
}
