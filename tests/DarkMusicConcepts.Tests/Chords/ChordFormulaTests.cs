using DarkMusicConcepts.Chords;
using DarkMusicConcepts.Tests;
using FluentAssertions;

namespace DarkMusicConcepts.Notes.Tests;

public class ChordFormulaTests
{
    [Fact]
    public void AllFormulas_ShouldActuallyContainAllTheFormulas()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<ChordFormula, ChordFormula>();
        ChordFormula.AllFormulas.Count.Should().Be(found.Count());
        ChordFormula.AllFormulas.Should().Contain(found);
    }
}