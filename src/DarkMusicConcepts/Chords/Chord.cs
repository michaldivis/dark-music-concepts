namespace DarkMusicConcepts;

/// <summary>
/// A chord is any harmonic set of pitches/frequencies consisting of multiple notes (also called "pitches") that are heard as if sounding simultaneously.
/// </summary>
public class Chord
{
    private readonly List<ChordNote> _chordNotes = new();

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
    /// The root pitch of the chord
    /// </summary>
    public Pitch RootPitch { get; }

    /// <summary>
    /// The bass (lowest) note of the chord
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

    private Chord(IEnumerable<Note> notes, ChordFormula? chordFormula, int? inversion, Pitch? rootPitch)
    {
        notes.ThrowIfNull();

        notes
            .Throw()
            .IfCountLessThan(2);

        var orderedNotes = notes
            .OrderBy(x => x.AbsolutePitch)
            .ToList()
            .AsReadOnly();

        Notes = orderedNotes;

        if (chordFormula is null || inversion is null || rootPitch is null)
        {
            (chordFormula, inversion, rootPitch) = GetFormulaAndInversionAndRootPitch(orderedNotes);
        }

        Formula = chordFormula;
        Inversion = inversion.Value;
        RootPitch = rootPitch.Value;

        var bass = orderedNotes[0];

        _chordNotes.Add(new ChordNote(bass, ChordFunctions.Root));

        foreach (var note in notes)
        {
            var interval = bass.IntervalWithOther(note);
            var chordNote = new ChordNote(note, ChordFunction.FunctionForInterval(interval));
            _chordNotes.Add(chordNote);
        }

        Name = GetName(rootPitch.Value, chordFormula, inversion.Value);

        Bass = bass;
        Lead = orderedNotes[orderedNotes.Count - 1];
    }

    /// <summary>
    /// Creates a chord from a collection of notes
    /// </summary>
    /// <param name="notes">Notes to create the chord from</param>
    /// <returns>A chord created from the notes</returns>
    public static Chord Create(IEnumerable<Note> notes)
    {
        return new Chord(notes, null, null, null);
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

        return new Chord(notes, formula, 0, root.BasePitch);
    }

    /// <summary>
    /// Creates a chord definition that can be manipulated to build a custom chord using the <see cref="ChordDefinition.With(ChordFunction, Accident)"/> and <see cref="ChordDefinition.Build"/> methods
    /// </summary>
    /// <param name="root">Root note of the chord</param>
    /// <returns>A chord definition that can be manipulated to build a custom chord</returns>
    public static ChordDefinition Build(Note root)
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

        return Inversion >= invertedNotes.Count - 1
            ? new Chord(invertedNotes, Formula, 0, RootPitch) 
            : new Chord(invertedNotes, Formula, Inversion + 1, RootPitch);
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

        var rootPitch = scale.Pitches[(int)scaleDegree];

        var root = Note.Create(rootPitch, octave);

