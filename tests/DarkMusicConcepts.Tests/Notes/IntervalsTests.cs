using DarkMusicConcepts.Chords;
using DarkMusicConcepts.Tests;
using FluentAssertions;

namespace DarkMusicConcepts.Notes.Tests;

public class IntervalsTests
{
    [Fact]
    public void All_ShouldActuallyContainAllTheIntervals()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<Interval>(typeof(Intervals));
        Intervals.All.Count.Should().Be(found.Count());
        Intervals.All.Should().Contain(found);
    }

    [Fact]
    public void All_ShouldBeUnique()
    {
        var duplicates = Intervals.All
            .GroupBy(x => new { x.Distance, x.Accident })
            .Where(x => x.Count() > 1)
            .ToList();

        duplicates.Should().BeEmpty();
    }
}