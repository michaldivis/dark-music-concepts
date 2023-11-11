namespace DarkMusicConcepts;

/// <summary>
/// Representation of musical time, the value is stored in MIDI ticks
/// </summary>
public class Time : Unit<long, Time>, IUnit<long, Time>
{
    public static long MinValue { get; } = 0;
    public static long MaxValue { get; } = long.MaxValue;

    private Time(long value) : base(value)
    {
    }

    static Time IUnit<long, Time>.Create(long value) => new(value);

    private const long _ticksPerQuarterNote = 960;
    private const long _ticksPerSixteenthNote = _ticksPerQuarterNote / 4;
    private const long _ticksPerSixteenthNoteTriplet = _ticksPerQuarterNote / 6;
    private const long _ticksPerSixteenthNoteDotted = 360;

    #region Helper members

    public long Ticks => Value;

    public long Bars => Ticks / _ticksPerSixteenthNote / 16 / 4;

    public long WholeNotes => Ticks / _ticksPerSixteenthNote / 16;
    public long HalfNotes => Ticks / _ticksPerSixteenthNote / 8;
    public long QuarterNotes => Ticks / _ticksPerSixteenthNote / 4;
    public long EightNotes => Ticks / _ticksPerSixteenthNote / 2;
    public long SixteenthNotes => Ticks / _ticksPerSixteenthNote;
    public long ThirtySecondNotes => Ticks / _ticksPerSixteenthNote * 2;
    public long SixtyForthNotes => Ticks / _ticksPerSixteenthNote * 4;

    public long WholeNoteTriplets => Ticks / _ticksPerSixteenthNoteTriplet / 16;
    public long HalfNoteTriplets => Ticks / _ticksPerSixteenthNoteTriplet / 8;
    public long QuarterNoteTriplets => Ticks / _ticksPerSixteenthNoteTriplet / 4;
    public long EightNoteTriplets => Ticks / _ticksPerSixteenthNoteTriplet / 2;
    public long SixteenthNoteTriplets => Ticks / _ticksPerSixteenthNoteTriplet;
    public long ThirtySecondNoteTriplets => Ticks / _ticksPerSixteenthNoteTriplet * 2;
    public long SixtyForthNoteTriplets => Ticks / _ticksPerSixteenthNoteTriplet * 4;

    public long WholeDottedNotes => Ticks / _ticksPerSixteenthNoteDotted / 16;
    public long HalfDottedNotes => Ticks / _ticksPerSixteenthNoteDotted / 8;
    public long QuarterDottedNotes => Ticks / _ticksPerSixteenthNoteDotted / 4;
    public long EightDottedNotes => Ticks / _ticksPerSixteenthNoteDotted / 2;
    public long SixteenthDottedNotes => Ticks / _ticksPerSixteenthNoteDotted;
    public long ThirtySecondDottedNotes => Ticks / _ticksPerSixteenthNoteDotted * 2;
    public long SixtyForthDottedNotes => Ticks / _ticksPerSixteenthNoteDotted * 4;

    public static Time FromBars(long amount) => From(amount * _ticksPerSixteenthNote * 64);

    public static Time FromWholeNotes(long amount) => From(amount * _ticksPerSixteenthNote * 16);
    public static Time FromHalfNotes(long amount) => From(amount * _ticksPerSixteenthNote * 8);
    public static Time FromQuarterNotes(long amount) => From(amount * _ticksPerSixteenthNote * 4);
    public static Time FromEightNotes(long amount) => From(amount * _ticksPerSixteenthNote * 2);
    public static Time FromSixteenthNotes(long amount) => From(amount * _ticksPerSixteenthNote);
    public static Time FromThirtySecondNotes(long amount) => From(amount * _ticksPerSixteenthNote / 2);
    public static Time FromSixtyForthNotes(long amount) => From(amount * _ticksPerSixteenthNote / 4);

    public static Time FromWholeNoteTriplets(long amount) => From(amount * _ticksPerSixteenthNoteTriplet * 16);
    public static Time FromHalfNoteTriplets(long amount) => From(amount * _ticksPerSixteenthNoteTriplet * 8);
    public static Time FromQuarterNoteTriplets(long amount) => From(amount * _ticksPerSixteenthNoteTriplet * 4);
    public static Time FromEightNoteTriplets(long amount) => From(amount * _ticksPerSixteenthNoteTriplet * 2);
    public static Time FromSixteenthNoteTriplets(long amount) => From(amount * _ticksPerSixteenthNoteTriplet);
    public static Time FromThirtySecondNoteTriplets(long amount) => From(amount * _ticksPerSixteenthNoteTriplet / 2);
    public static Time FromSixtyForthNoteTriplets(long amount) => From(amount * _ticksPerSixteenthNoteTriplet / 4);

    public static Time FromWholeNoteDotteds(long amount) => From(amount * _ticksPerSixteenthNoteDotted * 16);
    public static Time FromHalfNoteDotteds(long amount) => From(amount * _ticksPerSixteenthNoteDotted * 8);
    public static Time FromQuarterNoteDotteds(long amount) => From(amount * _ticksPerSixteenthNoteDotted * 4);
    public static Time FromEightNoteDotteds(long amount) => From(amount * _ticksPerSixteenthNoteDotted * 2);
    public static Time FromSixteenthNoteDotteds(long amount) => From(amount * _ticksPerSixteenthNoteDotted);
    public static Time FromThirtySecondNoteDotteds(long amount) => From(amount * _ticksPerSixteenthNoteDotted / 2);
    public static Time FromSixtyForthNoteDotteds(long amount) => From(amount * _ticksPerSixteenthNoteDotted / 4);

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
        var usPerQuarter = 60_000 / bpm.Value;
        var usPerTick = (double)usPerQuarter / _ticksPerQuarterNote;
        var ms = (double)usPerTick * Ticks;
        var duration = TimeSpan.FromMilliseconds(ms);
        return duration;
    }

    public override string ToString() => $"{Ticks:n0} ticks";
}