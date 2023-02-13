using CommunityToolkit.Mvvm.Input;

namespace TheoryPlayground.Views;

public partial class NotesViewModel : ViewModelBase
{
    [ObservableProperty]
    private Note _selectedNote = Notes.C4;

    [RelayCommand]
    private void Play()
    {
        AudioPlayer.Instance.Play(SelectedNote);
    }
}