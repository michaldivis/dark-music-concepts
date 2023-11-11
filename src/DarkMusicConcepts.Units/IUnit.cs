namespace DarkMusicConcepts;

public interface IUnit<TValue, TThis>
    where TValue : IComparable, IComparable<TValue>, IEquatable<TValue>
{
    public static abstract TValue MinValue { get; }
    public static abstract TValue MaxValue { get; }

    internal static abstract TThis Create(TValue value);
    public static abstract bool IsValidValue(TValue? value);
}
