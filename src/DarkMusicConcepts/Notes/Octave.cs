namespace DarkMusicConcepts.Notes;

/// <summary>
/// <para>Octaves in westerns music are named: Sub-Contra, Contra, Great, Small, One-Line, Two-Line, Three-Line, Four-Line, Five-Line and Six-Line. </para>
/// <para>Octaves can also be represented as numbers: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9  The neutral octave, is the <see cref="Four"/> or 4 octave, meaning its the octave that does not change the note pitch.</para>
/// <para>Its usual to represent a note at an octave using the number notation for octaves so an A4 means an A note at OneLine octave.</para>
/// <para>Instruments have what is called a range.This is the number of octaves an instrument can play (<see href="http://en.wikipedia.org/wiki/Instrument_range"/>). When composing a song for an instrument the comp[oser must be aware of the instrument range so that all nothes can be played by the instrument.</para>
/// </summary>
public enum Octave
{
    /// <summary>
    /// Sub sub contra
    /// </summary>
    MinusOne = -1,
    /// <summary>
    /// Sub contra
    /// </summary>
    Zero = 0,
    /// <summary>
    /// Contra
    /// </summary>
    One = 1,
    /// <summary>
    /// Great
    /// </summary>
    Two = 2,
    /// <summary>
    /// Small
    /// </summary>
    Three = 3,
    /// <summary>
    /// One line
    /// </summary>
    Four = 4,
    /// <summary>
    /// Two line
    /// </summary>
    Five = 5,
    /// <summary>
    /// Three line
    /// </summary>
    Six = 6,
    /// <summary>
    /// Four line
    /// </summary>
    Seven = 7,
    /// <summary>
    /// Five line
    /// </summary>
    Eight = 8,
    /// <summary>
    /// Six line
    /// </summary>
    Nine = 9
}
