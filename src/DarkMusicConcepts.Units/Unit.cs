using System.Numerics;

namespace DarkMusicConcepts;

/// <summary>
/// Number value object base class with a specific value range from Min to Max
/// </summary>
/// <typeparam name="TValue">The actual value</typeparam>
/// <typeparam name="TThis">Self</typeparam>
public abstract class Unit<TValue, TThis> : IComparable, IComparable<Unit<TValue, TThis>>, IEquatable<Unit<TValue, TThis>>
    where TThis : Unit<TValue, TThis>, IUnit<TValue, TThis>
    where TValue : struct, IComparable, IComparable<TValue>, IEquatable<TValue>
{
    public static TThis Min { get; } = TThis.Create(TThis.MinValue);
    public static TThis Max { get; } = TThis.Create(TThis.MaxValue);

    protected Unit(TValue value)
    {
        Value = value;
    }

    public TValue Value { get; init; }

    public static TThis From(TValue value)
    {
        var unit = TThis.Create(value);

        unit.Validate();

        return unit;
    }

    public static bool TryFrom(TValue value, out TThis unit)
    {
        if (!IsValidValue(value))
        {
            unit = null!;
            return false;
        }

        unit = TThis.Create(value);

        return true;
    }

    public static bool IsValidValue(TValue value)
    {
        if (value.CompareTo(TThis.MinValue) < 0)
        {
            return false;
        }

        if (value.CompareTo(TThis.MaxValue) > 0)
        {
            return false;
        }

        return true;
    }

    protected void Validate()
    {
        if (!IsValidValue(Value))
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, $"{nameof(Value)} has to be within range {TThis.MinValue}-{TThis.MaxValue}");
        }
    }

    #region Equality

    private static bool EqualsInternal(Unit<TValue, TThis>? a, Unit<TValue, TThis>? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return EqualityComparer<TValue>.Default.Equals(a.Value, b.Value);
    }

    public bool Equals(Unit<TValue, TThis>? other)
    {
        if (other is null)
        {
            return false;
        }

        return EqualsInternal(this, other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is not Unit<TValue, TThis> other)
        {
            return false;
        }

        return EqualsInternal(this, other);
    }

    public static bool operator ==(Unit<TValue, TThis>? a, Unit<TValue, TThis>? b)
    {
        return EqualsInternal(a, b);
    }

    public static bool operator !=(Unit<TValue, TThis>? a, Unit<TValue, TThis>? b)
    {
        return !EqualsInternal(a, b);
    }

    #endregion

    #region Comparison

    private static int CompareToInteral(Unit<TValue, TThis>? a, Unit<TValue, TThis>? b)
    {
        if (a is null && b is null)
        {
            return 0;
        }

        if (a is null)
        {
            return -1;
        }

        if (b is null)
        {
            return 1;
        }

        return a.Value.CompareTo(b.Value);
    }

    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (ReferenceEquals(this, obj))
        {
            return 0;
        }

        if (obj is not Unit<TValue, TThis> other)
        {
            throw new ArgumentException($"Object must be of type {typeof(TValue).Name}", nameof(obj));
        }

        return CompareToInteral(this, other);
    }

    public int CompareTo(Unit<TValue, TThis>? other)
    {
        return CompareToInteral(this, other);
    }

    public static bool operator >(Unit<TValue, TThis>? a, Unit<TValue, TThis>? b)
    {
        return CompareToInteral(a, b) > 0;
    }

    public static bool operator <(Unit<TValue, TThis>? a, Unit<TValue, TThis>? b)
    {
        return CompareToInteral(a, b) < 0;
    }

    public static bool operator >=(Unit<TValue, TThis>? a, Unit<TValue, TThis>? b)
    {
        return CompareToInteral(a, b) >= 0;
    }

    public static bool operator <=(Unit<TValue, TThis>? a, Unit<TValue, TThis>? b)
    {
        return CompareToInteral(a, b) <= 0;
    }

    #endregion

    public override int GetHashCode() => EqualityComparer<TValue>.Default.GetHashCode(Value);

    public override string ToString() => Value.ToString() ?? string.Empty;
}