namespace TheoryPlayground.Views;

public abstract partial class ViewModelBase : ObservableObject
{
    public Pitch[] Pitches { get; } = Enum.GetValues<Pitch>();
    public Octave[] Octaves { get; } = Enum.GetValues<Octave>();
    public ScaleDegree[] ScaleDegrees { get; } = Enum.GetValues<ScaleDegree>();
    public ScaleStep[] ScaleSteps { get; } = Enum.GetValues<ScaleStep>();
}
