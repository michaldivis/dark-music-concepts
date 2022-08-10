using FluentAssertions;

namespace DarkMusicConcepts.Notes.Tests;

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
    [InlineData(Pitch.C, Octave.SubContra, 12)]
    [InlineData(Pitch.D, Octave.Contra, 26)]
    [InlineData(Pitch.A, Octave.OneLine, 69)]
    [InlineData(Pitch.B, Octave.FourLine, 107)]
    [InlineData(Pitch.G, Octave.SixLine, 127)]
    public void MidiNumber_ShouldBeCorrect(Pitch notePitch, Octave octave, int expectedMidiNumber)
    {
        var note = new Note(notePitch, octave);
        note.MidiNumber?.Value.Should().Be(expectedMidiNumber);
    }

    [Theory]
    [InlineData(Pitch.C, Octave.SubContra, 16.35)]
    [InlineData(Pitch.G, Octave.SubContra, 24.50)]
    [InlineData(Pitch.E, Octave.Contra, 41.20)]
    [InlineData(Pitch.CSharpOrDFlat, Octave.Great, 69.30)]
    [InlineData(Pitch.F, Octave.Small, 174.61)]
    [InlineData(Pitch.A, Octave.OneLine, 440.00)]
    [InlineData(Pitch.E, Octave.TwoLine, 659.25)]
    [InlineData(Pitch.B, Octave.ThreeLine, 1975.53)]
    [InlineData(Pitch.A, Octave.FiveLine, 7040.00)]
    public void Frequency_ShouldBeCorrect(Pitch notePitch, Octave octave, double expectedFrequency)
    {
        var note = new Note(notePitch, octave);
        note.Frequency.Value.Should().BeApproximately(expectedFrequency, 0.01d);
    }

    [Fact]
    public void ComparisonEqualsOperator_ShouldBeTrue_WhenPitchAndOctaveAreEqual()
    {
        var note1 = new Note(Pitch.C, Octave.Contra);
        var note2 = new Note(Pitch.C, Octave.Contra);
        var areEqual = note1 == note2;
        areEqual.Should().BeTrue();
    }

    [Fact]
    public void ComparisonEqualsOperator_ShouldBeFalse_WhenPitchAndOctaveAreNotEqual()
    {
        var note1 = new Note(Pitch.C, Octave.Contra);
        var note2 = new Note(Pitch.D, Octave.OneLine);
        var areEqual = note1 == note2;
        areEqual.Should().BeFalse();
    }

    [Fact]
    public void ComparisonEquals_ShouldBeTrue_WhenPitchAndOctaveAreEqual()
    {
        var note1 = new Note(Pitch.C, Octave.Contra);
        var note2 = new Note(Pitch.C, Octave.Contra);
        var areEqual = note1.Equals(note2);
        areEqual.Should().BeTrue();
    }

    [Fact]
    public void ComparisonEquals_ShouldBeFalse_WhenPitchAndOctaveAreNotEqual()
    {
        var note1 = new Note(Pitch.C, Octave.Contra);
        var note2 = new Note(Pitch.D, Octave.OneLine);
        var areEqual = note1.Equals(note2);
        areEqual.Should().BeFalse();
    }

    [Fact]
    public void ComparisonNotEqualOperator_ShouldBeTrue_WhenPitchAndOctaveAreEqual()
    {
        var note1 = new Note(Pitch.C, Octave.Contra);
        var note2 = new Note(Pitch.C, Octave.Contra);
        var areNotEqual = note1 != note2;
        areNotEqual.Should().BeFalse();
    }

    [Fact]
    public void ComparisonNotEqualOperator_ShouldBeFalse_WhenPitchAndOctaveAreNotEqual()
    {
        var note1 = new Note(Pitch.C, Octave.Contra);
        var note2 = new Note(Pitch.D, Octave.OneLine);
        var areNotEqual = note1 != note2;
        areNotEqual.Should().BeTrue();
    }

    [Fact]
    public void AllNotesCanBeCreated()
    {
        try
        {
            foreach (var note in Note.AllNotes)
            {
                _ = note;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [Theory]
    [MemberData(nameof(AllNotes))]
    public void FindByFrequency_ShouldWork_ForAllNotes(Note note)
    {
        var foundNote = Note.FindByFrequency(note.Frequency);
        foundNote.BasePitch.Should().Be(note.BasePitch);
        foundNote.Octave.Should().Be(note.Octave);
    }

    [Fact]
    public void FindByFrequency_ShouldThrow_WhenFrequencyDoesntMatch()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Note.FindByFrequency(441));
    }

    [Theory]
    [MemberData(nameof(AllNotes))]
    public void TryFindByFrequency_ShouldWork_ForAllNotes(Note note)
    {
        var success = Note.TryFindByFrequency(note.Frequency, out var foundNote);
        success.Should().BeTrue();
        foundNote.Should().NotBeNull();
    }

    [Fact]
    public void TryFindByFrequency_ShouldFail_WhenFrequencyDoesntMatch()
    {
        var success = Note.TryFindByFrequency(441, out var note);
        success.Should().BeFalse();
        note.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(NotesUpTo8thOctave))]
    public void FindByMidiNumber_ShouldWork_ForNotesUpTo8thOctave(Note note)
    {
        var foundNote = Note.FindByMidiNumber(note.MidiNumber!);
        foundNote.BasePitch.Should().Be(note.BasePitch);
        foundNote.Octave.Should().Be(note.Octave);
    }

    [Theory]
    [MemberData(nameof(NotesUpTo8thOctave))]
    public void TryFindByMidiNumber_ShouldWork_ForAllNotes(Note note)
    {
        var success = Note.TryFindByMidiNumber(note.MidiNumber!, out var foundNote);
        success.Should().BeTrue();
        foundNote.Should().NotBeNull();
    }

    [Fact]
    public void Transpose_ShouldWork_WhenTransposingInsidePossibleRange()
    {
        var note = Note.A4;
        var transposed = note.Transpose(Interval.PerfectOctave);
        transposed.Should().Be(Note.A5);
    }

    [Fact]
    public void Transpose_ShouldThrow_WhenTransposingOutOfRange()
    {
        var maxNote = Note.B9;
        Assert.Throws<ArgumentException>(() => maxNote.Transpose(Interval.MinorSecond));
    }

    [Fact]
    public void TryTranspose_ShouldWork_WhenTransposingInsidePossibleRange()
    {
        var note = Note.A4;
        var success = note.TryTranspose(Interval.PerfectOctave, out var transposed);
        success.Should().BeTrue();
        transposed.Should().Be(Note.A5);
    }

    [Fact]
    public void TryTranspose_ShouldFail_WhenTransposingOutOfRange()
    {
        var maxNote = Note.B9;
        var success = maxNote.TryTranspose(Interval.MinorSecond, out var note);
        success.Should().BeFalse();
        note.Should().BeNull();
    }

    public static IEnumerable<object[]> AllNotes => Note.AllNotes.Select(a => new[] { a } );

    //notes up to 8th octave since some of the 9th octave notes go out of MIDI number range (127)
    public static IEnumerable<object[]> NotesUpTo8thOctave => Note.AllNotes.Where(a => a.Octave <= Octave.FiveLine).Select(a => new[] { a });    
}
