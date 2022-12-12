namespace DarkMusicConcepts;

public class ChordFormulasTests
{
    [Fact]
    public void All_ShouldActuallyContainAllTheFormulas()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<ChordFormula>(typeof(ChordFormulas));
        ChordFormulas.All.Count.Should().Be(found.Count());
        ChordFormulas.All.Should().Contain(found);
    }

    [Fact]
    public void All_ShouldBeUnique()
    {
        var duplicates = ChordFunctions.All
            .GroupBy(x => string.Join(';', x.Intervals.Select(i => i.Distance)))
            .Where(x => x.Count() > 1)
            .ToList();

        duplicates.Should().BeEmpty();
    }
}