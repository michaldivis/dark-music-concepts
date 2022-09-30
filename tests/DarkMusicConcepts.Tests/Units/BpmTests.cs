using FluentAssertions;

namespace DarkMusicConcepts.Units.Tests;

public class BpmTests
{
    [Fact]
    public void From_ShouldThrow_WhenLessThanMin()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Bpm.From(Bpm.Min - 1));
    }

    [Fact]
    public void TryFrom_ShouldFail_WhenLessThanMin()
    {
        var success = Bpm.TryFrom(Bpm.Min - 1, out var invalidBpm);
        success.Should().Be(false);
        invalidBpm.Should().Be(null);
    }

    [Fact]
    public void ImplicitCreation_ShouldWork_WithInt()
    {
        Bpm bpm = 43;
        bpm.Value.Should().Be(43);
    }

    [Fact]
    public void Comparison_ShouldReturnTrue_WhenValueMatches()
    {
        var bpm1 = Bpm.From(43);
        var bpm2 = Bpm.From(43);
        var result = bpm1 == bpm2;
        result.Should().BeTrue();
    }

    [Fact]
    public void Comparison_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var bpm1 = Bpm.From(43);
        var bpm2 = Bpm.From(69);
        var result = bpm1 == bpm2;
        result.Should().BeFalse();
    }

    [Fact]
    public void ComparisonWithInt_ShouldReturnTrue_WhenValueMatches()
    {
        var bpm = Bpm.From(43);
        var result = bpm == 43;
        result.Should().BeTrue();
    }

    [Fact]
    public void ComparisonWithInt_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var bpm = Bpm.From(43);
        var result = bpm == 69;
        result.Should().BeFalse();
    }

    [Fact]
    public void ComparisonWithIntOtherWay_ShouldReturnTrue_WhenValueMatches()
    {
        var bpm = Bpm.From(43);
        var result = 43 == bpm;
        result.Should().BeTrue();
    }

    [Fact]
    public void ComparisonWithIntOtherWay_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var bpm = Bpm.From(43);
        var result = 69 == bpm;
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsWithInt_ShouldReturnTrue_WhenValueMatches()
    {
        var bpm = Bpm.From(43);
        var result = bpm.Equals(43);
        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsWithInt_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var bpm = Bpm.From(43);
        var result = bpm.Equals(69);
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsWithIntOtherWay_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var bpm = Bpm.From(43);
        var result = 69.Equals(bpm);
        result.Should().BeFalse();
    }
}
