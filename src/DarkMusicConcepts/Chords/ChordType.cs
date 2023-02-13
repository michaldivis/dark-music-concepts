namespace DarkMusicConcepts;

public enum ChordType
{
    /// <summary>
    /// Chords built using intervals of three scale degrees, such as major and minor triads and seventh chords.
    /// </summary>
    Tertian,
    /// <summary>
    /// Chords built using intervals of four scale degrees, such as perfect fourths and augmented fourths.
    /// </summary>
    Quartal,
    /// <summary>
    /// Chords built using intervals of five scale degrees, such as perfect fifths and augmented fifths.
    /// </summary>
    Quintal,
    /// <summary>
    /// Chords built using intervals of six scale degrees, such as major and minor sixths.
    /// </summary>
    Sextal,
    /// <summary>
    /// Chords built using intervals of seven scale degrees, such as major and minor sevenths.
    /// </summary>
    Septimal
}