namespace DarkMusicConcepts;

public record ChordPitchesDefinition(Pitch RootPitch, ChordFormula ChordFormula, IReadOnlyList<Pitch> Pitches);