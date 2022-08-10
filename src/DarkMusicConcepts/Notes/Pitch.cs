namespace DarkMusicConcepts.Notes;

/// <summary>
/// <para>If you look at a piano keyboard you will notice that there are white and black keys. The notes C, D, E, F, G, A, B only represent the white keys, so how are black keys named. In fact each has two names so there are in reality twelve notes not seven C, C#/Db, D, D#/Eb, E, F, F#/Gb, G, G#/Ab, A, A#/Bb, B.</para>
/// <para>The "#" symbol is a "sharp" and the "b" symbol is a "flat". We call # and b accidentals.</para>
/// </summary>
public enum Pitch
{
    C = 0,
    CSharpOrDFlat = 1,
    D = 2,
    DSharpOrEFlat = 3,
    E = 4,
    F = 5,
    FSharpOrGFlat = 6,
    G = 7,
    GSharpOrAFlat = 8,
    A = 9,
    ASharpOrBFlat = 10,
    B = 11
}
