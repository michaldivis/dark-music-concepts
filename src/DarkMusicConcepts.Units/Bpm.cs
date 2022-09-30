using ValueOf;

namespace DarkMusicConcepts.Units;

public class Bpm : ValueOf<int, Bpm>
{
    public const int Min = 1;

    protected override void Validate()
    {
        if (Value < Min)
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, "BPM cannot be less than 1");
        }
    }

    protected override bool TryValidate()
    {
        if (Value < Min)
        {
            return false;
        }

        return true;
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
