namespace DarkMusicConcepts;

/// <summary>
/// <para>MIDI number of a note.</para>
/// <para>In MIDI, each note is assigned a numeric value, which is transmitted with any Note-On/Off message. Middle C has a reference value of 60. The MIDI standard only says that the note number 60 is a C, it does not say of which octave.</para>
/// <para>Due to the limitation of MIDI number's range (0-127), not all existing notes can be assigned one. There are more than 128 notes.</para>
/// </summary>
public class MidiNumber : Unit<int, MidiNumber>, IUnit<int, MidiNumber>
{
    public static int MinValue { get; } = 0;
    public static int MaxValue { get; } = 127;

    private MidiNumber(int value) : base(value)
    {
    }

    static MidiNumber IUnit<int, MidiNumber>.Create(int value) => new(value);
}
