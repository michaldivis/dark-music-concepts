using DarkMusicConcepts.Chords;
using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Scales;

namespace SampleConsoleApp.Demos;
internal class ChordsDemo : Demo
{
    public override void Run()
    {
        PrintHeader("Chords");

        var chord = Chord.Create(Notes.C2, ChordFormulas.DominantSeventh);
        Print(chord);
        Print(chord.Bass);
        Print(chord.Lead);
        Print(chord.Formula);
        PrintCollection(chord.Notes, false);

        var chord1stInversion = chord.Invert();
        Print(chord1stInversion);

        var chord2ndInversion = chord1stInversion.Invert();
        Print(chord2ndInversion);

        var chord3rdInversion = chord2ndInversion.Invert();
        Print(chord3rdInversion);

        var chord4thInversion = chord3rdInversion.Invert();
        Print(chord4thInversion);

        PrintSubHeader("Chord builder");

        var customChord = Chord
            .CreateCustom(Notes.G3)
            .With(ChordFunctions.Third)
            .With(ChordFunctions.Fifth, Accident.Sharp)
            .With(ChordFunctions.Eleventh, Accident.Flat)
            .Build();

        Print(customChord);

        PrintSubHeader("Chords from scale degrees");

        var cMajorScale = ScaleFormulas.Ionian.Create(Pitch.C);
        var octave = Octave.OneLine;
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.I));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.II));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.III));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.IV));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.V));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.VI));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.VII));

        PrintSubHeader("Chords from scale degrees");

        Comment("The following will create a triad based on the major scale. Starting with the root pitch, then skipping one pitch and taking the next");
        Print(Chord.Create(cMajorScale, cMajorScale.Root, octave, ScaleStep.II, ScaleStep.II));

        PrintSubHeader("Chords progressions");

        Print(ChordProgressions.Pop.I_IV_V_IV);

        var customChordProgression = ChordProgression.Create(ScaleDegree.I, ScaleDegree.IV, ScaleDegree.V, ScaleDegree.II, ScaleDegree.VI);
        var customChordProgressionChords = customChordProgression.GetChords(cMajorScale, octave);
        Print(customChordProgression);
        PrintCollection(customChordProgressionChords, true);

        PrintSubHeader("Chord pattern generation");

        var random = new Random(123456);
        var chordPatternGenerator = new ChordPatternGenerator(random);
        var randomChords = chordPatternGenerator.CreateRandomChords(6, ScaleFormulas.HarmonicMinor.Create(Pitch.C), Octave.Great);
        PrintCollection(randomChords, true);
    }
}