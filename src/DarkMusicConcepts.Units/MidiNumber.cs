using ValueOf;

namespace DarkMusicConcepts.Units;

/// <summary>
/// <para>MIDI number of a note.</para>
/// <para>In MIDI, each note is assigned a numeric value, which is transmitted with any Note-On/Off message. Middle C has a reference value of 60. The MIDI standard only says that the note number 60 is a C, it does not say of which octave.</para>
/// <para>Due to the limitation of MIDI number's range (0-127), not all existing notes can be assigned one. There are more than 128 notes.</para>
/// </summary>
public class MidiNumber : ValueOf<int, MidiNumber>
{
    public const int Min = 0;
    public const int Max = 127;

    protected override void Validate()
    {
        if (Value < Min)
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, $"MIDI number cannot be smaller than {Min}");
        }

        if (Value > Max)
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, $"MIDI number cannot exceed {Max}");
        }
    }

    protected override bool TryValidate()
    {
        if (Value < Min)
        {
            return false;
        }

        if (Value > Max)
        {
            return false;
        }

        return true;
    }

    public static implicit operator MidiNumber(int value) => From(value);

    public static bool operator ==(MidiNumber number1, int number2)
    {
        if (number1 is null)
        {
            return false;
        }

        return number1.Value == number2;
    }

    public static bool operator !=(MidiNumber number1, int number2)
    {
        return !(number1 == number2);
    }

    public static bool operator ==(int number1, MidiNumber number2)
    {
        if (number2 is null)
        {
            return false;
        }

        return number2.Value == number1;
    }

    public static bool operator !=(int number1, MidiNumber number2)
    {
        return !(number2 == number1);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MidiNumber);
    }

    public bool Equals(MidiNumber? other)
    {
        return other is not null && Value == other.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}
