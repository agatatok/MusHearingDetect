using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.PatternSegments;
using MusHearingDetect.Models;
using System.IO;
using MusHearingDetect.Models.SoundEvaluation;
using NAudio.Wave;

namespace MusHearingDetect.Controllers
{
    public class TestController : Controller
    {
         
        private readonly IHostingEnvironment env;
        public TestController(IHostingEnvironment env)
        {
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BeginTest(int? id)
        {
            if (id != null)
            {
                var audiofile = AudioRepo.Audiofiles[(int)id - 1];
                ViewBag.Id = id;
                ViewBag.AudioSrc = audiofile.Src;
                ViewBag.Number = $"{id}/{AudioRepo.Audiofiles.Count}";
                if(id==19 || id==20)
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
        public IActionResult BeginTest(string firstbtn, string secondbtn)
        {
            int id = int.Parse(this.RouteData.Values["id"].ToString());
            var audiofile = AudioRepo.Audiofiles[id - 1];
            if (firstbtn!=null)
            {
                UserAnswers.AddAnswer(audiofile.Question.FirstAnswer.IsRight);
            }
            if (secondbtn!=null)
            {
                UserAnswers.AddAnswer(audiofile.Question.SecondAnswer.IsRight);
            }
            
            var answs = UserAnswers.Answers;
            
            
            if (id < 21)
            {
                return RedirectToAction("BeginTest", new { Id = id + 1 });
            }
            else
            {
                return RedirectToAction("YourResult");
            }

        }


        [HttpPost]
        public IActionResult SingQuestion(int Id, string Src)
        {

            
            StreamWriter sw = new StreamWriter("log.txt");

            var waveResampler = new Resampler();
            Models.VoiceRecognition.Sound freqencyDetector = new Models.VoiceRecognition.Sound();
            List<float> result = freqencyDetector.DetectFrequency(waveResampler);

            float mainFrequency = FrequencyFilter.CalculateMainFreq(result);
            sw.WriteLine($"MEAN: {mainFrequency.ToString()}");
            



            for (int i = 0; i < result.Count; i++)
            {
                sw.Write("Frequ " + result[i] + "\r\n");
            }
                

            sw.Flush();
            sw.Close();

            if (Id == 19)
            {
                FrequencyClassificator FreqClass = new FrequencyClassificator(330);
                UserAnswers.AddAnswer(FreqClass.Validate(mainFrequency));
                var answs = UserAnswers.Answers;
                return RedirectToAction("BeginTest", new { Id = Id + 1 });
            }
            else if (Id == 20)
            {
                FrequencyClassificator FreqClass = new FrequencyClassificator(440);
                UserAnswers.AddAnswer(FreqClass.Validate(mainFrequency));
                return RedirectToAction("YourResult");
            }
            else
            {
                return null;
            }
        }


        
        public IActionResult YourResult()
        {
            ViewBag.Result = UserAnswers.CalculateResult();
            return View();
            
        }

        public IActionResult Sing()
        {
            return View();
        }

    }
}