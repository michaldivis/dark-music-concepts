namespace DarkMusicConcepts;
/// <summary>
/// Representation of musical time, the (<see cref="Value"/>) is stored in MIDI ticks
/// </summary>
public class Time : Unit<long, Time>
{
    public const long MinValue = 0;
    public const long MaxValue = long.MaxValue;

    public static Time Min { get; } = From(MinValue);
    public static Time Max { get; } = From(MaxValue);

    private Time(long value) : base(value)
    {
    }

    protected override long GetMinValue() => MinValue;
    protected override long GetMaxValue() => MaxValue;

    public static Time From(long ticks)
    {
        var time = new Time(ticks);

        time.Validate();

        return time;
    }

    public static bool TryFrom(long ticks, out Time time)
    {
        var x = new Time(ticks);

        time = x.TryValidate()
            ? x
            : null!;

        return time is not null;
    }

    private const long TicksPerQuarterNote = 960;
    private const long TicksPerSixteenthNote = TicksPerQuarterNote / 4;
    private const long TicksPerSixteenthNoteTriplet = TicksPerQuarterNote / 6;
    private const long TicksPerSixteenthNoteDotted = 360;

    #region Helper members

    public long Ticks => Value;

    public long Bars => Ticks / TicksPerSixteenthNote / 16 / 4;

    public long WholeNotes => Ticks / TicksPerSixteenthNote / 16;
    public long HalfNotes => Ticks / TicksPerSixteenthNote / 8;
    public long QuarterNotes => Ticks / TicksPerSixteenthNote / 4;
    public long EightNotes => Ticks / TicksPerSixteenthNote / 2;
    public long SixteenthNotes => Ticks / TicksPerSixteenthNote;
    public long ThirtySecondNotes => Ticks / TicksPerSixteenthNote * 2;
    public long SixtyForthNotes => Ticks / TicksPerSixteenthNote * 4;

    public long WholeNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet / 16;
    public long HalfNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet / 8;
    public long QuarterNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet / 4;
    public long EightNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet / 2;
    public long SixteenthNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet;
    public long ThirtySecondNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet * 2;
    public long SixtyForthNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet * 4;

    public long WholeDottedNotes => Ticks / TicksPerSixteenthNoteDotted / 16;
    public long HalfDottedNotes => Ticks / TicksPerSixteenthNoteDotted / 8;
    public long QuarterDottedNotes => Ticks / TicksPerSixteenthNoteDotted / 4;
    public long EightDottedNotes => Ticks / TicksPerSixteenthNoteDotted / 2;
    public long SixteenthDottedNotes => Ticks / TicksPerSixteenthNoteDotted;
    public long ThirtySecondDottedNotes => Ticks / TicksPerSixteenthNoteDotted * 2;
    public long SixtyForthDottedNotes => Ticks / TicksPerSixteenthNoteDotted * 4;

    public static Time FromBars(long amount) => From(amount * TicksPerSixteenthNote * 64);

    public static Time FromWholeNotes(long amount) => From(amount * TicksPerSixteenthNote * 16);
    public static Time FromHalfNotes(long amount) => From(amount * TicksPerSixteenthNote * 8);
    public static Time FromQuarterNotes(long amount) => From(amount * TicksPerSixteenthNote * 4);
    public static Time FromEightNotes(long amount) => From(amount * TicksPerSixteenthNote * 2);
    public static Time FromSixteenthNotes(long amount) => From(amount * TicksPerSixteenthNote);
    public static Time FromThirtySecondNotes(long amount) => From(amount * TicksPerSixteenthNote / 2);
    public static Time FromSixtyForthNotes(long amount) => From(amount * TicksPerSixteenthNote / 4);

    public static Time FromWholeNoteTriplets(long amount) => From(amount * TicksPerSixteenthNoteTriplet * 16);
    public static Time FromHalfNoteTriplets(long amount) => From(amount * TicksPerSixteenthNoteTriplet * 8);
    public static Time FromQuarterNoteTriplets(long amount) => From(amount * TicksPerSixteenthNoteTriplet * 4);
    public static Time FromEightNoteTriplets(long amount) => From(amount * TicksPerSixteenthNoteTriplet * 2);
    public static Time FromSixteenthNoteTriplets(long amount) => From(amount * TicksPerSixteenthNoteTriplet);
    public static Time FromThirtySecondNoteTriplets(long amount) => From(amount * TicksPerSixteenthNoteTriplet / 2);
    public static Time FromSixtyForthNoteTriplets(long amount) => From(amount * TicksPerSixteenthNoteTriplet / 4);

