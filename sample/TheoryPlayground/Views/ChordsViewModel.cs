using DarkMusicConcepts;

namespace TheoryPlayground.Views;

public partial class ChordsViewModel : ViewModelBase
{
    public RootAndFormulaDemo RootAndFormula { get; } = new();
    public ScaleAndScaleDegreeDemo ScaleAndScaleDegree { get; } = new();
    public ScaleAndChordTypeDemo ScaleAndChordType { get; } = new();    

    public partial class RootAndFormulaDemo : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chord))]
        private Note _selectedRootNote = Notes.C4;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chord))]
        private ChordFormula _selectedChordFormula = ChordFormulas.Major;

        public Chord Chord => Chord.Create(SelectedRootNote, SelectedChordFormula);

        [RelayCommand]
        private void Play()
        {
            AudioPlayer.Instance.Play(Chord);
        }
    }

    public partial class ScaleAndScaleDegreeDemo : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chord))]
        private Note _selectedRootNote = Notes.C4;
        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chord))]
        private ScaleFormula _selectedScaleFormula = ScaleFormulas.Dorian;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chord))]
        private ScaleDegree _selectedScaleDegree = ScaleDegree.I;

        public Chord Chord => Chord.Create(SelectedScaleFormula.Create(SelectedRootNote.BasePitch), SelectedRootNote.Octave, SelectedScaleDegree);

        [RelayCommand]
        private void Play()
        {
            AudioPlayer.Instance.Play(Chord);
        }

        [RelayCommand]
        private async Task PlayAllScaleDegrees()
        {
            foreach (var scaleDegree in ScaleDegrees)
            {
                var scale = SelectedScaleFormula.Create(SelectedRootNote.BasePitch);
                var chord = Chord.Create(scale, SelectedRootNote.Octave, scaleDegree);
                AudioPlayer.Instance.Play(chord);
                await Task.Delay(1100);
            }
        }
    }

    public partial class ScaleAndChordTypeDemo : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chord))]
        private Note _selectedRootNote = Notes.C4;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chord))]
        private ScaleFormula _selectedScaleFormula = ScaleFormulas.Phrygian;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chord))]
        private ChordType _selectedChordType = ChordType.Tertian;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chord))]
        private int _selectedAmountOfNotes = 3;
        
        public int[] AmountsOfNotes { get; } = new[] { 2, 3, 4, 5, 6 };

        public Chord Chord => Chord.Create(SelectedScaleFormula.Create(SelectedRootNote.BasePitch), SelectedRootNote.Octave, SelectedRootNote.BasePitch, SelectedChordType, SelectedAmountOfNotes);

        [RelayCommand]
        private void Play()
        {
            AudioPlayer.Instance.Play(Chord);
        }
    }
}