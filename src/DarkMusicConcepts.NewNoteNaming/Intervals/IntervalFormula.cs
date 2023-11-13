namespace DarkMusicConcepts.NewNoteNaming.Intervals;

public class IntervalFormula
{
    public IntervalFormula(IntervalQuality quality, IntervalQuantity quantity)
    {
        Quality = quality;
        Quantity = quantity;
    }

    public IntervalQuality Quality { get; }
    public IntervalQuantity Quantity { get; }

    public override string ToString()
    {
        return $"{Quality.ToString()} {Quantity}";
    }
}
