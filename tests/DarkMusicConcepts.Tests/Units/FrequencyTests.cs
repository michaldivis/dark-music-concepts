using FluentAssertions;

namespace DarkMusicConcepts.Units.Tests;
public class FrequencyTests
{
    [Fact]
    public void From_ShouldThrow_WhenLessThanMin()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Frequency.From(Frequency.Min - 1));
    }

    [Fact]
    public void TryFrom_ShouldFail_WhenLessThanMin()
    {
        var success = Frequency.TryFrom(Frequency.Min - 1, out var invalidFrequency);
        success.Should().Be(false);
        invalidFrequency.Should().Be(null);
    }

    [Fact]
    public void ImplicitCreation_ShouldWork_WithDouble()
    {
        Frequency frequency = 43d;
        frequency.Value.Should().Be(43d);
    }

    [Fact]
    public void Comparison_ShouldReturnTrue_WhenValueMatches()
    {
        var frequency1 = Frequency.From(43d);
        var frequency2 = Frequency.From(43d);
        var result = frequency1 == frequency2;
        result.Should().BeTrue();
    }

    [Fact]
    public void Comparison_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var frequency1 = Frequency.From(43d);
        var frequency2 = Frequency.From(69d);
        var result = frequency1 == frequency2;
        result.Should().BeFalse();
    }

    [Fact]
    public void ComparisonWithDouble_ShouldReturnTrue_WhenValueMatches()
    {
        var frequency = Frequency.From(43d);
        var result = frequency == 43d;
        result.Should().BeTrue();
    }

    [Fact]
    public void ComparisonWithDouble_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var frequency = Frequency.From(43d);
        var result = frequency == 69d;
        result.Should().BeFalse();
    }

    [Fact]
    public void ComparisonWithDoubleOtherWay_ShouldReturnTrue_WhenValueMatches()
    {
        var frequency = Frequency.From(43d);
        var result = 43d == frequency;
        result.Should().BeTrue();
    }

    [Fact]
    public void ComparisonWithDoubleOtherWay_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var frequency = Frequency.From(43d);
        var result = 69d == frequency;
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsWithDouble_ShouldReturnTrue_WhenValueMatches()
    {
        var frequency = Frequency.From(43d);
        var result = frequency.Equals(43d);
        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsWithDouble_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var frequency = Frequency.From(43d);
        var result = frequency.Equals(69d);
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsWithDoubleOtherWay_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var frequency = Frequency.From(43d);
        var result = 69d.Equals(frequency);
        result.Should().BeFalse();
    }
}
