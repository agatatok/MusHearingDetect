using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.PatternSegments;
using MusHearingDetect.Models;

namespace MusHearingDetect.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BeginTest(int? id)
        {
            if (id == 1 || id == 2 || id == 3)
            {
                Question question1 = new Question
                {
                    Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany trójdźwięk brzmi wesoło, czy smutno.",
                    Title = "Wesoły czy smutny?",
                    Audio = new Audiofile(2)

                };

                return View(question1);
            }

            else if (id == 4 || id == 5 || id == 6)
            {
                Question question2 = new Question
                {
                    Description = "Posłuchaj nagrania, a następnie określ, czy usłyszana melodia prowadzi w górę czy w dół.",
                    Title = "W górę czy w dół?"
                };
                return View(question2);
            }
            else
            {
                Question question3 = new Question
                {
                    Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany dźwięk jest wysoki (cienki), czy niski (gruby).",
                    Title = "Wysoki czy niski?"
                };
                return View(question3);
            }
        }


        [HttpPost]
        public IActionResult BeginTest(Answer answer)
        {
            string url = HttpContext.Request.Path;
            int idn = int.Parse(url.Remove(0, url.LastIndexOf('/') + 1));
            return RedirectToAction("BeginTest", new {id = idn+1});
        }
    }
}