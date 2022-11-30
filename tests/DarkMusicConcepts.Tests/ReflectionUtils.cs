using System.Reflection;

namespace DarkMusicConcepts.Tests;
internal static class ReflectionUtils
{
    public static IEnumerable<TProperty> GetPublicStaticProperties<TProperty>(Type containingType)
    {
        var foundItems = containingType
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(x => x.PropertyType == typeof(TProperty))
            .Select(x => x.GetValue(null))
            .Cast<TProperty>();

        return foundItems;
    }
}
