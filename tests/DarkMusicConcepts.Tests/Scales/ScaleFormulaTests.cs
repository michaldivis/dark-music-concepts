using DarkMusicConcepts.Notes;
using FluentAssertions;

namespace DarkMusicConcepts.Scales.Tests;
public class ScaleFormulaTests
{
    [Theory]
    [MemberData(nameof(AllScaleFormulasAndRoots))]
    public void CreateForRoot_ShouldWorkForAllScalesAndRoots(ScaleFormula scaleFormula, NotePitch root)
    {
        _ = scaleFormula.CreateForRoot(root);
    }

    [Fact]
    public void CreateForRoot_ShouldCreateAValidScale()
    {
        var aPhrygian = ScaleFormula.Phrygian.CreateForRoot(NotePitch.A);

        aPhrygian.I.Should().Be(NotePitch.A);
        aPhrygian.II.Should().Be(NotePitch.ASharpOrBFlat);
        aPhrygian.III.Should().Be(NotePitch.C);
        aPhrygian.IV.Should().Be(NotePitch.D);
        aPhrygian.V.Should().Be(NotePitch.E);
        aPhrygian.VI.Should().Be(NotePitch.F);
        aPhrygian.VII.Should().Be(NotePitch.G);

        aPhrygian.Notes.Should().ContainInOrder(new[] {
            NotePitch.A,
            NotePitch.ASharpOrBFlat,
            NotePitch.C,
            NotePitch.D,
            NotePitch.E,
            NotePitch.F,
            NotePitch.G
        });
    }

    public static IEnumerable<object[]> AllScaleFormulasAndRoots => GetAllScaleFormulasAndRoots();

    private static IEnumerable<object[]> GetAllScaleFormulasAndRoots()
    {
        foreach (var scaleFormula in ScaleFormula.AllScaleFormulas)
        {
            foreach (var root in Enum.GetValues<NotePitch>())
            {
                yield return new object[] { scaleFormula, root }; 
            }
        }
    }
}
