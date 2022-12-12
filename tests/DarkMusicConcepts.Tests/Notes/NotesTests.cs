namespace DarkMusicConcepts;

public class NotesTests
{
    [Fact]
    public void All_ShouldActuallyContainAllTheNotes()
    {
        var found = ReflectionUtils.GetPublicStaticProperties<Note>(typeof(Notes));
        Notes.All.Count.Should().Be(found.Count());
        Notes.All.Should().Contain(found);
    }

    [Fact]
    public void All_ShouldBeUnique()
    {
        var duplicates = Notes.All
            .GroupBy(x => new { x.BasePitch, x.Octave })
            .Where(x => x.Count() > 1)
            .ToList();

        duplicates.Should().BeEmpty();
    }
}