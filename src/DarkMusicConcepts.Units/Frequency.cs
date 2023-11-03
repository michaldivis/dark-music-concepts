namespace DarkMusicConcepts;

/// <summary>
/// <para>A frequency of a note in Herz.</para>
/// <para>A musical note emits a sound. Sound is a wave measured using its frequency (<see href="http://en.wikipedia.org/wiki/Frequency"/>). Hertz is the unit used to measure frequency of waves. If we want our Note to emit a sound we need to add a frequency value to it. Octaves affect frequency by doubling it or dividing it by two. So far we defined sound as pitch, but in reality pitch is more of a sound id. Frequency is the real sound.</para>
/// <para>Note frequencies are mathematically related to each other, and are defined around the central note, A4 (A @ OneLine octave) <see href="http://en.wikipedia.org/wiki/Piano_key_frequencies"/>. The current "standard pitch" or modern "concert pitch" for this note is 440 Hz. The formula for frequency calculatio is:</para>
/// <para>f = 2^n/12 * 440Hz(n is the pitch distance to A4 or A @ OneLine).</para>
/// </summary>
public class Frequency : Unit<double, Frequency>
{
    public const double MinValue = 0;
    public const double MaxValue = double.MaxValue;

    public static Frequency Min { get; } = From(MinValue);
    public static Frequency Max { get; } = From(MaxValue);

    private Frequency(double value) : base(value)
    {
    }

    protected override double GetMinValue() => MinValue;
    protected override double GetMaxValue() => MaxValue;

    public override string ToString()
    {
        return $"{Value} Hz";
    }

    public static Frequency From(double value)
    {
        var frequency = new Frequency(value);

        frequency.Validate();

        return frequency;
    }

    public static bool TryFrom(double value, out Frequency frequency)
    {
        var x = new Frequency(value);

        frequency = x.TryValidate()
            ? x
            : null!;

        return frequency is not null;
    }
}
