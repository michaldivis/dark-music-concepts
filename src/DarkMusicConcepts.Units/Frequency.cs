using ValueOf;

namespace DarkMusicConcepts.Units;

/// <summary>
/// <para>A frequency of a note in Herz.</para>
/// <para>A musical note emits a sound. Sound is a wave measured using its frequency (<see href="http://en.wikipedia.org/wiki/Frequency"/>). Hertz is the unit used to measure frequency of waves. If we want our Note to emit a sound we need to add a frequency value to it. Octaves affect frequency by doubling it or dividing it by two. So far we defined sound as pitch, but in reality pitch is more of a sound id. Frequency is the real sound.</para>
/// <para>Note frequencies are mathematically related to each other, and are defined around the central note, A4 (A @ OneLine octave) <see href="http://en.wikipedia.org/wiki/Piano_key_frequencies"/>. The current "standard pitch" or modern "concert pitch" for this note is 440 Hz. The formula for frequency calculatio is:</para>
/// <para>f = 2^n/12 * 440Hz(n is the pitch distance to A4 or A @ OneLine).</para>
/// </summary>
public class Frequency : ValueOf<double, Frequency>
{
    public const double Min = 0;
    public const double Max = double.MaxValue;

    protected override void Validate()
    {
        if (!IsValidFrequencyValue(Value))
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, $"{nameof(Value)} has to be within range {Min}-{Max}");
        }
    }

    protected override bool TryValidate()
    {
        return IsValidFrequencyValue(Value);
    }

    private static bool IsValidFrequencyValue(double frequency)
    {
        return frequency >= Min && frequency <= Max;
    }

    public static implicit operator Frequency(double value) => From(value);

    public override string ToString()
    {
        return $"{Value} Hz";
    }

    public static bool operator ==(Frequency frequency1, double frequency2)
    {
        if (frequency1 is null)
        {
            return false;
        }

        return frequency1.Value == frequency2;
    }

    public static bool operator !=(Frequency frequency1, double frequency2)
    {
        return !(frequency1 == frequency2);
    }

    public static bool operator ==(double frequency1, Frequency frequency2)
    {
        if (frequency2 is null)
        {
            return false;
        }

        return frequency2.Value == frequency1;
    }

    public static bool operator !=(double frequency1, Frequency frequency2)
    {
        return !(frequency2 == frequency1);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Frequency);
    }

    public bool Equals(Frequency? other)
    {
        return other is not null && Value == other.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}
