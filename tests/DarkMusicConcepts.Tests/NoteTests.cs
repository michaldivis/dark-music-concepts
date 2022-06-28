using FluentAssertions;

namespace DarkMusicConcepts;

public class NoteTests
{
    [Theory]
    [InlineData(NotePitch.C, Octave.SubContra, 24)]
    [InlineData(NotePitch.D, Octave.Contra, 38)]
    [InlineData(NotePitch.A, Octave.OneLine, 69)]
    [InlineData(NotePitch.B, Octave.FourLine, 107)]
    [InlineData(NotePitch.G, Octave.SixLine, 127)]
    public void MidiNumber_Tests(NotePitch notePitch, Octave octave, int expectedMidiNumber)
    {
        var note = new Note(notePitch, octave);
        note.MidiNumber.Should().Be(expectedMidiNumber);
    }
}