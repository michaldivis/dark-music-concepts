namespace DarkMusicConcepts.Rhytms;
public class TimeUnit
{
    private readonly int _ticks;

    private const int TicksPerQuarterNote = 960;
    private const int TicksPerSixteenthNote = 240;
    private const int TicksPerSixteenthNoteTriplet = 160;
    private const int TicksPerSixteenthNoteDotted = 360;

    private TimeUnit(int ticks)
    {
        _ticks = ticks;
    }

    public int Ticks => _ticks;

    public static readonly TimeUnit Bar = new(TicksPerSixteenthNote * 16 * 4);
    public static readonly TimeUnit WholeNote = new(TicksPerSixteenthNote * 16);
    public static readonly TimeUnit HalfNote = new(TicksPerSixteenthNote * 8);
    public static readonly TimeUnit QuarterNote = new(TicksPerSixteenthNote * 4);
    public static readonly TimeUnit EightNote = new(TicksPerSixteenthNote * 2);
    public static readonly TimeUnit SixteenthNote = new(TicksPerSixteenthNote);
    public static readonly TimeUnit ThirtySecondNote = new(TicksPerSixteenthNote / 2);
    public static readonly TimeUnit SixtyForthNote = new(TicksPerSixteenthNote / 4);

    public static readonly TimeUnit BarTriplet = new(TicksPerSixteenthNoteTriplet * 16 * 4);
    public static readonly TimeUnit WholeNoteTriplet = new(TicksPerSixteenthNoteTriplet * 16);
    public static readonly TimeUnit HalfNoteTriplet = new(TicksPerSixteenthNoteTriplet * 8);
    public static readonly TimeUnit QuarterNoteTriplet = new(TicksPerSixteenthNoteTriplet * 4);
    public static readonly TimeUnit EightNoteTriplet = new(TicksPerSixteenthNoteTriplet * 2);
    public static readonly TimeUnit SixteenthNoteTriplet = new(TicksPerSixteenthNoteTriplet);
    public static readonly TimeUnit ThirtySecondNoteTriplet = new(TicksPerSixteenthNoteTriplet / 2);
    public static readonly TimeUnit SixtyForthNoteTriplet = new(TicksPerSixteenthNoteTriplet / 4);

    public static readonly TimeUnit BarDotted = new(TicksPerSixteenthNoteDotted * 16 * 4);
    public static readonly TimeUnit WholeNoteDotted = new(TicksPerSixteenthNoteDotted * 16);
    public static readonly TimeUnit HalfNoteDotted = new(TicksPerSixteenthNoteDotted * 8);
    public static readonly TimeUnit QuarterNoteDotted = new(TicksPerSixteenthNoteDotted * 4);
    public static readonly TimeUnit EightNoteDotted = new(TicksPerSixteenthNoteDotted * 2);
    public static readonly TimeUnit SixteenthNoteDotted = new(TicksPerSixteenthNoteDotted);
    public static readonly TimeUnit ThirtySecondNoteDotted = new(TicksPerSixteenthNoteDotted / 2);
    public static readonly TimeUnit SixtyForthNoteDotted = new(TicksPerSixteenthNoteDotted / 4);

    /// <summary>
    /// Gets the time duration of this <see cref="TimeUnit"/> for a specific <see cref="Bpm"/>
    /// </summary>
    /// <param name="bpm">The tempo to get duration for</param>
    public TimeSpan GetDuration(Bpm bpm)
    {
        var usPerQuarter = 60_000_000 / bpm.Value;
        var usPerTick = usPerQuarter / TicksPerQuarterNote;
        var ms = usPerTick * _ticks / 1000;
        var duration = TimeSpan.FromMilliseconds(ms);
        return duration;
    }

    public static TimeUnit operator +(TimeUnit a, TimeUnit b)
    {
        return new TimeUnit(a.Ticks + b.Ticks);
    }

    public static TimeUnit operator -(TimeUnit a, TimeUnit b)
    {
        return new TimeUnit(a.Ticks - b.Ticks);
    }

    public static TimeUnit operator *(TimeUnit a, int multiplier)
    {
        return new TimeUnit(a.Ticks * multiplier);
    }

    public override string ToString()
    {
        return $"{Ticks:n0} ticks";
    }
}