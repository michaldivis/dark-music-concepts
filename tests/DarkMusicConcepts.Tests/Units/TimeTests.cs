using FluentAssertions;

namespace DarkMusicConcepts.Units.Tests;

public class TimeTests
{
    [Fact]
    public void From_ShouldThrow_WhenLessThanMin()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Time.From(Time.Min - 1));
    }

    [Fact]
    public void TryFrom_ShouldFail_WhenLessThanMin()
    {
        var success = Time.TryFrom(Time.Min - 1, out var invalidTime);
        success.Should().Be(false);
        invalidTime.Should().Be(null);
    }

    [Fact]
    public void Comparison_ShouldReturnTrue_WhenValueMatches()
    {
        var time1 = Time.From(43);
        var time2 = Time.From(43);
        var result = time1 == time2;
        result.Should().BeTrue();
    }

    [Fact]
    public void Comparison_ShouldReturnFalse_WhenValueDoesntMatch()
    {
        var time1 = Time.From(43);
        var time2 = Time.From(69);
        var result = time1 == time2;
        result.Should().BeFalse();
    }

    [Fact]
    public void AdditionOperatorWithSelf_ShouldWork()
    {
        var time1 = Time.From(15);
        var time2 = Time.From(6);
        var result = time1 + time2;
        result.Value.Should().Be(21);
    }

    [Fact]
    public void SubtractionOperatorWithSelf_ShouldWork()
    {
        var time1 = Time.From(15);
        var time2 = Time.From(6);
        var result = time1 - time2;
        result.Value.Should().Be(9);
    }

    [Fact]
    public void MultiplicationOperatorWithInt_ShouldWork()
    {
        var time = Time.From(15);
        var result = time * 3;
        result.Value.Should().Be(45);
    }

    [Fact]
    public void CalculatedProperties_NoneShouldThrowWhenAccessed()
    {
        var time = Time.FromQuarterNotes(1);

        _ = time.Ticks;

        _ = time.Bars;

        _ = time.WholeNotes;
        _ = time.HalfNotes;
        _ = time.QuarterNotes;
        _ = time.EightNotes;
        _ = time.SixteenthNotes;
        _ = time.ThirtySecondNotes;
        _ = time.SixtyForthNotes;

        _ = time.WholeNoteTriplets;
        _ = time.HalfNoteTriplets;
        _ = time.QuarterNoteTriplets;
        _ = time.EightNoteTriplets;
        _ = time.SixteenthNoteTriplets;
        _ = time.ThirtySecondNoteTriplets;
        _ = time.SixtyForthNoteTriplets;

        _ = time.WholeDottedNotes;
        _ = time.HalfDottedNotes;
        _ = time.QuarterDottedNotes;
        _ = time.EightDottedNotes;
        _ = time.SixteenthDottedNotes;
        _ = time.ThirtySecondDottedNotes;
        _ = time.SixtyForthDottedNotes;
    }

    [Fact]
    public void StaticInstances_NoneShouldThrowWhenAccessed()
    {
        _ = Time.Zero;

        _ = Time.Bar;

        _ = Time.WholeNote;
        _ = Time.HalfNote;
        _ = Time.QuarterNote;
        _ = Time.EightNote;
        _ = Time.SixteenthNote;
        _ = Time.ThirtySecondNote;
        _ = Time.SixtyForthNote;

        _ = Time.WholeNoteTriplet;
        _ = Time.HalfNoteTriplet;
        _ = Time.QuarterNoteTriplet;
        _ = Time.EightNoteTriplet;
        _ = Time.SixteenthNoteTriplet;
        _ = Time.ThirtySecondNoteTriplet;
        _ = Time.SixtyForthNoteTriplet;

        _ = Time.WholeNoteDotted;
        _ = Time.HalfNoteDotted;
        _ = Time.QuarterNoteDotted;
        _ = Time.EightNoteDotted;
        _ = Time.SixteenthNoteDotted;
        _ = Time.ThirtySecondNoteDotted;
        _ = Time.SixtyForthNoteDotted;
    }

    [Fact]
    public void StaticFromMethods_NoneShouldThrowWhenUsed()
    {
        _ = Time.FromBars(1);

        _ = Time.FromWholeNotes(1);
        _ = Time.FromHalfNotes(1);
        _ = Time.FromQuarterNotes(1);
        _ = Time.FromEightNotes(1);
        _ = Time.FromSixteenthNotes(1);
        _ = Time.FromThirtySecondNotes(1);
        _ = Time.FromSixtyForthNotes(1);

        _ = Time.FromWholeNoteTriplets(1);
        _ = Time.FromHalfNoteTriplets(1);
        _ = Time.FromQuarterNoteTriplets(1);
        _ = Time.FromEightNoteTriplets(1);
        _ = Time.FromSixteenthNoteTriplets(1);
        _ = Time.FromThirtySecondNoteTriplets(1);
        _ = Time.FromSixtyForthNoteTriplets(1);

        _ = Time.FromWholeNoteDotteds(1);
        _ = Time.FromHalfNoteDotteds(1);
        _ = Time.FromQuarterNoteDotteds(1);
        _ = Time.FromEightNoteDotteds(1);
        _ = Time.FromSixteenthNoteDotteds(1);
        _ = Time.FromThirtySecondNoteDotteds(1);
        _ = Time.FromSixtyForthNoteDotteds(1);
    }

    [Theory]
    [InlineData(4, 120, 500)]
    [InlineData(3, 120, 375)]
    [InlineData(2, 120, 250)]
    [InlineData(1, 120, 125)]
    [InlineData(4, 90, 666.66)]
    [InlineData(3, 90, 500)]
    [InlineData(2, 90, 333.33)]
    [InlineData(1, 90, 166.66)]
    [InlineData(4, 67, 895.52)]
    [InlineData(3, 67, 671.64)]
    [InlineData(2, 67, 447.76)]
    [InlineData(1, 67, 223.88)]
    [InlineData(4, 186, 322.58)]
    [InlineData(3, 186, 241.93)]
    [InlineData(2, 186, 161.29)]
    [InlineData(1, 186, 80.64)]
    public void GetDuration_ShouldWork(int amountOfSixteenthNotes, int bpm, double expectedDurationMs)
    {
        var time = Time.FromSixteenthNotes(amountOfSixteenthNotes);
        var tempo = Bpm.From(bpm);
        var result = time.GetDuration(tempo);
        result.TotalMilliseconds.Should().BeApproximately(expectedDurationMs, 0.01d);
    }
}