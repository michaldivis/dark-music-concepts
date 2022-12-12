namespace DarkMusicConcepts;

public class IntervalTests
{
    #region Equality

    [Fact]
    public void Equals_ShouldWork()
    {
        Interval nullItem = null!;
        var item1 = Intervals.MinorSecond;
        var item2 = Intervals.MinorSecond;
        var item3 = Intervals.MajorThird;

        (item1.Equals(item2)).Should().BeTrue();
        (item2.Equals(item1)).Should().BeTrue();

        (item1.Equals(item3)).Should().BeFalse();
        (item1.Equals(nullItem)).Should().BeFalse();
    }

    [Fact]
    public void EqualOperator_ShouldWork()
    {
        Interval nullItem = null!;
        var item1 = Intervals.MinorSecond;
        var item2 = Intervals.MinorSecond;
        var item3 = Intervals.MajorThird;

        (item1 == item2).Should().BeTrue();
        (item2 == item1).Should().BeTrue();

        (item1 == item3).Should().BeFalse();
        (item1 == nullItem).Should().BeFalse();
        (nullItem == item1).Should().BeFalse();
    }

    [Fact]
    public void NotEqualOperator_ShouldWork()
    {
        Interval nullItem = null!;
        var item1 = Intervals.MinorSecond;
        var item2 = Intervals.MinorSecond;
        var item3 = Intervals.MajorThird;

        (item1 != item2).Should().BeFalse();
        (item2 != item1).Should().BeFalse();

        (item1 != item3).Should().BeTrue();
        (item1 != nullItem).Should().BeTrue();
        (nullItem != item1).Should().BeTrue();
    }

    #endregion

    #region Comparison

    [Fact]
    public void CompareTo_ShouldWork()
    {
        var normal = Intervals.PerfectFifth;

        Interval nullItem = null!;
        var little = Intervals.MajorSecond;
        var alsoNormal = Intervals.PerfectFifth;
        var large = Intervals.MinorSeventh;

        normal.CompareTo(nullItem).Should().Be(1);
        normal.CompareTo(little).Should().Be(1);
        normal.CompareTo(alsoNormal).Should().Be(0);
        normal.CompareTo(large).Should().Be(-1);
    }

    [Fact]
    public void GreaterThanOperator_ShouldWork()
    {
        var normal = Intervals.PerfectFifth;

        Interval nullItem = null!;
        var little = Intervals.MajorSecond;
        var alsoNormal = Intervals.PerfectFifth;
        var large = Intervals.MinorSeventh;

        (normal > nullItem).Should().BeTrue();
        (normal > little).Should().BeTrue();
        (normal > alsoNormal).Should().BeFalse();
        (normal > large).Should().BeFalse();
        (nullItem > normal).Should().BeFalse();
    }

    [Fact]
    public void GreaterThanOrEqualOperator_ShouldWork()
    {
        var normal = Intervals.PerfectFifth;

        Interval nullItem = null!;
        var little = Intervals.MajorSecond;
        var alsoNormal = Intervals.PerfectFifth;
        var large = Intervals.MinorSeventh;

        (normal >= nullItem).Should().BeTrue();
        (normal >= little).Should().BeTrue();
        (normal >= alsoNormal).Should().BeTrue();
        (normal >= large).Should().BeFalse();
        (nullItem >= normal).Should().BeFalse();
    }

    [Fact]
    public void SmallerThanOperator_ShouldWork()
    {
        var normal = Intervals.PerfectFifth;

        Interval nullItem = null!;
        var little = Intervals.MajorSecond;
        var alsoNormal = Intervals.PerfectFifth;
        var large = Intervals.MinorSeventh;

        (normal < nullItem).Should().BeFalse();
        (normal < little).Should().BeFalse();
        (normal < alsoNormal).Should().BeFalse();
        (normal < large).Should().BeTrue();
        (nullItem < normal).Should().BeTrue();
    }

    [Fact]
    public void SmallerThanOrEqualOperator_ShouldWork()
    {
        var normal = Intervals.PerfectFifth;

        Interval nullItem = null!;
        var little = Intervals.MajorSecond;
        var alsoNormal = Intervals.PerfectFifth;
        var large = Intervals.MinorSeventh;

        (normal <= nullItem).Should().BeFalse();
        (normal <= little).Should().BeFalse();
        (normal <= alsoNormal).Should().BeTrue();
        (normal <= large).Should().BeTrue();
        (nullItem <= normal).Should().BeTrue();
    }

    #endregion
}