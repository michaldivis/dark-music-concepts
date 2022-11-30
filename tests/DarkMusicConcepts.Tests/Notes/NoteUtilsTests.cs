using FluentAssertions;

namespace DarkMusicConcepts.Notes.Tests;

public class NoteUtilsTests
{
    [Theory]
    [InlineData(Pitch.C, 0, Pitch.C)]
    [InlineData(Pitch.C, 1, Pitch.CSharpOrDFlat)]
    [InlineData(Pitch.C, 2, Pitch.D)]
    [InlineData(Pitch.C, 3, Pitch.DSharpOrEFlat)]
    [InlineData(Pitch.C, 4, Pitch.E)]
    [InlineData(Pitch.C, 5, Pitch.F)]
    [InlineData(Pitch.C, 6, Pitch.FSharpOrGFlat)]
    [InlineData(Pitch.C, 7, Pitch.G)]
    [InlineData(Pitch.C, 8, Pitch.GSharpOrAFlat)]
    [InlineData(Pitch.C, 9, Pitch.A)]
    [InlineData(Pitch.C, 10, Pitch.ASharpOrBFlat)]
    [InlineData(Pitch.C, 11, Pitch.B)]
    [InlineData(Pitch.C, 12, Pitch.C)]
    public void TransposePitch_ShouldWork(Pitch notePitch, int intervalDistance, Pitch expected)
    {
        var interval = Interval.CreateIntervalFromDistance(intervalDistance);
        var transposed = NoteUtils.TransposePitch(notePitch, interval);
        transposed.Should().Be(expected);
    }

    [Fact]
    public void TransposePitch_ShouldNotThrow_ForAllPitchesAndIntervals()
    {
        foreach (var notePitch in Enum.GetValues<Pitch>())
        {
            foreach (var interval in Intervals.All)
            {
                _ = NoteUtils.TransposePitch(notePitch, interval);
            }
        }
    }
}