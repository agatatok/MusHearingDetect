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
                var question = AudioRepo.audiofiles[(int)id - 1];
                ViewBag.AudioSrc = question.Src;
                return View(question);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    


        [HttpPost]
        public IActionResult BeginTest(Question question)
        {
            Question quest = question;
            if (quest.FirstAnswer!=null)
            {
                UserAnswers.AddAnswer(quest.FirstAnswer);
            }
            else
            {
                UserAnswers.AddAnswer(quest.SecondAnswer);
            }

            var answs = UserAnswers.Answers;

            int id = int.Parse(this.RouteData.Values["id"].ToString());
            if (id < 15)
            {
                return RedirectToAction("BeginTest", new {id = id+1});
            }
            else
            {
                return RedirectToAction("Result");
            }
            
        }


        public IActionResult YourResult()
        {
            return View();
        }

    }
}