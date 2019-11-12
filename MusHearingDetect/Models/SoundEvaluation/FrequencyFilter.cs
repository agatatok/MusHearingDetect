using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Models.SoundEvaluation
{
    public static class FrequencyFilter
    {
        public static float CalculateMainFreq(List<float> frequencies)
        {
            int invalidSamples = (int)Math.Ceiling(0.05 * (double)frequencies.Count);
            List<float> sublist = frequencies.GetRange(invalidSamples, frequencies.Count - invalidSamples-1);
            return sublist.Average();  
        }
    }
}
