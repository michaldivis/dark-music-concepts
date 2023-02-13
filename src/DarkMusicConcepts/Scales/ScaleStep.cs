namespace DarkMusicConcepts;

/// <summary>
/// Represents the size of a step to take relative to scale positions
/// <para>Example</para>
/// <para><see cref="I"/> should go from <see cref="ScaleDegree.I"/> to <see cref="ScaleDegree.II"/></para>
/// <para><see cref="II"/> should go from <see cref="ScaleDegree.I"/> to <see cref="ScaleDegree.III"/></para>
/// </summary>
public enum ScaleStep
{
    I = 1,
    II = 2,
    III = 3,
    IV = 4,
    V = 5,
    VI = 6,
    VII = 7
}