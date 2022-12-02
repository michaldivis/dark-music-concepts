using FluentAssertions;

namespace DarkMusicConcepts.Units.Tests;

public class UnitTests
{
    private class DemoUnit : Unit<int, DemoUnit>
    {
        public const int MinValue = 0;
        public const int MaxValue = int.MaxValue;

        public static DemoUnit Min { get; } = From(MinValue);
        public static DemoUnit Max { get; } = From(MaxValue);

        protected override int GetMinValue() => MinValue;
        protected override int GetMaxValue() => MaxValue;
    }

    [Fact]
    public void SimpleExample_ShouldWork()
    {
        var item1 = DemoUnit.From(123456);
        var item2 = DemoUnit.From(123456);
        var item3 = DemoUnit.From(456789);

        item1.Should().Be(item2);
        item1.GetHashCode().Should().Be(item2.GetHashCode());

        item1.Should().NotBe(item3);
        item1.GetHashCode().Should().NotBe(item3.GetHashCode());
    }

    #region Validate

    [Fact]
    public void Validate_ShouldWork()
    {
        var act = new Action(() => DemoUnit.From(-99));
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion

    #region TryValidate

    [Fact]
    public void TryValidate_ShouldReturnFalse_WhenInvalid()
    {
        var result = DemoUnit.TryFrom(-99, out var value);
        result.Should().BeFalse();
        value.Should().BeNull();
    }

    [Fact]
    public void TryValidate_ShouldReturnTrue_WhenValid()
    {
        var result = DemoUnit.TryFrom(25, out var value);
        result.Should().BeTrue();
        value.Should().NotBeNull();
    }

    #endregion

    #region ToString

    [Fact]
    public void ToString_ShouldValueToString()
    {
        var value = 123;
        var result = DemoUnit.From(value).ToString();
        result.Should().Be(value.ToString());
    }

    #endregion

    #region Equality

    [Fact]
    public void StaticEquals_ShouldWork()
    {
        DemoUnit nullItem = null!;
        var item1 = DemoUnit.From(123456);
        var item2 = DemoUnit.From(123456);
        var item3 = DemoUnit.From(456789);

        (DemoUnit.Equals(item1, item2)).Should().BeTrue();
        (DemoUnit.Equals(item2, item1)).Should().BeTrue();

        (DemoUnit.Equals(item1, item3)).Should().BeFalse();
        (DemoUnit.Equals(item1, nullItem)).Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldWork()
    {
        DemoUnit nullItem = null!;
        var item1 = DemoUnit.From(123456);
        var item2 = DemoUnit.From(123456);
        var item3 = DemoUnit.From(456789);

        (item1.Equals(item2)).Should().BeTrue();
        (item2.Equals(item1)).Should().BeTrue();

        (item1.Equals(item3)).Should().BeFalse();
        (item1.Equals(nullItem)).Should().BeFalse();
    }

    [Fact]
    public void EqualOperator_ShouldWork()
    {
        DemoUnit nullItem = null!;
        var item1 = DemoUnit.From(123456);
        var item2 = DemoUnit.From(123456);
        var item3 = DemoUnit.From(456789);

        (item1 == item2).Should().BeTrue();
        (item2 == item1).Should().BeTrue();

        (item1 == item3).Should().BeFalse();
        (item1 == nullItem).Should().BeFalse();
        (nullItem == item1).Should().BeFalse();
    }

    [Fact]
    public void NotEqualOperator_ShouldWork()
    {
        DemoUnit nullItem = null!;
        var item1 = DemoUnit.From(123456);
        var item2 = DemoUnit.From(123456);
        var item3 = DemoUnit.From(456789);

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
        var normal = DemoUnit.From(123456);

        DemoUnit nullItem = null!;
        var little = DemoUnit.From(10);
        var alsoNormal = DemoUnit.From(123456);
        var large = DemoUnit.From(456789);

        normal.CompareTo(nullItem).Should().Be(1);
        normal.CompareTo(little).Should().Be(1);
        normal.CompareTo(alsoNormal).Should().Be(0);
        normal.CompareTo(large).Should().Be(-1);
    }

    [Fact]
    public void CompareToObject_ShouldWork()
    {
        var normal = DemoUnit.From(123456);

        object nullItem = null!;
        object anotherType = "I'm not a Demo Unit...";
        object little = DemoUnit.From(10);
        object alsoNormal = DemoUnit.From(123456);
        object large = DemoUnit.From(456789);

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
        var normal = DemoUnit.From(123456);

        DemoUnit nullItem = null!;
        var little = DemoUnit.From(10);
        var alsoNormal = DemoUnit.From(123456);
        var large = DemoUnit.From(456789);

        (normal > nullItem).Should().BeTrue();
        (normal > little).Should().BeTrue();
        (normal > alsoNormal).Should().BeFalse();
        (normal > large).Should().BeFalse();
        (nullItem > normal).Should().BeFalse();
    }

    [Fact]
    public void GreaterThanOrEqualOperator_ShouldWork()
    {
        var normal = DemoUnit.From(123456);

        DemoUnit nullItem = null!;
        var little = DemoUnit.From(10);
        var alsoNormal = DemoUnit.From(123456);
        var large = DemoUnit.From(456789);

        (normal >= nullItem).Should().BeTrue();
        (normal >= little).Should().BeTrue();
        (normal >= alsoNormal).Should().BeTrue();
        (normal >= large).Should().BeFalse();
        (nullItem >= normal).Should().BeFalse();
    }

    [Fact]
    public void SmallerThanOperator_ShouldWork()
    {
        var normal = DemoUnit.From(123456);

        DemoUnit nullItem = null!;
        var little = DemoUnit.From(10);
        var alsoNormal = DemoUnit.From(123456);
        var large = DemoUnit.From(456789);

        (normal < nullItem).Should().BeFalse();
        (normal < little).Should().BeFalse();
        (normal < alsoNormal).Should().BeFalse();
        (normal < large).Should().BeTrue();
        (nullItem < normal).Should().BeTrue();
    }

    [Fact]
    public void SmallerThanOrEqualOperator_ShouldWork()
    {
        var normal = DemoUnit.From(123456);

        DemoUnit nullItem = null!;
        var little = DemoUnit.From(10);
        var alsoNormal = DemoUnit.From(123456);
        var large = DemoUnit.From(456789);

        (normal <= nullItem).Should().BeFalse();
        (normal <= little).Should().BeFalse();
        (normal <= alsoNormal).Should().BeTrue();
        (normal <= large).Should().BeTrue();
        (nullItem <= normal).Should().BeTrue();
    }

    #endregion
}