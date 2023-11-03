namespace DarkMusicConcepts;

/// <summary>
/// <para>MIDI velocity indicates how hard the key was struck when the note was played, which usually corresponds to the note's loudness.</para>
/// <para>The MIDI velocity range is from 0–127, with 127 being the loudest.</para>
/// </summary>
public class MidiVelocity : Unit<int, MidiVelocity>
{
    public const int MinValue = 0;
    public const int MaxValue = 127;

    public static MidiVelocity Min { get; } = From(MinValue);
    public static MidiVelocity Max { get; } = From(MaxValue);

    private MidiVelocity(int value) : base(value)
    {
    }

    protected override int GetMinValue() => MinValue;
    protected override int GetMaxValue() => MaxValue;

    public static MidiVelocity From(int value)
    {
        var midiVelocity = new MidiVelocity(value);

        midiVelocity.Validate();

        return midiVelocity;
    }

    public static bool TryFrom(int value, out MidiVelocity midiVelocity)
    {
        midiVelocity = new MidiVelocity(value);

        return midiVelocity.TryValidate();
    }
}