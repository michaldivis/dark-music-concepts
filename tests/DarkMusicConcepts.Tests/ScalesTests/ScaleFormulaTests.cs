namespace DarkMusicConcepts.Tests.ScalesTests;

public class ScaleFormulaTests
{
    [Theory]
    [MemberData(nameof(AllScaleFormulasAndRoots))]
    public void Create_ShouldWorkForAllScalesAndRoots(ScaleFormula scaleFormula, Pitch root)
    {
        _ = scaleFormula.Create(root);
    }

    [Fact]
    public void Create_ShouldCreateAValidScale()
    {
        var aPhrygian = ScaleFormulas.Phrygian.Create(Pitch.A);

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

    public static IEnumerable<object[]> AllScaleFormulasAndRoots => GetAllScaleFormulasAndRoots();

    private static IEnumerable<object[]> GetAllScaleFormulasAndRoots()
    {
        foreach (var scaleFormula in ScaleFormulas.All)
        {
            foreach (var root in Enum.GetValues<Pitch>())
            {
                yield return new object[] { scaleFormula, root }; 
            }
        }
    }
}