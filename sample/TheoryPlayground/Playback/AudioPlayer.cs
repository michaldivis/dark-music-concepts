using NAudio.Wave.SampleProviders;
using NAudio.Wave;

namespace TheoryPlayground.Playback;

class AudioPlayer : IDisposable
{
    private readonly IWavePlayer _outputDevice;
    private readonly MixingSampleProvider _mixer;

    private static readonly TimeSpan _duration = TimeSpan.FromSeconds(1);

    public static AudioPlayer Instance { get; } = new(44100, 2);

    public AudioPlayer(int sampleRate = 44100, int channelCount = 2)
    {
        _outputDevice = new WaveOutEvent();
        _mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount))
        {
            ReadFully = true
        };
        
        _outputDevice.Init(_mixer);
        _outputDevice.Play();
    }

    public void Play(Note note)
    {
        Play(note.Frequency.Value);
    }

    public void Play(Chord chord)
    {
        foreach (var note in chord.Notes)
        {
            Play(note.Frequency.Value);
        }
    }

    private void Play(double frequency)
    {
        var sine = new SignalGenerator()
        {
            Gain = 0.2,
            Frequency = frequency,
            Type = SignalGeneratorType.Sin
        }
        .Take(_duration);

        AddMixerInput(sine);
    }

    private ISampleProvider ConvertToRightChannelCount(ISampleProvider input)
    {
        if (input.WaveFormat.Channels == _mixer.WaveFormat.Channels)
        {
            return input;
        }
        if (input.WaveFormat.Channels == 1 && _mixer.WaveFormat.Channels == 2)
        {
            return new MonoToStereoSampleProvider(input);
        }
        throw new NotImplementedException("Not yet implemented this channel count conversion");
    }

    private void AddMixerInput(ISampleProvider input)
    {
        _mixer.AddMixerInput(ConvertToRightChannelCount(input));
    }

    public void Dispose()
    {
        _outputDevice.Dispose();
    }
}