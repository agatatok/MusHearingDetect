using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Models.SoundEvaluation
{
    public class FrequencyClassificator
    {
        float baseFrequency;
        const float deviation = 25;

        public FrequencyClassificator(float baseFrequency)
        {
            this.baseFrequency = baseFrequency;
        }

        public bool Validate(float frequency)
        {
            if (frequency < baseFrequency + deviation && frequency > baseFrequency - deviation)
            {
                return true;
            }
            else return false;
        }

    }
}
