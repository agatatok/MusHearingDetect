using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NAudio.Wave;

namespace MusHearingDetect.Models
{
    public class Recording
    {
        BufferedWaveProvider bwp;
        
        public void StartDetecting(int device)
        {
            WaveInEvent waveIn = new WaveInEvent();
            waveIn.DeviceNumber = device;
            waveIn.WaveFormat = new WaveFormat(44100, 1);
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            waveIn.StartRecording();
        }
    }
}
