namespace DarkMusicConcepts.Tests.NotesTests;

public class NoteTests
{
    public static IEnumerable<object[]> AllNotes => Notes.All.Select(a => new[] { a });

    //notes up to 8th octave since some of the 9th octave notes go out of MIDI number range (127)
    public static IEnumerable<object[]> NotesUpTo8thOctave => Notes.All.Where(a => a.Octave <= Octave.Eight).Select(a => new[] { a });

    public NoteTests()
    {
        DarkMusicConceptsCore.Configure(new DarkMusicConceptsSettings
        {
            MidiMiddleCOctave = Octave.Four //middle C = C4
        });
    }

    [Theory]
    [InlineData(Pitch.C, Octave.Zero, 12)]
    [InlineData(Pitch.D, Octave.One, 26)]
    [InlineData(Pitch.A, Octave.Four, 69)]
    [InlineData(Pitch.B, Octave.Seven, 107)]
    [InlineData(Pitch.G, Octave.Nine, 127)]
    public void MidiNumber_ShouldBeCorrect(Pitch notePitch, Octave octave, int expectedMidiNumber)
    {
        var note = Note.Create(notePitch, octave);
        note.MidiNumber?.Value.Should().Be(expectedMidiNumber);
    }

    [Theory]
    [InlineData(Pitch.C, Octave.Zero, 16.35)]
    [InlineData(Pitch.G, Octave.Zero, 24.50)]
    [InlineData(Pitch.E, Octave.One, 41.20)]
    [InlineData(Pitch.CSharpOrDFlat, Octave.Two, 69.30)]
    [InlineData(Pitch.F, Octave.Three, 174.61)]
    [InlineData(Pitch.A, Octave.Four, 440.00)]
    [InlineData(Pitch.E, Octave.Five, 659.25)]
    [InlineData(Pitch.B, Octave.Six, 1975.53)]
    [InlineData(Pitch.A, Octave.Eight, 7040.00)]
    public void Frequency_ShouldBeCorrect(Pitch notePitch, Octave octave, double expectedFrequency)
    {
        var note = Note.Create(notePitch, octave);
        note.Frequency.Value.Should().BeApproximately(expectedFrequency, 0.01d);
    }

