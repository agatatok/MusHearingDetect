using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Models
{
    public static class UserAnswers
    {
        private static List<bool> answers = new List<bool>();

        public static IEnumerable<bool> Answers
        {
            get { return answers; }
        }

        public static void AddAnswer(bool answer)
        {
            answers.Add(answer);
        }
    }
}