        return Create(scale, root, ScaleStep.II, ScaleStep.II);
    }

    /// <summary>
    /// Creates a chord based on an a scale, root pitch and steps.
    /// <para>The following code should create a chord that starts with the I, then goes two scale degrees up (to III), and the goes another two degrees up (to V). Resulting in a I, III, V chord</para>
    /// <code>
    /// var scale = ScaleFormulas.Ionian.CreateForRoot(Pitch.E);
    /// var chord = Chord.Create(scale, scale.I, Octave.OneLine, ScaleStep.II, ScaleStep.II);</code>
    /// </summary>
    /// <param name="scale">Scale</param>
    /// <param name="root">Root note</param>
    /// <param name="scaleSteps">The steps to find the notes (each step is relative to the previous one)</param>
    /// <returns>A chord created from the scale, root pitch and steps</returns>
    /// <exception cref="ArgumentOutOfRangeException" />
    public static Chord Create(Scale scale, Note root, params ScaleStep[] scaleSteps)
    {
        scale.Pitches
            .Throw("The root pitch is not in the scale")
            .IfNotContains(root.BasePitch);

        var notes = new List<Note>
        {
            root
        };

        var currentPitch = root.BasePitch;
        var currentOctave = root.Octave;

        foreach (var scaleStep in scaleSteps)
        {
            var otherPitch = scale._pitches.GetNext(currentPitch, (int)scaleStep);

            if (otherPitch < currentPitch)
            {
                currentOctave += 1;
            }

            notes.Add(Note.Create(otherPitch, currentOctave));

            currentPitch = otherPitch;
        }

        var intervals = notes
            .Skip(1)
            .Select(x => root.IntervalWithOther(x))
            .ToArray();

        var existingFormula = ChordFormulas.All.FirstOrDefault(x => x.Intervals.SequenceEqual(intervals));

        var formula = existingFormula ?? new ChordFormula("Custom", intervals);

        var chord = new Chord(notes, formula, 0, root.BasePitch);

        return chord;
    }

    /// <summary>
    /// Creates a chord based on an a scale and chord type
    /// </summary>
    /// <param name="scale">Scale</param>
    /// <param name="octave">Octave to start the root note in</param>
    /// <param name="rootPitch">The root pitch to start the chord</param>
    /// <param name="chordType">Type of the chord</param>
    /// <param name="amountOfNotes">Amount of chord notes</param>
    /// <returns>A chord created from the scale and chord type</returns>
    /// <exception cref="ArgumentException" />
    /// <exception cref="ArgumentOutOfRangeException" />
    public static Chord Create(Scale scale, Octave octave, Pitch rootPitch, ChordType chordType, int amountOfNotes)
    {
        amountOfNotes
            .Throw()
            .IfNegativeOrZero();

        scale.Pitches
            .Throw()
            .IfNotContains(rootPitch);

        var scaleStep = chordType switch
        {
            ChordType.Tertian => ScaleStep.II,
            ChordType.Quartal => ScaleStep.III,
            ChordType.Quintal => ScaleStep.IV,
            ChordType.Sextal => ScaleStep.V,
            ChordType.Septimal => ScaleStep.VI,
            _ => throw ExhaustiveMatch.Failed(chordType)
        };

        var steps = Enumerable
            .Range(0, amountOfNotes - 1)
            .Select(x => scaleStep)
            .ToArray();

        var root = Note.Create(rootPitch, octave);

        return Create(scale, root, steps);
    }

    private static string GetName(Pitch root, ChordFormula formula, int inversion)
    {
        return inversion == 0
            ? $"{root}{formula.AbreviatedName}"
            : $"{root}{formula.AbreviatedName} ({Humanizer.AddOrdinal(inversion)} inversion)";
    }

    private static (ChordFormula chordFormula, int inversion, Pitch rootPitch) GetFormulaAndInversionAndRootPitch(IReadOnlyList<Note> notes)
    {
        var pitches = notes
            .Select(x => x.BasePitch)
            .ToList();

        var chordPitchesDefinition = ChordPitchesDefinitions.All.FirstOrDefault(x => x.Pitches.ContainsSameElements(pitches));

        if (chordPitchesDefinition is null)
        {
            // the pitches didn't match any chord known in the library
            return (ChordFormulas.Unknown, 0, pitches[0]);
        }

        var bassPitch = pitches[0];

        var indexOfBassInChordFormula = chordPitchesDefinition.Pitches.IndexOf(bassPitch);

        // var indexOfBass = pitches.IndexOf(chordPitchesDefinition.RootPitch);

        return (chordPitchesDefinition.ChordFormula, indexOfBassInChordFormula, chordPitchesDefinition.RootPitch);
    }

    public override string ToString()
    {
        var noteNames = string.Join(", ", Notes);
        return $"{Name} ({noteNames})";
    }
}