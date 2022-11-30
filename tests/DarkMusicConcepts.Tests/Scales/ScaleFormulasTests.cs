using DarkMusicConcepts.Tests;
using FluentAssertions;

namespace DarkMusicConcepts.Scales.Tests;

public class ScaleFormulasTests
{
    [Fact]
    public void All_ShouldActuallyContainAllTheScaleFormulas()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<ScaleFormula>(typeof(ScaleFormula));
        ScaleFormulas.All.Count.Should().Be(found.Count());
        ScaleFormulas.All.Should().Contain(found);
    }
}