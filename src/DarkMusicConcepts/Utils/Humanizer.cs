namespace DarkMusicConcepts.Utils;
internal static class Humanizer
{
    public static string AddOrdinal(int num)
    {
        if (num <= 0)
        {
            return num.ToString();
        }

        switch (num % 100)
        {
            case 11:
            case 12:
            case 13:
                return num + "th";
            default:
                break;
        }

        return (num % 10) switch
        {
            1 => num + "st",
            2 => num + "nd",
            3 => num + "rd",
            _ => num + "th",
        };
    }

    public static string Humanize(Accident accident)
    {
        return accident switch
        {
            Accident.Flat => "b",
            Accident.None => "",
            Accident.Sharp => "#",
            _ => throw new NotImplementedException()
        };
    }
}
