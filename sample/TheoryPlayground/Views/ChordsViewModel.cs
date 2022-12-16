using CommunityToolkit.Mvvm.Input;

namespace TheoryPlayground.Views;

public partial class ChordsViewModel : ViewModelBase
{
    public RootAndFormulaDemo RootAndFormula { get; } = new();
    public ScaleAndScaleDegreeDemo ScaleAndScaleDegree { get; } = new();

    public partial class RootAndFormulaDemo : ViewModelBase
    {
        [ObservableProperty]
        private Note _selectedRootNote = Notes.C2;

        [ObservableProperty]
        private ChordFormula _selectedChordFormula = ChordFormulas.Major;

        [RelayCommand]
        private void Play()
        {
            var chord = Chord.Create(SelectedRootNote, SelectedChordFormula);
            AudioPlayer.Instance.Play(chord);
        }
    }

    public partial class ScaleAndScaleDegreeDemo : ViewModelBase
    {
        [ObservableProperty]
        private Note _selectedRootNote = Notes.C2;
        
        [ObservableProperty]
        private ScaleFormula _selectedScaleFormula = ScaleFormulas.Dorian;

        [ObservableProperty]
        private ScaleDegree _selectedScaleDegree = ScaleDegree.I;

        [RelayCommand]
        private void Play()
        {
            var scale = SelectedScaleFormula.Create(SelectedRootNote.BasePitch);
            var chord = Chord.Create(scale, SelectedRootNote.Octave, SelectedScaleDegree);
            AudioPlayer.Instance.Play(chord);
        }
    }
}