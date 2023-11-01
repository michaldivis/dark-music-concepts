namespace DarkMusicConcepts;

internal static class CollectionExtensions
{
    /// <summary>
    /// Finds the Nth next item in a list, if the current item is the last item in the list, the first item is returned
    /// </summary>
    /// <typeparam name="T">Type of item</typeparam>
    /// <param name="list">The list to search in</param>
    /// <param name="item">The start item</param>
    /// <param name="step">The number of steps to move. 1 = get the next item, 3 = get the third next item, etc...</param>
    /// <returns>The next item</returns>
    /// <exception cref="ArgumentException"></exception>
    public static T GetNext<T>(this IList<T> list, T item, int step = 1)
    {
        var index = list.IndexOf(item);

        index
            .Throw("Item not found in list")
            .IfNegative();

        var wantedIndex = index + step;
        var safeIndex = wantedIndex % list.Count;
        return list[safeIndex];
    }

    /// <summary>
    /// Checks if two collections contain the same elements, in any order
    /// </summary>
    /// <typeparam name="T">Type of item</typeparam>
    /// <param name="list">The collection to compare</param>
    /// <param name="other">The other collection to compare</param>
    /// <returns><see langword="true"/> if the two collections contain the same elements, in any order</returns>
    public static bool ContainsSameElements<T>(this IEnumerable<T> list, IEnumerable<T> other)
    {
        if (list.Count() != other.Count())
        {
            return false;
        }

        return list.All(x => other.Contains(x));
    }

    /// <summary>
    /// Returns the index of the first occurrence of a given value in a range of this list. The list is searched forwards from beginning to end. The elements of the list are compared to the given value using the Object.Equals method.
    /// </summary>
    public static int IndexOf<T>(this IReadOnlyList<T> list, T item)
    {
        for (var i = 0; i < list.Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(list[i], item))
            {
                return i;
            }
        }

        return -1;
    }
}