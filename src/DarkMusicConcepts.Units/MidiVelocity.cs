using ValueOf;

namespace DarkMusicConcepts.Units;

/// <summary>
/// <para>MIDI velocity indicates how hard the key was struck when the note was played, which usually corresponds to the note's loudness.</para>
/// <para>The MIDI velocity range is from 0–127, with 127 being the loudest.</para>
/// </summary>
public class MidiVelocity : ValueOf<int, MidiVelocity>
{
    public const int Min = 0;
    public const int Max = 127;

    protected override void Validate()
    {
        if (!IsValidMidiVelocityValue(Value))
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, $"{nameof(Value)} has to be within range {Min}-{Max}");
        }
    }

    protected override bool TryValidate()
    {
        return IsValidMidiVelocityValue(Value);
    }

    private static bool IsValidMidiVelocityValue(int velocity)
    {
        return velocity >= Min && velocity <= Max;
    }

    public static implicit operator MidiVelocity(int value)
    {
        return From(value);
    }

    public static bool operator ==(MidiVelocity velocity1, int velocity2)
    {
        if (velocity1 is null)
        {
            return false;
        }

        return velocity1.Value == velocity2;
    }

    public static bool operator !=(MidiVelocity velocity1, int velocity2)
    {
        return !(velocity1 == velocity2);
    }

    public static bool operator ==(int velocity1, MidiVelocity velocity2)
    {
        if (velocity2 is null)
        {
            return false;
        }

        return velocity2.Value == velocity1;
    }

    public static bool operator !=(int velocity1, MidiVelocity velocity2)
    {
        return !(velocity2 == velocity1);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MidiVelocity);
    }

    public bool Equals(MidiVelocity? other)
    {
        if (other is not null)
        {
            return Value == other!.Value;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}