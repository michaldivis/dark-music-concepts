using FluentAssertions;

namespace DarkMusicConcepts;

public class NoteTests
{
    public NoteTests()
    {
        DarkMusicConceptsCore.Configure(new DarkMusicConceptsSettings
        {
            MidiMiddleCOctave = Octave.OneLine //middle C = C4
        });
    }

    [Theory]
    [InlineData(NotePitch.C, Octave.SubContra, 12)]
    [InlineData(NotePitch.D, Octave.Contra, 26)]
    [InlineData(NotePitch.A, Octave.OneLine, 69)]
    [InlineData(NotePitch.B, Octave.FourLine, 107)]
    [InlineData(NotePitch.G, Octave.SixLine, 127)]
    public void MidiNumber_Tests(NotePitch notePitch, Octave octave, int expectedMidiNumber)
    {
        var note = new Note(notePitch, octave);
        note.MidiNumber.Value.Should().Be(expectedMidiNumber);
    }

    [Theory]
    [InlineData(NotePitch.C, Octave.SubContra, 16.35)]
    [InlineData(NotePitch.G, Octave.SubContra, 24.50)]
    [InlineData(NotePitch.E, Octave.Contra, 41.20)]
    [InlineData(NotePitch.CSharp, Octave.Great, 69.30)]
    [InlineData(NotePitch.F, Octave.Small, 174.61)]
    [InlineData(NotePitch.A, Octave.OneLine, 440.00)]
    [InlineData(NotePitch.E, Octave.TwoLine, 659.25)]
    [InlineData(NotePitch.B, Octave.ThreeLine, 1975.53)]
    [InlineData(NotePitch.A, Octave.FiveLine, 7040.00)]
    public void Frequency_Tests(NotePitch notePitch, Octave octave, double expectedFrequency)
    {
        var note = new Note(notePitch, octave);
        note.Frequency.Value.Should().BeApproximately(expectedFrequency, 0.01d);
    }

    [Fact]
    public void ComparisonEqualsOperator_ShouldBeTrue_WhenPitchAndOctaveAreEqual()
    {
        var note1 = new Note(NotePitch.C, Octave.Contra);
        var note2 = new Note(NotePitch.C, Octave.Contra);
        var areEqual = note1 == note2;
        areEqual.Should().BeTrue();
    }

    [Fact]
    public void ComparisonEqualsOperator_ShouldBeFalse_WhenPitchAndOctaveAreNotEqual()
    {
        var note1 = new Note(NotePitch.C, Octave.Contra);
        var note2 = new Note(NotePitch.D, Octave.OneLine);
        var areEqual = note1 == note2;
        areEqual.Should().BeFalse();
    }

    [Fact]
    public void ComparisonEquals_ShouldBeTrue_WhenPitchAndOctaveAreEqual()
    {
        var note1 = new Note(NotePitch.C, Octave.Contra);
        var note2 = new Note(NotePitch.C, Octave.Contra);
        var areEqual = note1.Equals(note2);
        areEqual.Should().BeTrue();
    }

    [Fact]
    public void ComparisonEquals_ShouldBeFalse_WhenPitchAndOctaveAreNotEqual()
    {
        var note1 = new Note(NotePitch.C, Octave.Contra);
        var note2 = new Note(NotePitch.D, Octave.OneLine);
        var areEqual = note1.Equals(note2);
        areEqual.Should().BeFalse();
    }

    [Fact]
    public void ComparisonNotEqualOperator_ShouldBeTrue_WhenPitchAndOctaveAreEqual()
    {
        var note1 = new Note(NotePitch.C, Octave.Contra);
        var note2 = new Note(NotePitch.C, Octave.Contra);
        var areNotEqual = note1 != note2;
        areNotEqual.Should().BeFalse();
    }

    [Fact]
    public void ComparisonNotEqualOperator_ShouldBeFalse_WhenPitchAndOctaveAreNotEqual()
    {
        var note1 = new Note(NotePitch.C, Octave.Contra);
        var note2 = new Note(NotePitch.D, Octave.OneLine);
        var areNotEqual = note1 != note2;
        areNotEqual.Should().BeTrue();
    }
}