namespace DarkMusicConcepts.Units;

/// <summary>
/// <para>MIDI number of a note.</para>
/// <para>In MIDI, each note is assigned a numeric value, which is transmitted with any Note-On/Off message. Middle C has a reference value of 60. The MIDI standard only says that the note number 60 is a C, it does not say of which octave.</para>
/// <para>Due to the limitation of MIDI number's range (0-127), not all existing notes can be assigned one. There are more than 128 notes.</para>
/// </summary>
public class MidiNumber : Unit<int, MidiNumber>
{
    public const int Min = 0;
    public const int Max = 127;

    protected override int MinValue { get; } = Min;
    protected override int MaxValue { get; } = Max;
}
