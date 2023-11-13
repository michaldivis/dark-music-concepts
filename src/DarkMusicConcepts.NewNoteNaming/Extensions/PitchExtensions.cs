namespace DarkMusicConcepts.NewNoteNaming.Extensions;

public static class PitchExtensions
{
    public static int CalculateMidiNote(this Pitch.Pitch pitch)
    {
        //todo: should check if it is valid for mapping for midi range, but it's ok for finding intervals between notes
        var semitones = pitch.Octave * 12 + pitch.Step.GetStepValue() + pitch.Alter;
        return semitones;
    }
}
