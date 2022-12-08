using DarkMusicConcepts.Utils;
using FluentAssertions;

namespace DarkMusicConcepts.Tests.Utils;
public class ListExtensionsTests
{
    private const string _item1 = "Harry";
    private const string _item2 = "Hermione";
    private const string _item3 = "Ron";
    private const string _item4 = "Albus";
    private const string _item5 = "Hagrid";

    private readonly List<string> _items = new() { _item1, _item2, _item3, _item4, _item5 };

    [Theory]
    [InlineData(_item1, 1, _item2)]
    [InlineData(_item1, 2, _item3)]
    [InlineData(_item1, 3, _item4)]
    [InlineData(_item1, 4, _item5)]
    [InlineData(_item1, 5, _item1)]
    [InlineData(_item1, 6, _item2)]
    public void GetNext_ShouldWork(string item, int steps, string expected)
    {
        var next = _items.GetNext(item, steps);
        _ = next.Should().Be(expected);
    }
}
