using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NAudio.Wave;

namespace MusHearingDetect.Models.VoiceRecognition
{
    public class Sound
    {
        Dictionary<string, float> noteBaseFreqs = new Dictionary<string, float>()
            {
                { "C", 16.35f },
                { "C#", 17.32f },
                { "D", 18.35f },
                { "Eb", 19.45f },
                { "E", 20.60f },
                { "F", 21.83f },
                { "F#", 23.12f },
                { "G", 24.50f },
                { "G#", 25.96f },
                { "A", 27.50f },
                { "Bb", 29.14f },
                { "B", 30.87f },
            };

        public List<float> DetectFrequency(Resampler waveResampler)
        {
            List<float> detectedFrequencies = new List<float>();
            var waveStream = waveResampler.Convert();

            var pitch = new Pitch(waveStream);
            byte[] buffer = new byte[8192];

            int bytesRead = 0;
            int totalBytesProcessed = 0;
            do
            {
                bytesRead = waveStream.Read(buffer, 0, buffer.Length);
                float freq = pitch.Get(buffer);
                if (0 != freq) detectedFrequencies.Add(freq);
                totalBytesProcessed += bytesRead;

            } while (totalBytesProcessed < waveResampler.WaveBufferSize);

            return detectedFrequencies;
        }

        public string GetNote(float freq)
        {
            float baseFreq;

            foreach (var note in noteBaseFreqs)
            {
                baseFreq = note.Value;

                for (int i = 0; i < 9; i++)
                {
                    if ((freq >= baseFreq - 0.5) && (freq < baseFreq + 0.485) || (freq == baseFreq))
                    {
                        return note.Key + i;
                    }

                    baseFreq *= 2;
                }
            }

            return null;
        }
    }
}
