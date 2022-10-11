namespace DarkMusicConcepts.Units;

/// <summary>
/// <para>MIDI velocity indicates how hard the key was struck when the note was played, which usually corresponds to the note's loudness.</para>
/// <para>The MIDI velocity range is from 0–127, with 127 being the loudest.</para>
/// </summary>
public class MidiVelocity : Unit<int, MidiVelocity>
{
    public const int Min = 0;
    public const int Max = 127;

    protected override int MinValue { get; } = Min;
    protected override int MaxValue { get; } = Max;
}