namespace DarkMusicConcepts;

/// <summary>
/// <para>A frequency of a note in Herz.</para>
/// <para>A musical note emits a sound. Sound is a wave measured using its frequency (<see href="http://en.wikipedia.org/wiki/Frequency"/>). Hertz is the unit used to measure frequency of waves. If we want our Note to emit a sound we need to add a frequency value to it. Octaves affect frequency by doubling it or dividing it by two. So far we defined sound as pitch, but in reality pitch is more of a sound id. Frequency is the real sound.</para>
/// <para>Note frequencies are mathematically related to each other, and are defined around the central note, A4 (A @ OneLine octave) <see href="http://en.wikipedia.org/wiki/Piano_key_frequencies"/>. The current "standard pitch" or modern "concert pitch" for this note is 440 Hz. The formula for frequency calculatio is:</para>
/// <para>f = 2^n/12 * 440Hz(n is the pitch distance to A4 or A @ OneLine).</para>
/// </summary>
public class Frequency : Unit<double, Frequency>, IUnit<double, Frequency>
{
    public static double MinValue { get; } = 0;
    public static double MaxValue { get; } = double.MaxValue;

    private Frequency(double value) : base(value)
    {
    }

    static Frequency IUnit<double, Frequency>.Create(double value) => new(value);

    public override string ToString() => $"{Value} Hz";
}
