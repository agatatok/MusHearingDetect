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
        public Question Question { get; set; }

        public Audiofile()
        {
            
        }
        public Audiofile(int Id)
        {
            this.Id = Id;
            this.Src = GetSrc(Id);
        }
       
        private static string GetSrc(int Id)
        {
            char pad = '0';
            return String.Concat("~/audio/Audio", Id.ToString().PadLeft(3, pad), ".wav");
        }
    }
}
