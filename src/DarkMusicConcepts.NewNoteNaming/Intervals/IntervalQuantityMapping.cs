namespace DarkMusicConcepts.NewNoteNaming.Intervals;

public static class IntervalQuantityMapping
{
    public static string MapToIntervalString(int quantity)
    {
        return quantity switch
        {
            1 => "unison",
            2 => "second",
            3 => "third",
            4 => "fourth",
            5 => "fifth",
            6 => "sixth",
            7 => "seventh",
            8 => "octave",
            9 => "ninth",
            // Add more cases as needed
            _ => throw new ArgumentOutOfRangeException(nameof(quantity), "Invalid interval quantity.")
        };
    }
}
