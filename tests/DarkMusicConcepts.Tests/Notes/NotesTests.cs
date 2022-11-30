using DarkMusicConcepts.Tests;
using FluentAssertions;

namespace DarkMusicConcepts.Notes.Tests;

public class NotesTests
{
    [Fact]
    public void All_ShouldActuallyContainAllTheNotes()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<Note>(typeof(Notes));
        Notes.All.Count.Should().Be(found.Count());
        Notes.All.Should().Contain(found);
    }
}