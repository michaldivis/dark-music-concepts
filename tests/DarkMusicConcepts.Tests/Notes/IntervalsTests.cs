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
}