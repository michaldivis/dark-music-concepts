namespace DarkMusicConcepts.NewNoteNaming.Intervals;

public class IntervalQuantity
{
    public enum IntervalName : byte
    {
        Unison,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Octave,
        Ninth,
        Tenth,
        Eleventh,
        Twelfth,
        Thirteenth,
        Fourteenth,
        Fifteenth
    }

    public IntervalQuantity(IntervalName name)
    {
        Name = name;
    }

    public IntervalName Name { get; }

    public string GetName(int quantity)
    {
        if (quantity < 1 || quantity >= Enum.GetValues(typeof(IntervalName)).Length + 1)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Invalid interval quantity.");

        return ((IntervalName)(quantity - 1)).ToString();
    }
}
