using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Models
{
    public class Answer
    {
        public string AnswerTxt { get; set; }
        public bool IsRight { get; set; }

        public Answer()
        {
        }

        public Answer(string AnswerTxt, bool isRight)
        {
            this.AnswerTxt = AnswerTxt;
            this.IsRight = isRight;
        }
    }
}
