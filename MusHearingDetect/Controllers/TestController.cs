﻿using System;
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

namespace MusHearingDetect.Controllers
{
    public class TestController : Controller
    {
         
        private readonly IHostingEnvironment env;
        private UserContext _dbContext; 

        public TestController(IHostingEnvironment env, UserContext userContext)
        {
            this.env = env;
            _dbContext = userContext;
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
                return RedirectToAction("BeginTest", new { Id = 1 });

            }
            return View(user);
        }


        [HttpGet]
        public IActionResult BeginTest(int? id)
        {
            //int? questionId = HttpContext.Session.GetInt32("questionId");
            if (id != null)
            {
                //if (id!=questionId)
                //{
                //    return RedirectToAction("BeginTest", new { Id= questionId });
                //}

                var audiofile = AudioRepo.Audiofiles[(int)id - 1];
                ViewBag.Id = id;
                ViewBag.AudioSrc = audiofile.Src;
                ViewBag.Number = $"{id}/{AudioRepo.Audiofiles.Count}";
                //HttpContext.Session.SetInt32("questionId", (int)++questionId);
                if (id==19 || id==20)
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
            int? userId = HttpContext.Session.GetInt32("UserId");
            int id = int.Parse(this.RouteData.Values["id"].ToString());
            var audiofile = AudioRepo.Audiofiles[id - 1];

            var user = _dbContext.Users.First(a => a.Id == userId);
            PropertyInfo info = user.GetType().GetProperty($"Answer{id}");
            
            if (firstbtn!=null)
            {
                UserAnswers.AddAnswer(audiofile.Question.FirstAnswer.IsRight);
                info.SetValue(user, audiofile.Question.FirstAnswer.IsRight);
                _dbContext.SaveChanges();

            }
            if (secondbtn!=null)
            {
                UserAnswers.AddAnswer(audiofile.Question.SecondAnswer.IsRight);
                info.SetValue(user, audiofile.Question.SecondAnswer.IsRight);
                _dbContext.SaveChanges();
            }
            //var answs = UserAnswers.Answers;
            
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
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = _dbContext.Users.First(a => a.Id == userId);
            PropertyInfo info = user.GetType().GetProperty($"Answer{Id}");
            StreamWriter sw = new StreamWriter("log.txt");
            var waveResampler = new Resampler($@"C:\Users\agata\Downloads\recording{Id}.wav");
            Sound freqencyDetector = new Sound();
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
                var answs = Models.UserAnswers.Answers;
                info.SetValue(user, FreqClass.Validate(mainFrequency));
                _dbContext.SaveChanges();
                return RedirectToAction("BeginTest", new { Id = Id + 1 });
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
            byte[] filedata = null;
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                filedata = target.ToArray();
              
            }

            return View();
        }

    }
}