namespace DarkMusicConcepts.Units;

/// <summary>
/// Number value object base class with a specific value range from Min to Max
/// </summary>
/// <typeparam name="TValue">The actual value</typeparam>
/// <typeparam name="TThis">Self</typeparam>
public abstract class Unit<TValue, TThis> : IComparable<Unit<TValue, TThis>>, IEquatable<Unit<TValue, TThis>>
    where TThis : Unit<TValue, TThis>, new()
    where TValue : IComparable<TValue>, IEquatable<TValue>
{
    protected abstract TValue MinValue { get; }
    protected abstract TValue MaxValue { get; }

    private void Validate()
    {
        if (!IsValidValue(Value))
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, $"{nameof(Value)} has to be within range {MinValue}-{MaxValue}");
        }
    }

    private bool TryValidate()
    {
        return IsValidValue(Value);
    }

    private bool IsValidValue(TValue? value)
    {
        if(value is null)
        {
            return false;
        }

        if (value.CompareTo(MinValue) < 0)
        {
            return false;
        }

        if (value.CompareTo(MaxValue) > 0)
        {
            return false;
        }

        return true;
    }

    public TValue Value { get; protected set; }

    public static TThis From(TValue item)
    {
        var x = new TThis
        {
            Value = item
        };

        x.Validate();

        return x;
    }

    public static bool TryFrom(TValue item, out TThis thisValue)
    {
        var x = new TThis
        {
            Value = item
        };

        thisValue = x.TryValidate()
           ? x
           : null!;

        return thisValue is not null;
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

        if(obj is not Unit<TValue, TThis> other)
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

    public override int GetHashCode()
    {
        return EqualityComparer<TValue>.Default.GetHashCode(Value);
    }

    public override string ToString()
    {
        if (Value is null)
        {
            return string.Empty;
        }

        return Value.ToString() ?? string.Empty;
    }
}