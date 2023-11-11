namespace DarkMusicConcepts;

internal static class ListExtensions
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

        if (index < 0)
        {
            throw new ArgumentException("Item not found in list");
        }

        var wantedIndex = index + step;
        var safeIndex = wantedIndex % list.Count;
        return list[safeIndex];
    }
}