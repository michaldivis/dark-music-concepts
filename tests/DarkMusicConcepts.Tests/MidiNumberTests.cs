using FluentAssertions;

namespace DarkMusicConcepts.Tests;
public class MidiNumberTests
{
    [Fact]
    public void Creation_ShouldThrow_WhenLessThanZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => MidiNumber.From(-1));
    }

    //this test is currently disabled because the library allows creating of notes from the 9th octave, which would reach MIDI numbers over 127
    //[Fact]
    //public void Creation_ShouldThrow_WhenGreaterThan127()
    //{
    //    Assert.Throws<ArgumentOutOfRangeException>(() => MidiNumber.From(128));
    //}

    [Fact]
    public void ImplicitCreation_ShouldWork_WithInt()
    {
        MidiNumber midiNumber = 43;
        midiNumber.Value.Should().Be(43);
    }

    [Fact]
    public void Comparison_ShouldReturnTrue_WhenValueMatches()
    {
        var midiNumber1 = MidiNumber.From(43);
        var midiNumber2 = MidiNumber.From(43);
        var result = midiNumber1 == midiNumber2;
        result.Should().BeTrue();
    }

    [Fact]
    public void Comparison_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiNumber1 = MidiNumber.From(43);
        var midiNumber2 = MidiNumber.From(69);
        var result = midiNumber1 == midiNumber2;
        result.Should().BeFalse();
    }

    [Fact]
    public void ComparisonWithInt_ShouldReturnTrue_WhenValueMatches()
    {
        var midiNumber = MidiNumber.From(43);
        var result = midiNumber == 43;
        result.Should().BeTrue();
    }

    [Fact]
    public void ComparisonWithInt_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiNumber = MidiNumber.From(43);
        var result = midiNumber == 69;
        result.Should().BeFalse();
    }

    [Fact]
    public void ComparisonWithIntOtherWay_ShouldReturnTrue_WhenValueMatches()
    {
        var midiNumber = MidiNumber.From(43);
        var result = 43 == midiNumber;
        result.Should().BeTrue();
    }

    [Fact]
    public void ComparisonWithIntOtherWay_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiNumber = MidiNumber.From(43);
        var result = 69 == midiNumber;
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsWithInt_ShouldReturnTrue_WhenValueMatches()
    {
        var midiNumber = MidiNumber.From(43);
        var result = midiNumber.Equals(43);
        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsWithInt_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiNumber = MidiNumber.From(43);
        var result = midiNumber.Equals(69);
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsWithIntOtherWay_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var midiNumber = MidiNumber.From(43);
        var result = 69.Equals(midiNumber);
        result.Should().BeFalse();
    }
}
