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

        PrintSubHeader("Create chords from scale");

        var cMajorScale = ScaleFormulas.Ionian.Create(Pitch.C);
        var octave = Octave.OneLine;
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.Tonic));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.Supertonic));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.Mediant));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.Subdominant));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.Dominant));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.Submediant));
        Print(Chord.Create(cMajorScale, octave, ScaleDegree.LeadingTone));

        PrintSubHeader("Chord pattern generation");

        var random = new Random(123456);
        var chordPatternGenerator = new ChordPatternGenerator(random);
        var randomChords = chordPatternGenerator.CreateRandomChords(6, ScaleFormulas.HarmonicMinor.Create(Pitch.C), Octave.Great);
        PrintCollection(randomChords, true);
    }
}