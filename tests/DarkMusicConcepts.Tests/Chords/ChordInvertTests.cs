﻿namespace DarkMusicConcepts;

public class ChordInvertTests
{
    public static IEnumerable<Note> NotesUpTo7ThOctave => Notes.All.Where(a => a.Octave <= Octave.Seven);

    public class InvertCommonTriadsTests
    {
        private static readonly ChordFormula[] commonTriads =
        {
            ChordFormulas.Major,
            ChordFormulas.Minor,
            ChordFormulas.Diminished,
            ChordFormulas.Augmented
        };

        public static IEnumerable<object[]> CommonTriadsTestData
        {
            get
            {
                foreach (var chordFormula in commonTriads)
                foreach (var rootNote in NotesUpTo7ThOctave)
                    yield return new object[] { chordFormula, rootNote };
            }
        }

        [Theory]
        [MemberData(nameof(CommonTriadsTestData))]
        public void Invert_Once_ShouldReturn_FirstInversion(ChordFormula chordFormula, Note root)
        {
            var chord = Chord.Create(root, chordFormula);

            var inversion1 = chord.Invert();

            inversion1.Notes.Should().Equal(chord.Notes[1], chord.Notes[2], chord.Notes[0].TransposeUp(Intervals.PerfectOctave));
            inversion1.Inversion.Should().Be(1);
        }

        [Theory]
        [MemberData(nameof(CommonTriadsTestData))]
        public void Invert_Twice_ShouldReturn_SecondInversion(ChordFormula chordFormula, Note root)
        {
            var chord = Chord.Create(root, chordFormula);

            var inversion2 = chord.Invert().Invert();

            inversion2.Notes.Should().Equal(chord.Notes[2], chord.Notes[0].TransposeUp(Intervals.PerfectOctave),
                chord.Notes[1].TransposeUp(Intervals.PerfectOctave));
            inversion2.Inversion.Should().Be(2);
        }

        [Theory]
        [MemberData(nameof(CommonTriadsTestData))]
        public void Invert_ThreeTimes_ShouldReturn_InitialTriad_OneOctaveHigher(ChordFormula chordFormula, Note root)
        {
            var chord = Chord.Create(root, chordFormula);

            var inversion2 = chord.Invert().Invert().Invert();

            inversion2.Notes.Should().Equal(
                chord.Notes[0].TransposeUp(Intervals.PerfectOctave),
                chord.Notes[1].TransposeUp(Intervals.PerfectOctave), chord.Notes[2].TransposeUp(Intervals.PerfectOctave));
            inversion2.Inversion.Should().Be(0);
        }
    }

    public class InvertCommonSeventhChordsTests
    {
        private static readonly ChordFormula[] commonTriads =
        {
            ChordFormulas.DominantSeventh,
            ChordFormulas.MajorSeventh,
            ChordFormulas.MinorSeventh,
            ChordFormulas.MinorMajorSeventh,
            ChordFormulas.DiminishedSeventh
        };

        public static IEnumerable<object[]> CommonSeventhChordsTestData
        {
            get
            {
                foreach (var chordFormula in commonTriads)
                foreach (var rootNote in NotesUpTo7ThOctave)
                    yield return new object[] { chordFormula, rootNote };
            }
        }

        [Theory]
        [MemberData(nameof(CommonSeventhChordsTestData))]
        public void Invert_Once_ShouldReturn_FirstInversion(ChordFormula chordFormula, Note root)
        {
            var chord = Chord.Create(root, chordFormula);

            var inversion1 = chord.Invert();

            inversion1.Notes.Should().Equal(
                chord.Notes[1],
                chord.Notes[2],
                chord.Notes[3],
                chord.Notes[0].TransposeUp(Intervals.PerfectOctave));
            inversion1.Inversion.Should().Be(1);
        }

        [Theory]
        [MemberData(nameof(CommonSeventhChordsTestData))]
        public void Invert_Twice_ShouldReturn_SecondInversion(ChordFormula chordFormula, Note root)
        {
            var chord = Chord.Create(root, chordFormula);

            var inversion2 = chord.Invert().Invert();

            inversion2.Notes.Should().Equal(
                chord.Notes[2],
                chord.Notes[3],
                chord.Notes[0].TransposeUp(Intervals.PerfectOctave),
                chord.Notes[1].TransposeUp(Intervals.PerfectOctave));
            inversion2.Inversion.Should().Be(2);
        }

        [Theory]
        [MemberData(nameof(CommonSeventhChordsTestData))]
        public void Invert_ThreeTimes_ShouldReturn_ThirdInversion(ChordFormula chordFormula, Note root)
        {
            var chord = Chord.Create(root, chordFormula);

            var inversion2 = chord.Invert().Invert().Invert();

            inversion2.Notes.Should().Equal(
                chord.Notes[3],
                chord.Notes[0].TransposeUp(Intervals.PerfectOctave),
                chord.Notes[1].TransposeUp(Intervals.PerfectOctave),
                chord.Notes[2].TransposeUp(Intervals.PerfectOctave));
            inversion2.Inversion.Should().Be(3);
        }

        [Theory]
        [MemberData(nameof(CommonSeventhChordsTestData))]
        public void Invert_FourTimes_ShouldReturn_InitialSeventhChord_OneOctaveHigher(ChordFormula chordFormula, Note root)
        {
            var chord = Chord.Create(root, chordFormula);

            var inversion2 = chord.Invert().Invert().Invert().Invert();

            inversion2.Notes.Should().Equal(
                chord.Notes[0].TransposeUp(Intervals.PerfectOctave),
                chord.Notes[1].TransposeUp(Intervals.PerfectOctave),
                chord.Notes[2].TransposeUp(Intervals.PerfectOctave),
                chord.Notes[3].TransposeUp(Intervals.PerfectOctave));
            inversion2.Inversion.Should().Be(0);
        }
    }
}