    [Fact]
    public void AllNotesCanBeCreated()
    {
        try
        {
            foreach (var note in Notes.All)
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

    [Fact]
    public void AllNotesCanBeCreated_WhenMiddleCIsC3()
    {
        DarkMusicConceptsCore.Configure(new DarkMusicConceptsSettings
        {
            MidiMiddleCOctave = Octave.Three //middle C = C3
        });

        try
        {
            foreach (var note in Notes.All)
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
    public void AbsolutePitch_ShouldBeUnique(Note note)
    {
        var isAbsolutePitchUnique = Notes.All.All(a => a == note || a.AbsolutePitch != note.AbsolutePitch);
        isAbsolutePitchUnique.Should().BeTrue();
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
        Assert.Throws<ArgumentOutOfRangeException>(() => Note.FindByFrequency(Frequency.From(441)));
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
        var success = Note.TryFindByFrequency(Frequency.From(441), out var note);
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
    public void TransposeUp_ShouldWork_WhenTransposingInsidePossibleRange()
    {
        var note = Notes.A4;
        var transposed = note.TransposeUp(Intervals.PerfectOctave);
        transposed.Should().Be(Notes.A5);
    }

    [Fact]
    public void TransposeUp_ShouldThrow_WhenTransposingOutOfRange()
    {
        var maxNote = Notes.B9;
        Assert.Throws<ArgumentException>(() => maxNote.TransposeUp(Intervals.MinorSecond));
    }

    [Fact]
    public void TryTransposeUp_ShouldWork_WhenTransposingInsidePossibleRange()
    {
        var note = Notes.A4;
        var success = note.TryTransposeUp(Intervals.PerfectOctave, out var transposed);
        success.Should().BeTrue();
        transposed.Should().Be(Notes.A5);
    }

    [Fact]
    public void TryTransposeUp_ShouldFail_WhenTransposingOutOfRange()
    {
        var maxNote = Notes.B9;
        var success = maxNote.TryTransposeUp(Intervals.MinorSecond, out var note);
        success.Should().BeFalse();
        note.Should().BeNull();
    }

    [Fact]
    public void TransposeDown_ShouldWork_WhenTransposingInsidePossibleRange()
    {
        var note = Notes.A4;
        var transposed = note.TransposeDown(Intervals.PerfectOctave);
        transposed.Should().Be(Notes.A3);
    }

    [Fact]
    public void TransposeDown_ShouldThrow_WhenTransposingOutOfRange()
    {
        var minNote = Notes.CMinus1;
        Assert.Throws<ArgumentException>(() => minNote.TransposeDown(Intervals.MinorSecond));
    }

    [Fact]
    public void TryTransposeDown_ShouldWork_WhenTransposingInsidePossibleRange()
    {
        var note = Notes.A4;
        var success = note.TryTransposeDown(Intervals.PerfectOctave, out var transposed);
        success.Should().BeTrue();
        transposed.Should().Be(Notes.A3);
    }

    [Fact]
    public void TryTransposeDown_ShouldFail_WhenTransposingOutOfRange()
    {
        var minNote = Notes.CMinus1;
        var success = minNote.TryTransposeDown(Intervals.MinorSecond, out var note);
        success.Should().BeFalse();
        note.Should().BeNull();
    }

    #region Equality

    [Fact]
    public void Equals_ShouldWork()
    {
        Note nullItem = null!;
        var item1 = Note.Create(Pitch.C, Octave.Four);
        var item2 = Note.Create(Pitch.C, Octave.Four);
        var item3 = Note.Create(Pitch.G, Octave.Three);

        (item1.Equals(item2)).Should().BeTrue();
        (item2.Equals(item1)).Should().BeTrue();

        (item1.Equals(item3)).Should().BeFalse();
        (item1.Equals(nullItem)).Should().BeFalse();
    }

    [Fact]
    public void EqualOperator_ShouldWork()
    {
        Note nullItem = null!;
        var item1 = Note.Create(Pitch.C, Octave.Four);
        var item2 = Note.Create(Pitch.C, Octave.Four);
        var item3 = Note.Create(Pitch.G, Octave.Three);

        (item1 == item2).Should().BeTrue();
        (item2 == item1).Should().BeTrue();

        (item1 == item3).Should().BeFalse();
        (item1 == nullItem).Should().BeFalse();
        (nullItem == item1).Should().BeFalse();
    }

    [Fact]
    public void NotEqualOperator_ShouldWork()
    {
        Note nullItem = null!;
        var item1 = Note.Create(Pitch.C, Octave.Four);
        var item2 = Note.Create(Pitch.C, Octave.Four);
        var item3 = Note.Create(Pitch.G, Octave.Three);

        (item1 != item2).Should().BeFalse();
        (item2 != item1).Should().BeFalse();

        (item1 != item3).Should().BeTrue();
        (item1 != nullItem).Should().BeTrue();
        (nullItem != item1).Should().BeTrue();
    }

    #endregion

    #region Comparison

    [Fact]
    public void CompareTo_ShouldWork()
    {
        var normal = Note.Create(Pitch.C, Octave.Four);

        Note nullItem = null!;
        var little = Note.Create(Pitch.F, Octave.One);
        var alsoNormal = Note.Create(Pitch.C, Octave.Four);
        var large = Note.Create(Pitch.G, Octave.Six);

        normal.CompareTo(nullItem).Should().Be(1);
        normal.CompareTo(little).Should().Be(1);
        normal.CompareTo(alsoNormal).Should().Be(0);
        normal.CompareTo(large).Should().Be(-1);
    }

    [Fact]
    public void GreaterThanOperator_ShouldWork()
    {
        var normal = Note.Create(Pitch.C, Octave.Four);

        Note nullItem = null!;
        var little = Note.Create(Pitch.F, Octave.One);
        var alsoNormal = Note.Create(Pitch.C, Octave.Four);
        var large = Note.Create(Pitch.G, Octave.Six);

        (normal > nullItem).Should().BeTrue();
        (normal > little).Should().BeTrue();
        (normal > alsoNormal).Should().BeFalse();
        (normal > large).Should().BeFalse();
        (nullItem > normal).Should().BeFalse();
    }

    [Fact]
    public void GreaterThanOrEqualOperator_ShouldWork()
    {
        var normal = Note.Create(Pitch.C, Octave.Four);

        Note nullItem = null!;
        var little = Note.Create(Pitch.F, Octave.One);
        var alsoNormal = Note.Create(Pitch.C, Octave.Four);
        var large = Note.Create(Pitch.G, Octave.Six);

        (normal >= nullItem).Should().BeTrue();
        (normal >= little).Should().BeTrue();
        (normal >= alsoNormal).Should().BeTrue();
        (normal >= large).Should().BeFalse();
        (nullItem >= normal).Should().BeFalse();
    }

    [Fact]
    public void SmallerThanOperator_ShouldWork()
    {
        var normal = Note.Create(Pitch.C, Octave.Four);

        Note nullItem = null!;
        var little = Note.Create(Pitch.F, Octave.One);
        var alsoNormal = Note.Create(Pitch.C, Octave.Four);
        var large = Note.Create(Pitch.G, Octave.Six);

        (normal < nullItem).Should().BeFalse();
        (normal < little).Should().BeFalse();
        (normal < alsoNormal).Should().BeFalse();
        (normal < large).Should().BeTrue();
        (nullItem < normal).Should().BeTrue();
    }

    [Fact]
    public void SmallerThanOrEqualOperator_ShouldWork()
    {
        var normal = Note.Create(Pitch.C, Octave.Four);

        Note nullItem = null!;
        var little = Note.Create(Pitch.F, Octave.One);
        var alsoNormal = Note.Create(Pitch.C, Octave.Four);
        var large = Note.Create(Pitch.G, Octave.Six);

        (normal <= nullItem).Should().BeFalse();
        (normal <= little).Should().BeFalse();
        (normal <= alsoNormal).Should().BeTrue();
        (normal <= large).Should().BeTrue();
        (nullItem <= normal).Should().BeTrue();
    }

    #endregion   
}