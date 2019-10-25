using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Models
{
    public class Audiofile
    {
        public int Id { get; set; }
        public string Src { get; set; }

        public Audiofile(int Id)
        {
            char pad = '0';
            this.Src = String.Concat("~/Audio/UserAudio", Id.ToString().PadLeft(3, pad), ".wav");
        }
    }
}
