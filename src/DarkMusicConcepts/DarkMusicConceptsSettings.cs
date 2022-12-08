namespace DarkMusicConcepts;

public class DarkMusicConceptsSettings
{
    /// <summary>
    /// <para>Defines the octave of middle C (MIDI number 60) for MIDI number calculation. The MIDI standard only says that the note number 60 is a C, it does not say of which octave. More about that here: <see href="https://studiocode.dev/resources/midi-middle-c/"/></para>
    /// <para>Default value is <see cref="Octave.Four"/></para>
    /// </summary>
    public Octave MidiMiddleCOctave { get; init; } = Octave.Four;
}