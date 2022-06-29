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

        if (Value > 127)
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, "MIDI number cannot exceed 127");
        }
    }

    public static implicit operator MidiNumber(int value) => From(value);
}
