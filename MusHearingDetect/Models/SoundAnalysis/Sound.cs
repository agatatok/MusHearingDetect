using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NAudio.Wave;

namespace MusHearingDetect.Models.VoiceRecognition
{
    public class Sound
    { 

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

    }
}
