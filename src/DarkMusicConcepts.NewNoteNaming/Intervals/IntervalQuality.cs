namespace DarkMusicConcepts.NewNoteNaming.Intervals;

public enum IntervalQuality
{
    //todo: transform into class with internal enum representation to evade enum boxing-unboxing problems in runtime
    Perfect,
    Major,
    Minor,
    Augmented,
    Diminished
}
