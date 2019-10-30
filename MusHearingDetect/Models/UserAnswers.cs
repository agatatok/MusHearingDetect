using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Models
{
    public static class UserAnswers
    {
        private static List<Answer> answers = new List<Answer>();

        public static IEnumerable<Answer> Answers
        {
            get { return answers; }
        }

        public static void AddAnswer(Answer answer)
        {
            answers.Add(answer);
        }
    }
}
