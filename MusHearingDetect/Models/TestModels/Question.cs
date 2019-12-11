using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Models
{
    public class Question
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Answer FirstAnswer { get; set; }
        public Answer SecondAnswer { get; set; }

        public Question()
        {

        }
    }
}
