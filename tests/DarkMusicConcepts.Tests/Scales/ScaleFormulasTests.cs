namespace DarkMusicConcepts;

public class ScaleFormulasTests
{
    [Fact]
    public void All_ShouldActuallyContainAllTheScaleFormulas()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<ScaleFormula>(typeof(ScaleFormulas));
        ScaleFormulas.All.Count.Should().Be(found.Count());
        ScaleFormulas.All.Should().Contain(found);
    }

    [Fact]
    public void All_ShouldBeUnique()
    {
        var duplicates = ScaleFormulas.All
            .GroupBy(x => string.Join(';', x.Intervals.Select(i => i.Distance)))
            .Where(x => x.Count() > 1)
            .ToList();

        duplicates.Should().BeEmpty();
    }
}