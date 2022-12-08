using DarkMusicConcepts.Tests;

namespace DarkMusicConcepts.Chords;

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