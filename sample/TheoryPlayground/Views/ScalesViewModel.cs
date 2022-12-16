namespace TheoryPlayground.Views;

public partial class ScalesViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Scale))]
    private Note _selectedRootNote = Notes.C4;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Scale))]
    private ScaleFormula _selectedScaleFormula = ScaleFormulas.HarmonicMinor;

    public Scale Scale => SelectedScaleFormula.Create(SelectedRootNote.BasePitch);

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
}