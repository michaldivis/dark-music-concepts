namespace DarkMusicConcepts.Chords;

/// <summary>
/// A collection of chord progressions. This collection not complete by any means. It should serve more as demo of what the chord progressions can be. Feel free to create your own <see cref="ChordProgression"/>s.
/// </summary>
public static class ChordProgressions
{
    public static class Pop
    {
        //// <summary>
        ///This chord progression uses the tonic, subdominant, dominant, and subdominant chords in that order. It is a common and versatile progression, and it can be used in many different keys and styles of pop music. For example, in the key of C major, the progression would be C-F-G-F.
        ///</summary>
        public static ChordProgression I_IV_V_IV { get; } = new(ScaleDegree.I, ScaleDegree.IV, ScaleDegree.V, ScaleDegree.IV);

        /// <summary>
        ///This chord progression uses the tonic, relative minor, subdominant, and dominant chords in that order. It is a popular progression in pop music, and it creates a sense of movement and emotional contrast. For example, in the key of C major, the progression would be C-Am-F-G.
        ///</summary>
        public static ChordProgression I_VI_IV_V { get; } = new(ScaleDegree.I, ScaleDegree.VI, ScaleDegree.IV, ScaleDegree.V);

        /// <summary>
        ///This chord progression uses the supertonic, subdominant, tonic, and dominant chords in that order. It is a classic progression in pop music, and it creates a sense of tension and resolution. For example, in the key of C major, the progression would be Dm-F-C-G.
        ///</summary>
        public static ChordProgression II_IV_I_V { get; } = new(ScaleDegree.II, ScaleDegree.IV, ScaleDegree.I, ScaleDegree.V);

        /// <summary>
        ///This chord progression uses the subdominant, subdominant, tonic, dominant, and subdominant chords in that order. It is a repetitive and catchy progression, and it can be used in many different styles of pop music. For example, in the key of C major, the progression would be F-F-C-G-F.
        ///</summary>
        public static ChordProgression IV_IV_I_V_IV { get; } = new(ScaleDegree.IV, ScaleDegree.IV, ScaleDegree.I, ScaleDegree.V, ScaleDegree.IV);
    }

    public static class Oriental
    {
        /// <summary>
        ///This chord progression uses the tonic, mediant, subdominant, supertonic, and dominant chords in that order. It creates a dark and mysterious sound, and it can be used in many different keys and styles of oriental music. For example, in the key of C double harmonic minor, the progression would be C-Eb-F-D-G.
        ///</summary>
        public static ChordProgression I_III_IV_II_V { get; } = new(ScaleDegree.I, ScaleDegree.III, ScaleDegree.IV, ScaleDegree.II, ScaleDegree.V);

        /// <summary>
        ///This chord progression uses the tonic, subdominant, supertonic, mediant, and dominant chords in that order. It creates a tense and suspenseful sound, and it can be used in many different keys and styles of oriental music. For example, in the key of C double harmonic minor, the progression would be C-F-D-Eb-G.
        ///</summary>
        public static ChordProgression I_IV_II_III_V { get; } = new(ScaleDegree.I, ScaleDegree.IV, ScaleDegree.II, ScaleDegree.III, ScaleDegree.V);

        /// <summary>
        ///This chord progression uses the tonic, subdominant, dominant, and mediant chords in that order. It creates a sense of conflict and resolution, and it can be used in many different keys and styles of oriental music. For example, in the key of C double harmonic minor, the progression would be C-F-G-Eb.
        ///</summary>
        public static ChordProgression I_IV_V_III { get; } = new(ScaleDegree.I, ScaleDegree.IV, ScaleDegree.V, ScaleDegree.III);

        /// <summary>
        ///This chord progression uses the supertonic, subdominant, tonic, and dominant chords in that order. It creates a sense of tension and release, and it can be used in many different keys and styles of oriental music. For example, in the key of C double harmonic minor, the progression would be D-F-C-G.
        ///</summary>
        public static ChordProgression II_IV_I_V { get; } = new(ScaleDegree.II, ScaleDegree.IV, ScaleDegree.I, ScaleDegree.V);
    }

    public static class SciFi
    {
        /// <summary>
        ///This chord progression uses the tonic, subdominant, major seventh, and mediant chords in that order. It creates a strange and otherworldly sound, and it can be used in many different keys and styles of sci-fi music. For example, in the key of C major, the progression would be C-F-B-Eb.
        ///</summary>
        public static ChordProgression I_IV_VII_III { get; } = new(ScaleDegree.I, ScaleDegree.IV, ScaleDegree.VII, ScaleDegree.III);

        /// <summary>
        ///This chord progression uses the tonic, mediant, major seventh, and subdominant chords in that order. It creates a sense of mystery and tension, and it can be used in many different keys and styles of sci-fi music. For example, in the key of C major, the progression would be C-Eb-B-F.
        ///</summary>
        public static ChordProgression I_III_VII_IV { get; } = new(ScaleDegree.I, ScaleDegree.III, ScaleDegree.VII, ScaleDegree.IV);

        /// <summary>
        ///This chord progression uses the tonic, subdominant, dominant, and major seventh chords in that order. It creates a sense of movement and tension, and it can be used in many different keys and styles of sci-fi music. For example, in the key of C major, the progression would be C-F-G-B.
        ///</summary>
        public static ChordProgression I_IV_V_VII { get; } = new(ScaleDegree.I, ScaleDegree.IV, ScaleDegree.V, ScaleDegree.VII);

        /// <summary>
        ///This chord progression uses the tonic, subdominant, major seventh, and dominant chords in that order. It creates a sense of suspense and resolution, and it can be used in many different keys and styles of sci-fi music. For example, in the key of C major, the progression would be C-F-B-G.
        ///</summary>
        public static ChordProgression I_IV_VII_V { get; } = new(ScaleDegree.I, ScaleDegree.IV, ScaleDegree.VII, ScaleDegree.V);
    }
}