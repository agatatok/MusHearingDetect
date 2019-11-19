using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public static double CalculateResult()
        {
            return Math.Round((double)answers.Count(a => a) / (double)answers.Count*100);
        }
    }
}
