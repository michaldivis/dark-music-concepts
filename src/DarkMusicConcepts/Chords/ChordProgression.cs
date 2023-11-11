namespace DarkMusicConcepts;

public class ChordProgression
{
    public IReadOnlyList<ScaleDegree> ScaleDegrees { get; }
    public string Name { get; }
    
    internal ChordProgression(params ScaleDegree[] scaleDegrees)
    {
        ScaleDegrees = scaleDegrees;
        Name = GetName(scaleDegrees);
    }

    /// <summary>
    /// Create a chord progression
    /// </summary>
    /// <param name="scaleDegrees">The scale degrees to use</param>
    /// <returns>A chord progression</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static ChordProgression Create(params ScaleDegree[] scaleDegrees)
    {
        ArgumentNullException.ThrowIfNull(scaleDegrees);

        if (scaleDegrees.Length < 2)
        {
            throw new ArgumentException("Scale degrees must contain at least 2 elements", nameof(scaleDegrees));
        }

        return new ChordProgression(scaleDegrees);
    }

    /// <summary>
    /// Returns a set of chords based on the chord progression, scale and octave
    /// </summary>
    /// <param name="scale">The scale to use</param>
    /// <param name="octave">The octave to start chord root notes in</param>
    /// <returns>A set of chords</returns>
    public Chord[] GetChords(Scale scale, Octave octave)
    {
        var chords = new Chord[ScaleDegrees.Count];

        for (int i = 0; i < ScaleDegrees.Count; i++)
        {
            chords[i] = Chord.Create(scale, octave, ScaleDegrees[i]);
        }

        return chords;
    }

    private static string GetName(ScaleDegree[] scaleDegrees)
    {
        return string.Join('-', scaleDegrees); ;
    }

    public override string ToString()
    {
        return Name;
    }
}