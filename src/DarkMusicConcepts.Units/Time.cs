namespace DarkMusicConcepts;
/// <summary>
/// Representation of musical time, the (<see cref="Value"/>) is stored in MIDI ticks
/// </summary>
public class Time : Unit<int, Time>
{
    public const int MinValue = 0;
    public const int MaxValue = int.MaxValue;

    public static Time Min { get; } = From(MinValue);
    public static Time Max { get; } = From(MaxValue);

    protected override int GetMinValue() => MinValue;
    protected override int GetMaxValue() => MaxValue;

    private const int TicksPerQuarterNote = 960;
    private const int TicksPerSixteenthNote = TicksPerQuarterNote / 4;
    private const int TicksPerSixteenthNoteTriplet = TicksPerQuarterNote / 6;
    private const int TicksPerSixteenthNoteDotted = 360;

    #region Helper members

    public int Ticks => Value;

    public int Bars => Ticks / TicksPerSixteenthNote / 16 / 4;

    public int WholeNotes => Ticks / TicksPerSixteenthNote / 16;
    public int HalfNotes => Ticks / TicksPerSixteenthNote / 8;
    public int QuarterNotes => Ticks / TicksPerSixteenthNote / 4;
    public int EightNotes => Ticks / TicksPerSixteenthNote / 2;
    public int SixteenthNotes => Ticks / TicksPerSixteenthNote;
    public int ThirtySecondNotes => Ticks / TicksPerSixteenthNote * 2;
    public int SixtyForthNotes => Ticks / TicksPerSixteenthNote * 4;

    public int WholeNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet / 16;
    public int HalfNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet / 8;
    public int QuarterNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet / 4;
    public int EightNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet / 2;
    public int SixteenthNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet;
    public int ThirtySecondNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet * 2;
    public int SixtyForthNoteTriplets => Ticks / TicksPerSixteenthNoteTriplet * 4;

    public int WholeDottedNotes => Ticks / TicksPerSixteenthNoteDotted / 16;
    public int HalfDottedNotes => Ticks / TicksPerSixteenthNoteDotted / 8;
    public int QuarterDottedNotes => Ticks / TicksPerSixteenthNoteDotted / 4;
    public int EightDottedNotes => Ticks / TicksPerSixteenthNoteDotted / 2;
    public int SixteenthDottedNotes => Ticks / TicksPerSixteenthNoteDotted;
    public int ThirtySecondDottedNotes => Ticks / TicksPerSixteenthNoteDotted * 2;
    public int SixtyForthDottedNotes => Ticks / TicksPerSixteenthNoteDotted * 4;

    public static Time FromBars(int amount) => From(amount * TicksPerSixteenthNote * 64);

    public static Time FromWholeNotes(int amount) => From(amount * TicksPerSixteenthNote * 16);
    public static Time FromHalfNotes(int amount) => From(amount * TicksPerSixteenthNote * 8);
    public static Time FromQuarterNotes(int amount) => From(amount * TicksPerSixteenthNote * 4);
    public static Time FromEightNotes(int amount) => From(amount * TicksPerSixteenthNote * 2);
    public static Time FromSixteenthNotes(int amount) => From(amount * TicksPerSixteenthNote);
    public static Time FromThirtySecondNotes(int amount) => From(amount * TicksPerSixteenthNote / 2);
    public static Time FromSixtyForthNotes(int amount) => From(amount * TicksPerSixteenthNote / 4);

    public static Time FromWholeNoteTriplets(int amount) => From(amount * TicksPerSixteenthNoteTriplet * 16);
    public static Time FromHalfNoteTriplets(int amount) => From(amount * TicksPerSixteenthNoteTriplet * 8);
    public static Time FromQuarterNoteTriplets(int amount) => From(amount * TicksPerSixteenthNoteTriplet * 4);
    public static Time FromEightNoteTriplets(int amount) => From(amount * TicksPerSixteenthNoteTriplet * 2);
    public static Time FromSixteenthNoteTriplets(int amount) => From(amount * TicksPerSixteenthNoteTriplet);
    public static Time FromThirtySecondNoteTriplets(int amount) => From(amount * TicksPerSixteenthNoteTriplet / 2);
    public static Time FromSixtyForthNoteTriplets(int amount) => From(amount * TicksPerSixteenthNoteTriplet / 4);

    public static Time FromWholeNoteDotteds(int amount) => From(amount * TicksPerSixteenthNoteDotted * 16);
    public static Time FromHalfNoteDotteds(int amount) => From(amount * TicksPerSixteenthNoteDotted * 8);
    public static Time FromQuarterNoteDotteds(int amount) => From(amount * TicksPerSixteenthNoteDotted * 4);
    public static Time FromEightNoteDotteds(int amount) => From(amount * TicksPerSixteenthNoteDotted * 2);
    public static Time FromSixteenthNoteDotteds(int amount) => From(amount * TicksPerSixteenthNoteDotted);
    public static Time FromThirtySecondNoteDotteds(int amount) => From(amount * TicksPerSixteenthNoteDotted / 2);
    public static Time FromSixtyForthNoteDotteds(int amount) => From(amount * TicksPerSixteenthNoteDotted / 4);

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

    public static Time operator *(Time a, int multiplier)
    {
        return From(a.Ticks * multiplier);
    }

    public static Time operator *(int multiplier, Time a)
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