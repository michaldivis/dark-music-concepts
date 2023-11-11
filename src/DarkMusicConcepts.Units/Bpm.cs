namespace DarkMusicConcepts;

/// <summary>
/// <para>Beats per minute.</para>
/// <para>In musical terminology, tempo (Italian, 'time'; plural tempos, or tempi from the Italian plural) also known as beats per minute, is the speed or pace of a given composition. In classical music, tempo is typically indicated with an instruction at the start of a piece (often using conventional Italian terms) and is usually measured in beats per minute (or bpm). In modern classical compositions, a "metronome mark" in beats per minute may supplement or replace the normal tempo marking, while in modern genres like electronic dance music, tempo will typically simply be stated in BPM.</para>
/// </summary>
public class Bpm : Unit<double, Bpm>, IUnit<double, Bpm>
{
    public static double MinValue { get; } = 0;
    public static double MaxValue { get; } = double.MaxValue;

    private Bpm(double value) : base(value)
    {
    }

    static Bpm IUnit<double, Bpm>.Create(double value) => new(value);
}