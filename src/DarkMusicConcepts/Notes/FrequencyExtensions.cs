namespace DarkMusicConcepts.Notes;
internal static class FrequencyExtensions
{
    internal static bool EqualsWithPrecision(this Frequency a, Frequency b, double precision)
    {
        return Math.Abs(a.Value - b.Value) <= precision;
    }
}
