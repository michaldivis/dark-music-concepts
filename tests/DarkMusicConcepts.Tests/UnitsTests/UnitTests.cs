namespace DarkMusicConcepts.Tests.UnitsTests;

public class UnitTests
{
    [Fact]
    public void SimpleExample_ShouldWork()
    {
        var item1 = Bpm.From(123456);
        var item2 = Bpm.From(123456);
        var item3 = Bpm.From(456789);

        item1.Should().Be(item2);
        item1.GetHashCode().Should().Be(item2.GetHashCode());

        item1.Should().NotBe(item3);
        item1.GetHashCode().Should().NotBe(item3.GetHashCode());
    }

    #region Creation

    [Fact]
    public void From_ShouldThrow_WhenLessThanMin()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Bpm.From(Bpm.MinValue - 1));
    }

    [Fact]
    public void TryFrom_ShouldFail_WhenLessThanMin()
    {
        var success = Bpm.TryFrom(Bpm.MinValue - 1, out var invalidBpm);
        success.Should().Be(false);
        invalidBpm.Should().Be(null!);
    }

    #endregion

    #region Validate

    [Fact]
    public void Validate_ShouldWork()
    {
        var act = new Action(() => Bpm.From(-99));
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion

    #region TryValidate

    [Fact]
    public void TryValidate_ShouldReturnFalse_WhenInvalid()
    {
        var result = Bpm.TryFrom(-99, out var value);
        result.Should().BeFalse();
        value.Should().BeNull();
    }

    [Fact]
    public void TryValidate_ShouldReturnTrue_WhenValid()
    {
        var result = Bpm.TryFrom(25, out var value);
        result.Should().BeTrue();
        value.Should().NotBeNull();
    }

    #endregion

    #region ToString

    [Fact]
    public void ToString_ShouldValueToString()
    {
        var value = 123;
        var result = Bpm.From(value).ToString();
        result.Should().Be(value.ToString());
    }

    #endregion

    #region Equality

    [Fact]
    public void StaticEquals_ShouldWork()
    {
        Bpm nullItem = null!;
        var item1 = Bpm.From(123456);
        var item2 = Bpm.From(123456);
        var item3 = Bpm.From(456789);

        (Bpm.Equals(item1, item2)).Should().BeTrue();
        (Bpm.Equals(item2, item1)).Should().BeTrue();

        (Bpm.Equals(item1, item3)).Should().BeFalse();
        (Bpm.Equals(item1, nullItem)).Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldWork()
    {
        Bpm nullItem = null!;
        var item1 = Bpm.From(123456);
        var item2 = Bpm.From(123456);
        var item3 = Bpm.From(456789);

        (item1.Equals(item2)).Should().BeTrue();
        (item2.Equals(item1)).Should().BeTrue();

        (item1.Equals(item3)).Should().BeFalse();
        (item1.Equals(nullItem)).Should().BeFalse();
    }

    [Fact]
    public void EqualOperator_ShouldWork()
    {
        Bpm nullItem = null!;
        var item1 = Bpm.From(123456);
        var item2 = Bpm.From(123456);
        var item3 = Bpm.From(456789);

        (item1 == item2).Should().BeTrue();
        (item2 == item1).Should().BeTrue();

        (item1 == item3).Should().BeFalse();
        (item1 == nullItem).Should().BeFalse();
        (nullItem == item1).Should().BeFalse();
    }

    [Fact]
    public void NotEqualOperator_ShouldWork()
    {
        Bpm nullItem = null!;
        var item1 = Bpm.From(123456);
        var item2 = Bpm.From(123456);
        var item3 = Bpm.From(456789);

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
        var normal = Bpm.From(123456);

        Bpm nullItem = null!;
        var little = Bpm.From(10);
        var alsoNormal = Bpm.From(123456);
        var large = Bpm.From(456789);

        normal.CompareTo(nullItem).Should().Be(1);
        normal.CompareTo(little).Should().Be(1);
        normal.CompareTo(alsoNormal).Should().Be(0);
        normal.CompareTo(large).Should().Be(-1);
    }

    [Fact]
    public void CompareToObject_ShouldWork()
    {
        var normal = Bpm.From(123456);

        object nullItem = null!;
        object anotherType = "I'm not a Bpm...";
        object little = Bpm.From(10);
        object alsoNormal = Bpm.From(123456);
        object large = Bpm.From(456789);

        normal.CompareTo(nullItem).Should().Be(1);
        normal.CompareTo(little).Should().Be(1);
        normal.CompareTo(alsoNormal).Should().Be(0);
        normal.CompareTo(large).Should().Be(-1);

        Action act = () => normal.CompareTo(anotherType);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GreaterThanOperator_ShouldWork()
    {
        var normal = Bpm.From(123456);

        Bpm nullItem = null!;
        var little = Bpm.From(10);
        var alsoNormal = Bpm.From(123456);
        var large = Bpm.From(456789);

        (normal > nullItem).Should().BeTrue();
        (normal > little).Should().BeTrue();
        (normal > alsoNormal).Should().BeFalse();
        (normal > large).Should().BeFalse();
        (nullItem > normal).Should().BeFalse();
    }

    [Fact]
    public void GreaterThanOrEqualOperator_ShouldWork()
    {
        var normal = Bpm.From(123456);

        Bpm nullItem = null!;
        var little = Bpm.From(10);
        var alsoNormal = Bpm.From(123456);
        var large = Bpm.From(456789);

        (normal >= nullItem).Should().BeTrue();
        (normal >= little).Should().BeTrue();
        (normal >= alsoNormal).Should().BeTrue();
        (normal >= large).Should().BeFalse();
        (nullItem >= normal).Should().BeFalse();
    }

    [Fact]
    public void SmallerThanOperator_ShouldWork()
    {
        var normal = Bpm.From(123456);

        Bpm nullItem = null!;
        var little = Bpm.From(10);
        var alsoNormal = Bpm.From(123456);
        var large = Bpm.From(456789);

        (normal < nullItem).Should().BeFalse();
        (normal < little).Should().BeFalse();
        (normal < alsoNormal).Should().BeFalse();
        (normal < large).Should().BeTrue();
        (nullItem < normal).Should().BeTrue();
    }

    [Fact]
    public void SmallerThanOrEqualOperator_ShouldWork()
    {
        var normal = Bpm.From(123456);

        Bpm nullItem = null!;
        var little = Bpm.From(10);
        var alsoNormal = Bpm.From(123456);
        var large = Bpm.From(456789);

        (normal <= nullItem).Should().BeFalse();
        (normal <= little).Should().BeFalse();
        (normal <= alsoNormal).Should().BeTrue();
        (normal <= large).Should().BeTrue();
        (nullItem <= normal).Should().BeTrue();
    }

    #endregion
}