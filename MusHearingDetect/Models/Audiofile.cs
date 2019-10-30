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
            this.Src = GetSrc(Id);
        }

        public Audiofile(Audiofile audiofile, int Id)
        {
            this.Id = Id;
            this.Question = audiofile.Question;
            this.Src = GetSrc(Id);
        }
        public static string GetSrc(int Id)
        {
            char pad = '0';
            return String.Concat("~/audio/UserAudio", Id.ToString().PadLeft(3, pad), ".wav");
        }
    }
}
