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
        note.MidiNumber.Should().Be(expectedMidiNumber);
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
        note.Frequency.Should().BeApproximately(expectedFrequency, 0.01d);
    }
}