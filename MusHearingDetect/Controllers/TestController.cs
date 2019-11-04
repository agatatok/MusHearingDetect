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
                ViewBag.AudioSrc = audiofile.Src;
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
            if(secondbtn!=null)
            {
                UserAnswers.AddAnswer(audiofile.Question.SecondAnswer.IsRight);
            }
            
            var answs = UserAnswers.Answers;
            
            if (id < 10)
            {
                return RedirectToAction("BeginTest", new { id = id + 1 });
            }
            else
            {
                return RedirectToAction("YourResult");
            }

        }
        public IActionResult AddAnswer(bool IsRight)
        {
            bool ir = IsRight;

                return RedirectToAction("YourResult");
           
        }

        public IActionResult YourResult()
        {
            //todo: view with result
            return View();
        }

    }
}