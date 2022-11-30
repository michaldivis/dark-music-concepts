using DarkMusicConcepts.Chords;
using DarkMusicConcepts.Tests;
using FluentAssertions;

namespace DarkMusicConcepts.Notes.Tests;

public class ChordFormulasTests
{
    [Fact]
    public void All_ShouldActuallyContainAllTheFormulas()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<ChordFormula>(typeof(ChordFormulas));
        ChordFormulas.All.Count.Should().Be(found.Count());
        ChordFormulas.All.Should().Contain(found);
    }
}