using DarkMusicConcepts.Chords;
using DarkMusicConcepts.Tests;
using FluentAssertions;

namespace DarkMusicConcepts.Notes.Tests;

public class ChordFunctionsTests
{
    [Fact]
    public void All_ShouldActuallyContainAllTheFunctions()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<ChordFunction>(typeof(ChordFunctions));
        ChordFunctions.All.Count.Should().Be(found.Count());
        ChordFunctions.All.Should().Contain(found);
    }
}