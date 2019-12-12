using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusHearingDetect.Models;
using System.IO;
using MusHearingDetect.Models.SoundEvaluation;
using MusHearingDetect.Models.VoiceRecognition;
using MusHearingDetect.Models.UserProfile;
using System.Reflection;
using MusHearingDetect.DbContexts;
using MusHearingDetect.Services;
using System.Threading.Tasks;

namespace MusHearingDetect.Controllers
{
    public class TestController : Controller
    {

        private readonly IHostingEnvironment env;
        private UserContext _dbContext;
        private ITestService _service;
        

        public TestController(IHostingEnvironment env, UserContext userContext, ITestService service)
        {
            this.env = env;
            _dbContext = userContext;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Questionnaire()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Questionnaire(User user)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                _dbContext.Entry(user).GetDatabaseValues();
                int id = user.Id;
                HttpContext.Session.SetInt32("UserId", id);
                HttpContext.Session.SetInt32("questionId", 1);
                return RedirectToAction("Question", new { Id = 1 });

            }
            return View(user);
        }


        [HttpGet]
        public IActionResult Question(int? id)
        {
            int? questionId = HttpContext.Session.GetInt32("questionId");
            if (id != null)
            {
                if (id!=questionId)
                {
                    return RedirectToAction("Question", new { Id= questionId });
                }

                var audiofile = AudioRepository.Audiofiles[(int)id - 1];
                ViewBag.Id = id;
                ViewBag.AudioSrc = audiofile.Src;
                ViewBag.Number = $"{id}/{AudioRepository.Audiofiles.Count}";
                HttpContext.Session.SetInt32("questionId", (int)++questionId);
                if (id == 14 || id == 15 || id == 16 || id == 17 || id == 18)
                {
                    return View("DiffQuestion", audiofile);
                }
                if (id == 19 || id ==20)
                {
                    return View("SingQuestion", audiofile);
                }
                return View(audiofile);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Question(string firstbtn, string secondbtn)
        {

            int? userId = HttpContext.Session.GetInt32("UserId");
            int id = int.Parse(this.RouteData.Values["id"].ToString());
            var audiofile = AudioRepository.Audiofiles[id - 1];

            var user = _dbContext.Users.First(a => a.Id == userId);
            PropertyInfo info = user.GetType().GetProperty($"Answer{id}");

            if (firstbtn != null)
            {
                UserAnswers.AddAnswer(audiofile.Question.FirstAnswer.IsRight);
                info.SetValue(user, audiofile.Question.FirstAnswer.IsRight);
                _dbContext.SaveChanges();

            }
            if (secondbtn != null)
            {
                UserAnswers.AddAnswer(audiofile.Question.SecondAnswer.IsRight);
                info.SetValue(user, audiofile.Question.SecondAnswer.IsRight);
                _dbContext.SaveChanges();
            }

            if (id < 21)
            {
                return RedirectToAction("Question", new { Id = id + 1 });
            }
            else
            {
                return RedirectToAction("YourResult");
            }

        }

        [HttpPost]
        public IActionResult SingQuestion()
        {

            int Id = int.Parse(this.RouteData.Values["id"].ToString());
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _dbContext.Users.First(a => a.Id == userId);
            PropertyInfo info = user.GetType().GetProperty($"Answer{Id}");
            

            var waveResampler = new Resampler(null);
            Sound freqencyDetector = new Sound();
            List<float> result = freqencyDetector.DetectFrequency(waveResampler);
            float mainFrequency = FrequencyFilter.CalculateMainFreq(result);
           
            if (Id == 19)
            {
                FrequencyClassificator FreqClass = new FrequencyClassificator(330);
                UserAnswers.AddAnswer(FreqClass.Validate(mainFrequency));                
                info.SetValue(user, FreqClass.Validate(mainFrequency));
                _dbContext.SaveChanges();
                return RedirectToAction("Question", new { Id = Id + 1 });
            }
            else if (Id == 20)
            {
                FrequencyClassificator FreqClass = new FrequencyClassificator(440);
                UserAnswers.AddAnswer(FreqClass.Validate(mainFrequency));
                info.SetValue(user, FreqClass.Validate(mainFrequency));
                _dbContext.SaveChanges();
                return RedirectToAction("YourResult");
            }
            else
            {
                return null;
            }
        }


        public IActionResult YourResult()
        {
            ViewBag.Count = UserAnswers.Answers.Count(a => a);
            ViewBag.Result = UserAnswers.CalculateResult();
            int? userId = HttpContext.Session.GetInt32("UserId");

            var user = _dbContext.Users.First(a => a.Id == userId);
            user.Result = (int)UserAnswers.CalculateResult();
            _dbContext.SaveChanges();

            var ans = Models.UserAnswers.Answers;
            return View();

        }


        [HttpPost]
        public IActionResult Sing()
        {

            var file = Request.Form.Files[0];
            var questionId = Request.Form["param"].FirstOrDefault();
            
            byte[] audioArray = _service.GetAudioArray(file);
            bool answer;
            if(Int32.Parse(questionId) == 19)
            {

                answer = _service.ProcessRecording(audioArray, 330);
            }
            else if (Int32.Parse(questionId) == 20)
            {
                answer = _service.ProcessRecording(audioArray, 440);
            }
            else
            {
                answer = false;
            }
                

            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _dbContext.Users.First(a => a.Id == userId);
            PropertyInfo info = user.GetType().GetProperty($"Answer{questionId}");
            UserAnswers.AddAnswer(answer);
            info.SetValue(user, answer);
            _dbContext.SaveChanges();




            return Json("Ok");
        }
        
    }
}