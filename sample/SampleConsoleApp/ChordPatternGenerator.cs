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
        var availableChordFunctions = ChordFormula.GetFunctionsForScale(scale).ToList();

        for (int i = 0; i < amount; i++)
        {
            var chordFunction = availableChordFunctions[_random.Next(0, availableChordFunctions.Count)];
            var rootPitch = (Pitch)_random.Next(0, 12);
            var root = new Note(rootPitch, octave);
            var chord = new Chord(root, chordFunction);
            chords[i] = chord;
        }

        return chords;
    }
}
