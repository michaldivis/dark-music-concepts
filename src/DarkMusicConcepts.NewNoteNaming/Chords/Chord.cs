namespace DarkMusicConcepts.NewNoteNaming.Chords;

public class Chord
{
    public IReadOnlyList<Pitch.Pitch> Pitches { get; }
    public Pitch.Pitch Root { get; }
    public ChordFormula ChordFormula { get; }
    public int? Inversion { get; }
}
