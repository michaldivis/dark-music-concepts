namespace DarkMusicConcepts;

/// <summary>
/// <para>MIDI velocity indicates how hard the key was struck when the note was played, which usually corresponds to the note's loudness.</para>
/// <para>The MIDI velocity range is from 0–127, with 127 being the loudest.</para>
/// </summary>
public class MidiVelocity : Unit<int, MidiVelocity>, IUnit<int, MidiVelocity>
{
    public static int MinValue { get; } = 0;
    public static int MaxValue { get; } = 127;

    private MidiVelocity(int value) : base(value)
    {
    }

    static MidiVelocity IUnit<int, MidiVelocity>.Create(int value) => new(value);
}
