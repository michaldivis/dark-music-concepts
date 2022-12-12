namespace DarkMusicConcepts;

public class ChordFunctionTests
{
    public static IEnumerable<object[]> AllChordFunctions => ChordFunctions.All.Select(x => new[] { x });

    [Theory]
    [MemberData(nameof(AllChordFunctions))]
    public void FunctionForInterval_ShouldWorkForAllIntervals(ChordFunction chordFunction)
    {
        foreach (var interval in chordFunction.Intervals)
        {
            var result = ChordFunction.FunctionForInterval(interval);
            result.Should().Be(chordFunction);
        }
    }
}