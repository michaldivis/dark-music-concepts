using DarkMusicConcepts.Notes;

namespace DarkMusicConcepts.Scales;

public class Scale
{
    public Scale(IEnumerable<NotePitch> notes)
    {
        Notes = notes;
    }

    public IEnumerable<NotePitch> Notes { get; }

    public NotePitch I => Notes.ElementAt(0);

    public NotePitch II => Notes.ElementAt(1);

    public NotePitch III => Notes.ElementAt(2);

    public NotePitch IV => Notes.ElementAt(3);

    public NotePitch V => Notes.ElementAt(4);

    public NotePitch VI => Notes.ElementAt(5);

    public NotePitch VII => Notes.ElementAt(6);
}