using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Dsp;
using NAudio.Wave.SampleProviders;

namespace MusHearingDetect.Models
{
    public class Resampler
    {
        private long waveBufferSize;
        public long WaveBufferSize { get { return waveBufferSize; } }
        private string wavFilePath;
        public string WavFilePath
        {
            get { return wavFilePath; }
        }

        public Resampler(string path)
        {
            wavFilePath = path;
        }

        public IWaveProvider Convert()
        {
            var buffer = File.ReadAllBytes(wavFilePath);
            using (Stream stream = new MemoryStream(buffer))
            {
                using (var rawStream = new RawSourceWaveStream(stream, new WaveFormat(48000,16, 1)))
                using (var downsample = new WaveFormatConversionStream(new WaveFormat(44100, 16, 1), rawStream))
                using (var outputStream = new MemoryStream())
                {
                    WaveFileWriter.WriteWavFileToStream(outputStream, downsample.ToSampleProvider().ToWaveProvider16());
                    var outputData = outputStream.ToArray();
                    waveBufferSize = outputData.Length;
                    BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat(44100, 1));
                    if(outputData.Length < bufferedWaveProvider.BufferLength)
                        bufferedWaveProvider.AddSamples(outputData, 0, outputData.Length);
                    else bufferedWaveProvider.AddSamples(outputData, 0, bufferedWaveProvider.BufferLength);
                    IWaveProvider finalStream = new Wave16ToFloatProvider(bufferedWaveProvider);
                    return finalStream;
                }
            }
        }
    }
}

