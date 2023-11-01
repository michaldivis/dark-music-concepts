namespace DarkMusicConcepts;

/// <summary>
/// The pitches of all chords known in the library, with their respective chord formulas and root pitches.
/// </summary>
public static class ChordPitchesDefinitions
{
    public static IReadOnlyList<ChordPitchesDefinition> All { get; } = GetAll();

    private static IReadOnlyList<ChordPitchesDefinition> GetAll()
    {
        var allChordPitches = new List<ChordPitchesDefinition>();

        foreach (var pitch in Enum.GetValues<Pitch>())
        {
            foreach (var chordFormula in ChordFormulas.All)
            {
                var chordPitches = new List<Pitch>();

                var bass = Note.Create(pitch, Octave.Two);

                chordPitches.Add(bass.BasePitch);

                foreach (var interval in chordFormula.Intervals)
                {
                    var note = bass.TransposeUp(interval);
                    chordPitches.Add(note.BasePitch);
                }

                allChordPitches.Add(new(pitch, chordFormula, chordPitches));
            }
        }

        return allChordPitches;
    }
}
