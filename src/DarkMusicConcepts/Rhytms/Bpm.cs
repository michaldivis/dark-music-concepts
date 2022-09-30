using ValueOf;

namespace DarkMusicConcepts.Rhytms;

public class Bpm : ValueOf<int, Bpm>
{
    protected override void Validate()
    {
        if(Value < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(Value), Value, "BPM cannot be less than 1");
        }
    }

    protected override bool TryValidate()
    {
        return Value > 0;
    }
}