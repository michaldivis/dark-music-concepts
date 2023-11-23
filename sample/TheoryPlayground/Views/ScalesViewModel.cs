namespace TheoryPlayground.Views;

public partial class ScalesViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Scale))]
    private Note _selectedRootNote = Notes.C4;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Scale))]
    [NotifyPropertyChangedFor(nameof(CreationSteps))]
    private ScaleFormula _selectedScaleFormula = ScaleFormulas.HarmonicMinor;

    public Scale Scale => SelectedScaleFormula.Create(SelectedRootNote.BasePitch);
    public string CreationSteps => GetCreationSteps(SelectedScaleFormula);

    [RelayCommand]
    private async Task Play()
    {
        foreach (var pitch in Scale.Pitches)
        {
            var note = Note.Create(pitch, SelectedRootNote.Octave);
            AudioPlayer.Instance.Play(note); 
            await Task.Delay(1100);
        }
    }

    private static string GetCreationSteps(ScaleFormula scaleFormula)
    {
        var current = Notes.C4;
        var creationSteps = new List<string>();

        var intervals = scaleFormula.Intervals.Skip(1).ToList();
        intervals.Add(Intervals.PerfectOctave);

        foreach (var interval in intervals) 
        {
            var next = Notes.C4.TransposeUp(interval);

            var difference = current.IntervalWithOther(next);

            var creationStep = difference.Distance switch
            {
                1 => "H",
                2 => "W",
                3 => "1.5W",
                4 => "2W",
                _ => "wut?"
            };

            creationSteps.Add(creationStep);

            current = next;
        }

        return string.Join('-', creationSteps);
    }
}