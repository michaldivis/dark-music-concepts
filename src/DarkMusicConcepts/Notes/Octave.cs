namespace DarkMusicConcepts.Notes;

/// <summary>
/// <para>Octaves in westerns music are named: Sub-Contra, Contra, Great, Small, One-Line, Two-Line, Three-Line, Four-Line, Five-Line and Six-Line. </para>
/// <para>Octaves can also be represented as numbers: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9  The neutral octave, is the <see cref="OneLine"/> or 4 octave, meaning its the octave that does not change the note pitch.</para>
/// <para>Its usual to represent a note at an octave using the number notation for octaves so an A4 means an A note at OneLine octave.</para>
/// <para>Instruments have what is called a range.This is the number of octaves an instrument can play (<see href="http://en.wikipedia.org/wiki/Instrument_range"/>). When composing a song for an instrument the comp[oser must be aware of the instrument range so that all nothes can be played by the instrument.</para>
/// </summary>
public enum Octave
{
    SubContra = 0,
    Contra = 1,
    Great = 2,
    Small = 3,
    OneLine = 4,
    TwoLine = 5,
    ThreeLine = 6,
    FourLine = 7,
    FiveLine = 8,
    SixLine = 9
}
