using FluentAssertions;

namespace DarkMusicConcepts.Notes.Tests;

public class NoteUtilsTests
{
    [Theory]
    [InlineData(NotePitch.C, 0, NotePitch.C)]
    [InlineData(NotePitch.C, 1, NotePitch.CSharpOrDFlat)]
    [InlineData(NotePitch.C, 2, NotePitch.D)]
    [InlineData(NotePitch.C, 3, NotePitch.DSharpOrEFlat)]
    [InlineData(NotePitch.C, 4, NotePitch.E)]
    [InlineData(NotePitch.C, 5, NotePitch.F)]
    [InlineData(NotePitch.C, 6, NotePitch.FSharpOrGFlat)]
    [InlineData(NotePitch.C, 7, NotePitch.G)]
    [InlineData(NotePitch.C, 8, NotePitch.GSharpOrAFlat)]
    [InlineData(NotePitch.C, 9, NotePitch.A)]
    [InlineData(NotePitch.C, 10, NotePitch.ASharpOrBFlat)]
    [InlineData(NotePitch.C, 11, NotePitch.B)]
    [InlineData(NotePitch.C, 12, NotePitch.C)]
    public void TransposePitch_ShouldWork(NotePitch notePitch, int intervalDistance, NotePitch expected)
    {
        var interval = Interval.CreateIntervalFromDistance(intervalDistance);
        var transposed = NoteUtils.TransposePitch(notePitch, interval);
        transposed.Should().Be(expected);
    }

    [Fact]
    public void TransposePitch_ShouldNotThrow_ForAllPitchesAndIntervals()
    {
        foreach (var notePitch in Enum.GetValues<NotePitch>())
        {
            foreach (var interval in Interval.AllIntervals)
            {
                _ = NoteUtils.TransposePitch(notePitch, interval);
            }
        }
    }
}