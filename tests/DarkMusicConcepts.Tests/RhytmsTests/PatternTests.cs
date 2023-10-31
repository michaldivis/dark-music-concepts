namespace DarkMusicConcepts.Tests.RhytmsTests;

public class PatternTests
{
    [Fact]
    public void Create_ShouldThrow_WhenNodesNull()
    {
        var act = () => Pattern.Create(null!, Time.SixteenthNote);
        act.Should().Throw<ArgumentNullException>();
    }
    
    [Fact]
    public void Create_ShouldThrow_WhenNodesEmpty()
    {
        var act = () => Pattern.Create(Array.Empty<bool>(), Time.SixteenthNote);
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(0, 1, true)]
    [InlineData(0, 2, true)]
    [InlineData(0, 4, true)]
    [InlineData(0, 8, true)]
    [InlineData(0, 16, true)]
    [InlineData(1, 1, true)]
    [InlineData(1, 2, false)]
    [InlineData(1, 3, false)]
    [InlineData(1, 4, false)]
    [InlineData(2, 1, true)]
    [InlineData(2, 2, true)]
    [InlineData(2, 3, false)]
    [InlineData(2, 4, false)]
    [InlineData(3, 1, true)]
    [InlineData(3, 2, false)]
    [InlineData(3, 3, true)]
    [InlineData(3, 4, false)]
    [InlineData(4, 1, true)]
    [InlineData(4, 2, true)]
    [InlineData(4, 3, false)]
    [InlineData(4, 4, true)]
    public void IsNodeOnPulse_ShouldWork(int node, int pulseSixteenthNotes, bool expected)
    {
        var pattern = Pattern.Create(new[] { true, false }, Time.SixteenthNote);
        var isNodeOnPulse = pattern.IsNodeOnPulse(node, Time.FromSixteenthNotes(pulseSixteenthNotes));

        isNodeOnPulse.Should().Be(expected);
    }
}
