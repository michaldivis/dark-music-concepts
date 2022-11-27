using DarkMusicConcepts.Chords;
using DarkMusicConcepts.Notes;
using DarkMusicConcepts.Scales;

namespace SampleConsoleApp;
public class ChordPatternGenerator
{
    private readonly Random _random;

    public ChordPatternGenerator(Random random)
    {
        _random = random;
    }

    public Chord[] CreateRandomChords(int amount, Scale scale, Octave octave)
    {
        var chords = new Chord[amount];

        for (int i = 0; i < amount; i++)
        {
            var chordRoot = (Pitch)_random.Next(12);
            var availableChordFunctions = ChordFormula.GetFormulasForScale(scale, chordRoot);
            var chordFunction = availableChordFunctions.ElementAt(_random.Next(availableChordFunctions.Count()));
            var root = new Note(chordRoot, octave);
            var chord = Chord.Create(root, chordFunction);
            chords[i] = chord;
        }

        return chords;
    }
}
