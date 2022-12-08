using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Scales;

namespace DarkMusicConcepts.Chords;

public class ChordProgressionTests
{
    [Fact]
    public void Create_ShouldThrow_WhenNodesNull()
    {
        var act = () => ChordProgression.Create(null!);
        _ = act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Create_ShouldThrow_WhenNodesEmpty()
    {
        var act = () => ChordProgression.Create(Array.Empty<ScaleDegree>());
        _ = act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GetChords_ShouldWork()
    {
        var cMajorScale = ScaleFormulas.Ionian.Create(Pitch.C);
        var chords = ChordProgressions.Pop.I_IV_V_IV.GetChords(cMajorScale, Octave.Three);

        chords[0].Notes.Should().BeEquivalentTo(new[] { Notes.Notes.C3, Notes.Notes.E3, Notes.Notes.G3 });
        chords[1].Notes.Should().BeEquivalentTo(new[] { Notes.Notes.F3, Notes.Notes.A3, Notes.Notes.C4 });
        chords[2].Notes.Should().BeEquivalentTo(new[] { Notes.Notes.G3, Notes.Notes.B3, Notes.Notes.D4 });
        chords[3].Notes.Should().BeEquivalentTo(new[] { Notes.Notes.F3, Notes.Notes.A3, Notes.Notes.C4 });
    }
}