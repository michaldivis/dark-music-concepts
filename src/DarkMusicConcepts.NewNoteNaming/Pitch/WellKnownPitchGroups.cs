using DarkMusicConcepts.NewNoteNaming.Extensions;

namespace DarkMusicConcepts.NewNoteNaming.Pitch;

public static class WellKnownPitchGroups
{
    public static readonly IReadOnlyList<Pitch> BlackKeysFlat = new List<Pitch>
    {
        WellKnownPitches.Db1,
        WellKnownPitches.Eb1,
        WellKnownPitches.Gb1,
        WellKnownPitches.Ab1,
        WellKnownPitches.Bb1,
        WellKnownPitches.Db2,
        WellKnownPitches.Eb2,
        WellKnownPitches.Gb2,
        WellKnownPitches.Ab2,
        WellKnownPitches.Bb2
    };

    public static readonly IReadOnlyList<Pitch> BlackKeysSharp = new List<Pitch>
    {
        WellKnownPitches.Cs1,
        WellKnownPitches.Ds1,
        WellKnownPitches.Fs1,
        WellKnownPitches.Gs1,
        WellKnownPitches.As1,
        WellKnownPitches.Cs2,
        WellKnownPitches.Ds2,
        WellKnownPitches.Fs2,
        WellKnownPitches.Gs2,
        WellKnownPitches.As2
    };

    public static readonly IReadOnlyList<Pitch> WhiteKeys = new List<Pitch>
    {
        WellKnownPitches.C1,
        WellKnownPitches.D1,
        WellKnownPitches.E1,
        WellKnownPitches.F1,
        WellKnownPitches.G1,
        WellKnownPitches.A1,
        WellKnownPitches.B1,
        WellKnownPitches.C2,
        WellKnownPitches.D2,
        WellKnownPitches.E2,
        WellKnownPitches.F2,
        WellKnownPitches.G2,
        WellKnownPitches.A2,
        WellKnownPitches.B2
    };

    public static readonly IReadOnlyList<Pitch> ChromaticWithSharps =
        WhiteKeys.Concat(BlackKeysSharp).OrderBy(pitch => pitch.CalculateMidiNote()).ToList();

    public static readonly IReadOnlyList<Pitch> ChromaticWithFlats =
        WhiteKeys.Concat(BlackKeysFlat).OrderBy(pitch => pitch.CalculateMidiNote()).ToList();
}