    public static Time FromWholeNoteDotteds(long amount) => From(amount * TicksPerSixteenthNoteDotted * 16);
    public static Time FromHalfNoteDotteds(long amount) => From(amount * TicksPerSixteenthNoteDotted * 8);
    public static Time FromQuarterNoteDotteds(long amount) => From(amount * TicksPerSixteenthNoteDotted * 4);
    public static Time FromEightNoteDotteds(long amount) => From(amount * TicksPerSixteenthNoteDotted * 2);
    public static Time FromSixteenthNoteDotteds(long amount) => From(amount * TicksPerSixteenthNoteDotted);
    public static Time FromThirtySecondNoteDotteds(long amount) => From(amount * TicksPerSixteenthNoteDotted / 2);
    public static Time FromSixtyForthNoteDotteds(long amount) => From(amount * TicksPerSixteenthNoteDotted / 4);

    public static readonly Time Zero = From(0);

    public static readonly Time Bar = FromBars(1);

    public static readonly Time WholeNote = FromWholeNotes(1);
    public static readonly Time HalfNote = FromHalfNotes(1);
    public static readonly Time QuarterNote = FromQuarterNotes(1);
    public static readonly Time EightNote = FromEightNotes(1);
    public static readonly Time SixteenthNote = FromSixteenthNotes(1);
    public static readonly Time ThirtySecondNote = FromThirtySecondNotes(1);
    public static readonly Time SixtyForthNote = FromSixtyForthNotes(1);

    public static readonly Time WholeNoteTriplet = FromWholeNoteTriplets(1);
    public static readonly Time HalfNoteTriplet = FromHalfNoteTriplets(1);
    public static readonly Time QuarterNoteTriplet = FromQuarterNoteTriplets(1);
    public static readonly Time EightNoteTriplet = FromEightNoteTriplets(1);
    public static readonly Time SixteenthNoteTriplet = FromSixteenthNoteTriplets(1);
    public static readonly Time ThirtySecondNoteTriplet = FromThirtySecondNoteTriplets(1);
    public static readonly Time SixtyForthNoteTriplet = FromSixtyForthNoteTriplets(1);

    public static readonly Time WholeNoteDotted = FromWholeNoteDotteds(1);
    public static readonly Time HalfNoteDotted = FromHalfNoteDotteds(1);
    public static readonly Time QuarterNoteDotted = FromQuarterNoteDotteds(1);
    public static readonly Time EightNoteDotted = FromEightNoteDotteds(1);
    public static readonly Time SixteenthNoteDotted = FromSixteenthNoteDotteds(1);
    public static readonly Time ThirtySecondNoteDotted = FromThirtySecondNoteDotteds(1);
    public static readonly Time SixtyForthNoteDotted = FromSixtyForthNoteDotteds(1);

    #endregion

    #region Aritmetic operator overloads

    public static Time operator +(Time a, Time b)
    {
        return From(a.Ticks + b.Ticks);
    }

    public static Time operator -(Time a, Time b)
    {
        return From(a.Ticks - b.Ticks);
    }

    public static Time operator *(Time a, long multiplier)
    {
        return From(a.Ticks * multiplier);
    }

    public static Time operator *(long multiplier, Time a)
    {
        return From(a.Ticks * multiplier);
    }

    #endregion

    /// <summary>
    /// Gets the time duration of this <see cref="Time"/> for a specific <see cref="Bpm"/>
    /// </summary>
    /// <param name="bpm">The tempo to get duration for</param>
    public TimeSpan GetDuration(Bpm bpm)
    {
        var usPerQuarter = (double)60_000 / bpm.Value;
        var usPerTick = (double)usPerQuarter / TicksPerQuarterNote;
        var ms = (double)usPerTick * Ticks;
        var duration = TimeSpan.FromMilliseconds(ms);
        return duration;
    }

    public override string ToString()
    {
        return $"{Ticks:n0} ticks";
    }
}