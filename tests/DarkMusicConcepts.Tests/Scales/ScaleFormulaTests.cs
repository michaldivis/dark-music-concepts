using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Tests;
using FluentAssertions;

namespace DarkMusicConcepts.Scales.Tests;
public class ScaleFormulaTests
{
    [Theory]
    [MemberData(nameof(AllScaleFormulasAndRoots))]
    public void CreateForRoot_ShouldWorkForAllScalesAndRoots(ScaleFormula scaleFormula, Pitch root)
    {
        _ = scaleFormula.CreateForRoot(root);
    }

    [Fact]
    public void CreateForRoot_ShouldCreateAValidScale()
    {
        var aPhrygian = ScaleFormula.Phrygian.CreateForRoot(Pitch.A);

        aPhrygian.I.Should().Be(Pitch.A);
        aPhrygian.II.Should().Be(Pitch.ASharpOrBFlat);
        aPhrygian.III.Should().Be(Pitch.C);
        aPhrygian.IV.Should().Be(Pitch.D);
        aPhrygian.V.Should().Be(Pitch.E);
        aPhrygian.VI.Should().Be(Pitch.F);
        aPhrygian.VII.Should().Be(Pitch.G);

        aPhrygian.Pitches.Should().ContainInOrder(new[] {
            Pitch.A,
            Pitch.ASharpOrBFlat,
            Pitch.C,
            Pitch.D,
            Pitch.E,
            Pitch.F,
            Pitch.G
        });
    }

    [Fact]
    public void AllScaleFormulas_ShouldActuallyContainAllTheScaleFormulas()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<ScaleFormula, ScaleFormula>();
        ScaleFormula.AllScaleFormulas.Count.Should().Be(found.Count());
        ScaleFormula.AllScaleFormulas.Should().Contain(found);
    }

    public static IEnumerable<object[]> AllScaleFormulasAndRoots => GetAllScaleFormulasAndRoots();

    private static IEnumerable<object[]> GetAllScaleFormulasAndRoots()
    {
        foreach (var scaleFormula in ScaleFormula.AllScaleFormulas)
        {
            foreach (var root in Enum.GetValues<Pitch>())
            {
                yield return new object[] { scaleFormula, root }; 
            }
        }
    }
}
