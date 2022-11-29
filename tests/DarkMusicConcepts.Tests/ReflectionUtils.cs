using System.Reflection;

namespace DarkMusicConcepts.Tests;
internal static class ReflectionUtils
{
    public static IEnumerable<TProperty> GetPublicStaticProperties<TParent, TProperty>()
    {
        var foundItems = typeof(TParent)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(x => x.PropertyType == typeof(TProperty))
            .Select(x => x.GetValue(null))
            .Cast<TProperty>();

        return foundItems;
    }
}
