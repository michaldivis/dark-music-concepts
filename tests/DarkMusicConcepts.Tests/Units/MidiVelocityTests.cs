using FluentAssertions;

namespace DarkMusicConcepts.Units.Tests;
public class MidiVelocityTests
{
    [Fact]
    public void From_ShouldThrow_WhenLessThanMin()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MidiVelocity.From(MidiVelocity.Min - 1));
    }

    [Fact]
    public void From_ShouldThrow_WhenGreaterThanMax()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MidiVelocity.From(MidiVelocity.Max + 1));
    }

    [Fact]
    public void TryFrom_ShouldFail_WhenLessThanMin()
    {
        var success = MidiVelocity.TryFrom(MidiVelocity.Min - 1, out var invalidMidiVelocity);
        success.Should().Be(false);
        invalidMidiVelocity.Should().Be(null);
    }

    [Fact]
    public void TryFrom_ShouldFail_WhenGreaterThanMax()
    {
        var success = MidiVelocity.TryFrom(MidiVelocity.Max + 1, out var invalidMidiVelocity);
        success.Should().Be(false);
        invalidMidiVelocity.Should().Be(null);
    }

    [Fact]
    public void ImplicitCreation_ShouldWork_WithInt()
    {
        MidiVelocity midiVelocity = 43;
        midiVelocity.Value.Should().Be(43);
    }

    [Fact]
    public void Comparison_ShouldReturnTrue_WhenValueMatches()
    {
        var midiVelocity1 = MidiVelocity.From(43);
        var midiVelocity2 = MidiVelocity.From(43);
        var result = midiVelocity1 == midiVelocity2;
        result.Should().BeTrue();
    }

    [Fact]
    public void Comparison_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiVelocity1 = MidiVelocity.From(43);
        var midiVelocity2 = MidiVelocity.From(69);
        var result = midiVelocity1 == midiVelocity2;
        result.Should().BeFalse();
    }

    [Fact]
    public void ComparisonWithInt_ShouldReturnTrue_WhenValueMatches()
    {
        var midiVelocity = MidiVelocity.From(43);
        var result = midiVelocity == 43;
        result.Should().BeTrue();
    }

    [Fact]
    public void ComparisonWithInt_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiVelocity = MidiVelocity.From(43);
        var result = midiVelocity == 69;
        result.Should().BeFalse();
    }

    [Fact]
    public void ComparisonWithIntOtherWay_ShouldReturnTrue_WhenValueMatches()
    {
        var midiVelocity = MidiVelocity.From(43);
        var result = 43 == midiVelocity;
        result.Should().BeTrue();
    }

    [Fact]
    public void ComparisonWithIntOtherWay_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiVelocity = MidiVelocity.From(43);
        var result = 69 == midiVelocity;
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsWithInt_ShouldReturnTrue_WhenValueMatches()
    {
        var midiVelocity = MidiVelocity.From(43);
        var result = midiVelocity.Equals(43);
        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsWithInt_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiVelocity = MidiVelocity.From(43);
        var result = midiVelocity.Equals(69);
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsWithIntOtherWay_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiVelocity = MidiVelocity.From(43);
        var result = 69.Equals(midiVelocity);
        result.Should().BeFalse();
    }
}