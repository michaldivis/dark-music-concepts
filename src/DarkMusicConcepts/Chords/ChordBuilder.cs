namespace DarkMusicConcepts.Chords;
public static class ChordBuilder
{
    public static ChordInTheMaking ForRoot(Note root)
    {
        return new ChordInTheMaking(root);
    }

    public class ChordInTheMaking
    {
        private readonly Note _root;
        private readonly List<Interval> _intervals = new();

        internal ChordInTheMaking(Note root)
        {
            _root = root;
        }

        public ChordInTheMaking With(ChordFunction chordFunction, Accident accident = Accident.None)
        {
            var interval = chordFunction.Intervals.FirstOrDefault(x => x.Accident == accident);

            if (interval is null)
            {
                //TODO handle interval not found
                throw new ArgumentException("Interval with this accident not found in the specified chord function");
            }

            _intervals.Add(interval);

            return this;
        }

        public Chord Build()
        {
            var existingFormula = ChordFormulas.All.FirstOrDefault(x => x.Intervals.SequenceEqual(_intervals));

            if(existingFormula is null)
            {
                var customFormula = new ChordFormula("Custom", _intervals.ToArray());
                return Chord.Create(_root, customFormula);
            }

            return Chord.Create(_root, existingFormula);
        }
    }
}