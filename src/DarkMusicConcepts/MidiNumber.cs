using ValueOf;

namespace DarkMusicConcepts;

/// <summary>
/// <para>MIDI number of a note.</para>
/// <para>In MIDI, each note is assigned a numeric value, which is transmitted with any Note-On/Off message. Middle C has a reference value of 60. The MIDI standard only says that the note number 60 is a C, it does not say of which octave.</para>
/// <para>The octave of middle C can be configured using the <see cref="DarkMusicConceptsCore.Configure(DarkMusicConceptsSettings)"/> method to specify a custom <see cref="DarkMusicConceptsSettings.MidiMiddleCOctave"/> value. Default value is <see cref="Octave.OneLine"/></para>
/// </summary>
public class MidiNumber : ValueOf<int, MidiNumber>
{
    protected override void Validate()
    {
        if (Value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, "MIDI number cannot be negative");
        }

        //this validation is currently disabled because the library allows creating of notes from the 9th octave, which would reach MIDI numbers over 127
        //if (Value > 127)
        //{
        //    throw new ArgumentOutOfRangeException(nameof(Value), Value, "MIDI number cannot exceed 127");
        //}
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
