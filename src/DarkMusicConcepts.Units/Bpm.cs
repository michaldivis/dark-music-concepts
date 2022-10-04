using ValueOf;

namespace DarkMusicConcepts.Units;

public class Bpm : ValueOf<int, Bpm>
{
    public const int Min = 1;
    public const int Max = int.MaxValue;

    protected override void Validate()
    {
        if (!IsValidBpmValue(Value))
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, $"{nameof(Value)} has to be within range {Min}-{Max}");
        }
    }

    protected override bool TryValidate()
    {
        return IsValidBpmValue(Value);
    }

    private static bool IsValidBpmValue(int bpm)
    {
        return bpm >= Min && bpm <= Max;
    }

    public static implicit operator Bpm(int value)
    {
        return From(value);
    }

    public static bool operator ==(Bpm bpm1, int bpm2)
    {
        if (bpm1 is null)
        {
            return false;
        }

        return bpm1.Value == bpm2;
    }

    public static bool operator !=(Bpm bpm1, int bpm2)
    {
        return !(bpm1 == bpm2);
    }

    public static bool operator ==(int bpm1, Bpm bpm2)
    {
        if (bpm2 is null)
        {
            return false;
        }

        return bpm2.Value == bpm1;
    }

    public static bool operator !=(int bpm1, Bpm bpm2)
    {
        return !(bpm2 == bpm1);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Bpm);
    }

    public bool Equals(Bpm? other)
    {
        if (other is not null)
        {
            return Value == other!.Value;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}
