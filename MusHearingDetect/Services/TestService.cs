using Microsoft.AspNetCore.Http;
using MusHearingDetect.DbContexts;
using MusHearingDetect.Models;
using MusHearingDetect.Models.SoundEvaluation;
using MusHearingDetect.Models.VoiceRecognition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MusHearingDetect.Services
{
    public class TestService : ITestService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserContext _dbContext;
        


        public TestService(IHttpContextAccessor httpContextAccessor, UserContext userContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = userContext; 
        }

        public byte[] GetAudioArray(IFormFile file)
        {
            byte[] filedata = null;
            using (var target = new MemoryStream())
            { 
                file.CopyTo(target);
                filedata = target.ToArray();
            }
            return filedata;
        }

        public bool ProcessRecording(byte[] audioArray, int baseFreq)
        {
            var waveResampler = new Resampler(audioArray);
            Sound freqencyDetector = new Sound();
            List<float> result = freqencyDetector.DetectFrequency(waveResampler);
            float mainFrequency = FrequencyFilter.CalculateMainFreq(result);
            FrequencyClassificator FreqClass = new FrequencyClassificator(baseFreq);
            bool answer = FreqClass.Validate(mainFrequency);
            return answer;
            
        }

        //public void AddAnswerToDatabase(bool answer, int answerNumber)
        //{

        //    int? userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
        //    var user = _dbContext.Users.First(a => a.Id == userId);
        //    PropertyInfo info = user.GetType().GetProperty($"Answer{answerNumber.ToString()}");
        //    UserAnswers.AddAnswer(answer);
        //    info.SetValue(user, answer);
        //    _dbContext.SaveChanges();
        //}

    }
}
