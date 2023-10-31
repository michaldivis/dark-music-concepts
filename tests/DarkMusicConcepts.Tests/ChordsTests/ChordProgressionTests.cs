namespace DarkMusicConcepts.Tests.ChordTests;

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

        chords[0].Notes.Should().BeEquivalentTo(new[] { Notes.C3, Notes.E3, Notes.G3 });
        chords[1].Notes.Should().BeEquivalentTo(new[] { Notes.F3, Notes.A3, Notes.C4 });
        chords[2].Notes.Should().BeEquivalentTo(new[] { Notes.G3, Notes.B3, Notes.D4 });
        chords[3].Notes.Should().BeEquivalentTo(new[] { Notes.F3, Notes.A3, Notes.C4 });
    }
}