namespace DarkMusicConcepts.Tests.ChordsTests;

public class ChordTests
{
    public static IEnumerable<object[]> Create_FromNotes_RootPitchAndFormulaAndInversionAreCorrect_TestData =>
        new []
        {
            // CMaj - root poistion
            new object[] { new [] { Notes.C2, Notes.E2, Notes.G2 }, Pitch.C, ChordFormulas.Major, 0 },
            // CMaj - 1st inversion
            new object[] { new [] { Notes.E2, Notes.G3, Notes.C3 }, Pitch.C, ChordFormulas.Major, 1 },
            // CMaj - 2nd inversion
            new object[] { new [] { Notes.G2, Notes.E3, Notes.C3 }, Pitch.C, ChordFormulas.Major, 2 },
            // CMaj (spaced out) - root poistion
            new object[] { new [] { Notes.C2, Notes.E4, Notes.G6 }, Pitch.C, ChordFormulas.Major, 0 },
            // CMaj (spaced out) - 1st inversion
            new object[] { new [] { Notes.E2, Notes.G4, Notes.C6 }, Pitch.C, ChordFormulas.Major, 1 },
            // CMaj (spaced out) - 1st inversion, different order of upper notes
            new object[] { new [] { Notes.E2, Notes.C4, Notes.G6 }, Pitch.C, ChordFormulas.Major, 1 },
            // CMaj (spaced out) - 2nd inversion
            new object[] { new [] { Notes.G2, Notes.E4, Notes.C6 }, Pitch.C, ChordFormulas.Major, 2 },
            // CMaj (spaced out) - 2nd inversion, different order of upper notes
            new object[] { new [] { Notes.G2, Notes.C4, Notes.E6 }, Pitch.C, ChordFormulas.Major, 2 },
            // EMaj7 - root position
            new object[] { new [] { Notes.E2, Notes.GSharpOrAFlat2, Notes.B2, Notes.DSharpOrEFlat3 }, Pitch.E, ChordFormulas.MajorSeventh, 0 },
            // EMaj7 - 1st inversion
            new object[] { new [] { Notes.GSharpOrAFlat2, Notes.B2, Notes.DSharpOrEFlat3, Notes.E3 }, Pitch.E, ChordFormulas.MajorSeventh, 1 },
            // EMaj7 - 2nd inversion
            new object[] { new [] { Notes.B2, Notes.DSharpOrEFlat3, Notes.E3, Notes.GSharpOrAFlat3 }, Pitch.E, ChordFormulas.MajorSeventh, 2 },
            // EMaj7 - 3rd inversion
            new object[] { new [] { Notes.DSharpOrEFlat3, Notes.E3, Notes.GSharpOrAFlat3, Notes.B3 }, Pitch.E, ChordFormulas.MajorSeventh, 3 },            
            // EMaj7 (spaced out) - root position
            new object[] { new [] { Notes.E2, Notes.GSharpOrAFlat3, Notes.B4, Notes.DSharpOrEFlat5 }, Pitch.E, ChordFormulas.MajorSeventh, 0 },
            // EMaj7 (spaced out) - 1st inversion
            new object[] { new [] { Notes.GSharpOrAFlat2, Notes.B3, Notes.DSharpOrEFlat4, Notes.E5 }, Pitch.E, ChordFormulas.MajorSeventh, 1 },
            // EMaj7 (spaced out) - 2nd inversion
            new object[] { new [] { Notes.B2, Notes.DSharpOrEFlat3, Notes.E5, Notes.GSharpOrAFlat6 }, Pitch.E, ChordFormulas.MajorSeventh, 2 },
            // EMaj7 (spaced out) - 3rd inversion
            new object[] { new [] { Notes.DSharpOrEFlat3, Notes.E4, Notes.GSharpOrAFlat5, Notes.B6 }, Pitch.E, ChordFormulas.MajorSeventh, 3 },
        };

    [Theory]
    [MemberData(nameof(Create_FromNotes_RootPitchAndFormulaAndInversionAreCorrect_TestData))]
    public void Create_FromNotes_RootPitchAndFormulaAndInversionAreCorrect(IEnumerable<Note> notes, Pitch expectedRootPitch, ChordFormula expextedFormula, int expectedInversion)
    {
        var chord = Chord.Create(notes);

        chord.RootPitch.Should().Be(expectedRootPitch);
        chord.Formula.Should().Be(expextedFormula);
        chord.Inversion.Should().Be(expectedInversion);
    }
}
