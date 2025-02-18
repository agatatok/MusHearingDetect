﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Models.VoiceRecognition
{
    class Autocorrelator
    {
        float[] prevBuffer;
        int minOffset;
        int maxOffset;
        float sampleRate;

        public Autocorrelator(int sampleRate)
        {
            this.sampleRate = (float)sampleRate;
            int minFreq = 220;
            int maxFreq = 550;

            this.maxOffset = sampleRate / minFreq;
            this.minOffset = sampleRate / maxFreq;
        }

        public float DetectPitch(float[] buffer, int frames)
        {
            if (prevBuffer == null)
            {
                prevBuffer = new float[frames];
            }
            float secCor = 0;
            int secLag = 0;

            float maxCorr = 0;
            int maxLag = 0;


            for (int lag = maxOffset; lag >= minOffset; lag--)
            {
                float corr = 0; //calculated as the sum of squares
                for (int i = 0; i < frames; i++)
                {
                    int oldIndex = i - lag;
                    float sample = ((oldIndex < 0) ? prevBuffer[frames + oldIndex] : buffer[oldIndex]);
                    corr += (sample * buffer[i]);
                }
                if (corr > maxCorr)
                {
                    maxCorr = corr;
                    maxLag = lag;
                }
                if (corr >= 0.9 * maxCorr)
                {
                    secCor = corr;
                    secLag = lag;
                }
            }
            for (int n = 0; n < frames; n++)
            {
                prevBuffer[n] = buffer[n];
            }
            float noiseThreshold = frames / 1000f;
            if (maxCorr < noiseThreshold || maxLag == 0) return 0.0f;
            //return 44100.0f / secLag;   //--works better for singing
            return this.sampleRate / maxLag;
        }
    }
}
