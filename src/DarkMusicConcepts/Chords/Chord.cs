using DarkMusicConcepts.Scales;
using System.Linq;
using Throw;

namespace DarkMusicConcepts.Chords;
/// <summary>
/// A chord is any harmonic set of pitches/frequencies consisting of multiple notes (also called "pitches") that are heard as if sounding simultaneously.
/// </summary>
public class Chord
{
    private readonly List<ChordNote> _chordNotes = new();
    private readonly Note _rootBeforeInversion;

    /// <summary>
    /// The formula used to created the chord
    /// </summary>
    public ChordFormula Formula { get; }

    /// <summary>
    /// The inversion. This will be 0 if the chord hasn't been inverted, or greater than 0 if it has.
    /// </summary>
    public int Inversion { get; }

    /// <summary>
    /// The name of the chord containing the note name and number + the type/quality
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The root note of the chord
    /// </summary>
    public Note Bass { get; }

    /// <summary>
    /// The leading (highest) note of the chord
    /// </summary>
    public Note Lead { get; }

    /// <summary>
    /// All the notes contained in the chord
    /// </summary>
    public IReadOnlyList<Note> Notes { get; }

    private Chord(IReadOnlyList<Note> notes, Note rootBeforeInversion, ChordFormula chordFormula, int inversion)
    {
        _rootBeforeInversion = rootBeforeInversion;

        Notes = notes;
        Inversion = inversion;
        Formula = chordFormula;

        var root = notes[0];

        _chordNotes.Add(new ChordNote(root, ChordFunctions.Root));

        foreach (var note in notes)
        {
            var interval = root.IntervalWithOther(note);
            var chordNote = new ChordNote(note, ChordFunction.FunctionForInterval(interval));
            _chordNotes.Add(chordNote);
        }

        Name = GetName(_rootBeforeInversion, chordFormula, inversion);

        Bass = notes[0];
        Lead = notes[notes.Count - 1];
    }

    /// <summary>
    /// Creates a chord based on an existing formula
    /// </summary>
    /// <param name="root">Root note of the chord</param>
    /// <param name="formula">The existing formula</param>
    /// <returns>A chord created from the root note and formula</returns>
    public static Chord Create(Note root, ChordFormula formula)
    {
        var notes = new List<Note>
        {
            root
        };

        foreach (var interval in formula.Intervals)
        {
            notes.Add(root.TransposeUp(interval));
        }

        return new Chord(notes, root, formula, 0);
    }

    /// <summary>
    /// Creates a chord definition that can be manipulated to build a custom chord using the <see cref="ChordDefinition.With(ChordFunction, Accident)"/> and <see cref="ChordDefinition.Build"/> methods
    /// </summary>
    /// <param name="root">Root note of the chord</param>
    /// <returns>A chord definition that can be manipulated to build a custom chord</returns>
    public static ChordDefinition CreateCustom(Note root)
    {
        return new ChordDefinition(root);
    }

    /// <summary>
    /// Perform a chord inversion 
    /// </summary>
    /// <returns>Returns the next inversion of the chord, or if the maximum number of inversions has been reached, returns the base chord but an octave up</returns>
    public Chord Invert()
    {
        var invertedNotes = new List<Note>();
        invertedNotes.AddRange(Notes.Skip(1));
        invertedNotes.Add(Notes[0].TransposeUp(Intervals.PerfectOctave));
        invertedNotes.Sort();

        if(Inversion >= invertedNotes.Count - 1)
        {
            return new Chord(invertedNotes, _rootBeforeInversion.TransposeUp(Intervals.PerfectOctave), Formula, 0);
        }

        return new Chord(invertedNotes, _rootBeforeInversion, Formula, Inversion + 1);   
    }

    /// <summary>
    /// Creates a chord based on an a scale and scale degree
    /// </summary>
    /// <param name="scale">Scale</param>
    /// <param name="octave">Octave to start the root note in</param>
    /// <param name="scaleDegree">The scale degree</param>
    /// <returns>A chord created from the scale and scale degree</returns>
    /// <exception cref="ArgumentOutOfRangeException" />
    public static Chord Create(Scale scale, Octave octave, ScaleDegree scaleDegree)
    {
        ((int)scaleDegree)
            .Throw("The scale degree is greater than the number of pitches in the scale")
            .IfGreaterThanOrEqualTo(scale._pitches.Count);

        var rootPitch = scale._pitches[(int)scaleDegree];

        return Create(scale, rootPitch, octave, ScaleStep.II, ScaleStep.II);
    }

    /// <summary>
    /// Creates a chord based on an a scale, root pitch and steps.
    /// <para>The following code should create a chord that starts with the I, then goes two scale degrees up (to III), and the goes another two degrees up (to V). Resulting in a I, III, V chord</para>
    /// <code>
    /// var scale = ScaleFormulas.Ionian.CreateForRoot(Pitch.E);
    /// var chord = Chord.Create(scale, scale.I, Octave.OneLine, ScaleStep.II, ScaleStep.II);</code>
    /// </summary>
    /// <param name="scale">Scale</param>
    /// <param name="octave">Octave to start the root note in</param>
    /// <param name="scaleSteps">The steps to find the notes (each step is relative to the previous one)</param>
    /// <returns>A chord created from the scale, root pitch and steps</returns>
    /// <exception cref="ArgumentOutOfRangeException" />
    public static Chord Create(Scale scale, Pitch rootPitch, Octave octave, params ScaleStep[] scaleSteps)
    {
        scale.Pitches
            .Throw("The root pitch is not in the scale")
            .IfNotContains(rootPitch);

        var root = Note.Create(rootPitch, octave);

        var notes = new List<Note>
        {
            root
        };

        var currentPitch = rootPitch;

        foreach (var scaleStep in scaleSteps)
        {
            var otherPitch = scale._pitches.GetNext(currentPitch, (int)scaleStep);

            if (otherPitch < currentPitch)
            {
                octave += 1;
            }

            notes.Add(Note.Create(otherPitch, octave));

            currentPitch = otherPitch;
        }

        var intervals = notes
            .Skip(1)
            .Select(x => root.IntervalWithOther(x))
            .ToArray();

        var existingFormula = ChordFormulas.All.FirstOrDefault(x => x.Intervals.SequenceEqual(intervals));

        var formula = existingFormula ?? new ChordFormula("Custom", intervals);

        var chord = new Chord(notes, root, formula, 0);

        return chord;
    }

    private static string GetName(Note root, ChordFormula formula, int inversion)
    {
        if(inversion == 0)
        {
            return root.Name + formula.AbreviatedName;
        }

        return $"{root.Name}{formula.AbreviatedName} ({Humanizer.AddOrdinal(inversion)} inversion)";
    }

    public override string ToString()
    {
        var noteNames = string.Join(", ", Notes);
        return $"{Name} ({noteNames})";
    }
}