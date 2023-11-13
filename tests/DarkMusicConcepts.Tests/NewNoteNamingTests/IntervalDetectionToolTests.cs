using DarkMusicConcepts.NewNoteNaming;
using DarkMusicConcepts.NewNoteNaming.Intervals;
using DarkMusicConcepts.NewNoteNaming.Pitch;
using Xunit.Abstractions;

namespace DarkMusicConcepts.Tests.NewNoteNamingTests;

public class IntervalDetectionToolTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public IntervalDetectionToolTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void GetDiffSemitones_ShouldReturnZero_WhenBothPitchesAreTheSame()
    {
        foreach (var whiteKey in WellKnownPitchGroups.ChromaticWithFlats)
        {
            IntervalDetectionTool.GetDiffSemitones(whiteKey, whiteKey)
                .Should().Be(0);
        }
    }

    [Fact]
    public void GetDiffSemitones_ShouldReturnZero_WhenBothPitchesAreEnharmonicallyEqual()
    {
        var flatList = WellKnownPitchGroups.BlackKeysFlat;
        var sharpList = WellKnownPitchGroups.BlackKeysSharp;

        for (int i = 0; i < flatList.Count; i++)
        {
            var flatPitch = flatList[i];
            var sharpPitch = sharpList[i];

            IntervalDetectionTool.GetDiffSemitones(flatPitch, sharpPitch)
                .Should().Be(0);
        }
    }

    [Fact]
    public void GetDiffSemitones_ShouldReturnOne_ForAdjacentTones()
    {
        var fastList = WellKnownPitchGroups.ChromaticWithSharps;
        var slowList = WellKnownPitchGroups.ChromaticWithSharps;

        for (int i = 1; i < fastList.Count; i++)
        {
            var fastPitch = fastList[i];
            var slowPitch = slowList[i - 1];
            _testOutputHelper.WriteLine($"{slowPitch}, {fastPitch}");
            IntervalDetectionTool.GetDiffSemitones(fastPitch, slowPitch)
                .Should().Be(1);
        }
    }

    [Fact]
    public void FindQuantityWithinOctave_ShouldReturnUnison_WhenItIsPerfectUnison()
    {
        var chromaticWithSharps = WellKnownPitchGroups.ChromaticWithSharps;

        foreach (var pitch in chromaticWithSharps)
        {
            _testOutputHelper.WriteLine($"{pitch}, {pitch}");

            var findQuantityWithinOctave = IntervalDetectionTool.FindQuantityWithinOctave(pitch, pitch);
            findQuantityWithinOctave
                .Should().Be(WellKnownIntervalQuantities.Unison);
        }
    }

    [Fact]
    public void FindQuantityWithinOctave_ShouldReturnFourth_WhenItIsPerfectFourth()
    {
        var pairsOfFourth =
            new List<(NewNoteNaming.Pitch.Pitch lo, NewNoteNaming.Pitch.Pitch hi)>
            {
                (WellKnownPitches.C1, WellKnownPitches.F1),
                (WellKnownPitches.Cs1, WellKnownPitches.Fs1),
                (WellKnownPitches.D1, WellKnownPitches.G1),
                (WellKnownPitches.Ds1, WellKnownPitches.Gs1),
                (WellKnownPitches.E1, WellKnownPitches.A1),
                (WellKnownPitches.F1, WellKnownPitches.Bb1),
                (WellKnownPitches.Fs1, WellKnownPitches.B1),
                (WellKnownPitches.G1, WellKnownPitches.C2),
                (WellKnownPitches.Gs1, WellKnownPitches.Cs2),
                (WellKnownPitches.A1, WellKnownPitches.D2),
                (WellKnownPitches.As1, WellKnownPitches.Ds2),
                (WellKnownPitches.B1, WellKnownPitches.E2),
                (WellKnownPitches.C2, WellKnownPitches.F2),
            };

        foreach (var (lo, hi) in pairsOfFourth)
        {
            var findQuantityWithinOctave = IntervalDetectionTool.FindQuantityWithinOctave(lo, hi);

            _testOutputHelper.WriteLine($"{lo}, {hi}");
            findQuantityWithinOctave
                .Should().Be(WellKnownIntervalQuantities.Fourth);
        }


    }
}
