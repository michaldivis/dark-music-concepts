using System.Linq;

namespace TheoryPlayground.Views;

public partial class ChordProgressionsViewModel : ViewModelBase
{
    [ObservableProperty]
    private Note _selectedRootNote = Notes.C4;

    [ObservableProperty]
    private ScaleFormula _selectedScaleFormula = ScaleFormulas.HarmonicMinor;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsProgressionDefinitionValid))]
    [NotifyCanExecuteChangedFor(nameof(PlayCommand))]
    private string _progressionDefinition = "1 4 5 4";

    public bool IsProgressionDefinitionValid => CanPlay();

    [RelayCommand(CanExecute = nameof(IsProgressionDefinitionValid))]
    private async Task Play()
    {
        var scale = SelectedScaleFormula.Create(SelectedRootNote.BasePitch);
        var scaleDegrees = ParseProgression(ProgressionDefinition);
        var chordProgression = ChordProgression.Create(scaleDegrees);
        var chords = chordProgression.GetChords(scale, SelectedRootNote.Octave);

        foreach (var chord in chords)
        {
            AudioPlayer.Instance.Play(chord);
            await Task.Delay(1100);
        }
    }

    private bool CanPlay()
    {
        try
        {
            return ParseProgression(ProgressionDefinition).Any();
        }
        catch (Exception)
        {
            return false;
        }
    }

    private ScaleDegree[] ParseProgression(string definition)
    {
        return definition
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(number => ParseScaleDegree(number))
            .ToArray();
    }

    private ScaleDegree ParseScaleDegree(string number)
    {
        return number switch
        {
            "1" => ScaleDegree.I,
            "2" => ScaleDegree.II,
            "3" => ScaleDegree.III,
            "4" => ScaleDegree.IV,
            "5" => ScaleDegree.V,
            "6" => ScaleDegree.VI,
            "7" => ScaleDegree.VII,
            _ => throw new ArgumentException($"Invalid scale degree: {number}")
        };
    }
}