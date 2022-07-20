using DarkMusicConcepts.Notes;

namespace DarkMusicConcepts;

public static class DarkMusicConceptsCore
{
    /// <summary>
    /// <para>Defines the octave of middle C (MIDI number 60) for MIDI number calculation. The MIDI standard only says that the note number 60 is a C, it does not say of which octave. More about that here: <see href="https://studiocode.dev/resources/midi-middle-c/"/></para>
    /// <para>Default value is <see cref="Octave.OneLine"/></para>
    /// </summary>
    public static Octave MidiMiddleCOctave { get; private set; } = Octave.OneLine;

    public static void Configure(DarkMusicConceptsSettings settings)
    {
        MidiMiddleCOctave = settings.MidiMiddleCOctave;
    }
}
