using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MusHearingDetect.Models
{
    public static class AudioRepo
    {

        public static IList<Audiofile> Audiofiles = new List<Audiofile>()
        {
            new Audiofile(1)
            {
                Question = new Question()
                {
                    Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany trójdźwięk brzmi wesoło, czy smutno.",
                    Title = "Wesoły czy smutny?",
                    FirstAnswer = new Answer("Wesoły", true),
                    SecondAnswer = new Answer("Smutny", false)
                }
            },
            new Audiofile(2)
            {
                Question = new Question()
                {
                    Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany trójdźwięk brzmi wesoło, czy smutno.",
                    Title = "Wesoły czy smutny?",
                    FirstAnswer = new Answer("Wesoły", true),
                    SecondAnswer = new Answer("Smutny", false)
                }
            },
            new Audiofile(3)
            {
                Question = new Question()
                {
                    Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany trójdźwięk brzmi wesoło, czy smutno.",
                    Title = "Wesoły czy smutny?",
                    FirstAnswer = new Answer("Wesoły", false),
                    SecondAnswer = new Answer("Smutny", true)
                }
            },
            new Audiofile(4)
            {
                Question = new Question()
                {
                    Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany trójdźwięk brzmi wesoło, czy smutno.",
                    Title = "Wesoły czy smutny?",
                    FirstAnswer = new Answer("Wesoły", false),
                    SecondAnswer = new Answer("Smutny", true)
                }
            },
            new Audiofile(5)
            {
                Question = new Question()
                {
                    Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany trójdźwięk brzmi wesoło, czy smutno.",
                    Title = "Wesoły czy smutny?",
                    FirstAnswer = new Answer("Wesoły", true),
                    SecondAnswer = new Answer("Smutny", false)
                }
            },
            new Audiofile(6)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszana melodia prowadzi w górę czy w dół.",
                Title = "W górę czy w dół?",
                FirstAnswer = new Answer("W górę", false),
                SecondAnswer = new Answer("W dół", true)
                }
            },
            new Audiofile(7)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszana melodia prowadzi w górę czy w dół.",
                Title = "W górę czy w dół?",
                FirstAnswer = new Answer("W górę", true),
                SecondAnswer = new Answer("W dół", false)
                }
            },
            new Audiofile(8)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszana melodia prowadzi w górę czy w dół.",
                Title = "W górę czy w dół?",
                FirstAnswer = new Answer("W górę", true),
                SecondAnswer = new Answer("W dół", false)
                }
            },
            new Audiofile(9)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszana melodia prowadzi w górę czy w dół.",
                Title = "W górę czy w dół?",
                FirstAnswer = new Answer("W górę", false),
                SecondAnswer = new Answer("W dół", true)
                }
            },
            new Audiofile(10)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany dźwięk jest niski (gruby) czy wysoki (cienki).",
                Title = "Niski czy wysoki?",
                FirstAnswer = new Answer("Niski", true),
                SecondAnswer = new Answer("Wysoki", false)
                }
            },
            new Audiofile(11)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany dźwięk jest niski (gruby) czy wysoki (cienki).",
                Title = "Niski czy wysoki?",
                FirstAnswer = new Answer("Niski", false),
                SecondAnswer = new Answer("Wysoki", true)
                }
            },
            new Audiofile(12)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany dźwięk jest niski (gruby) czy wysoki (cienki).",
                Title = "Niski czy wysoki?",
                FirstAnswer = new Answer("Niski", true),
                SecondAnswer = new Answer("Wysoki", false)
                }
            },
            new Audiofile(13)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany dźwięk jest niski (gruby) czy wysoki (cienki).",
                Title = "Niski czy wysoki?",
                FirstAnswer = new Answer("Niski", false),
                SecondAnswer = new Answer("Wysoki", true)
                }
            },
            new Audiofile(14)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ ile dźwięków na raz usłyszałeś.",
                Title = "Ile słyszysz dźwięków?",
                FirstAnswer = new Answer("Dwa", true),
                SecondAnswer = new Answer("Więcej niż dwa" ,false)
                }
            },
            new Audiofile(15)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ ile dźwięków na raz usłyszałeś.",
                Title = "Ile słyszysz dźwięków?",
                FirstAnswer = new Answer("Dwa", false),
                SecondAnswer = new Answer("Więcej niż dwa" ,true)
                }
            },
            new Audiofile(16)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ ile dźwięków na raz usłyszałeś.",
                Title = "Ile słyszysz dźwięków?",
                FirstAnswer = new Answer("Dwa", false),
                SecondAnswer = new Answer("Więcej niż dwa" ,true)
                }
            },
            new Audiofile(17)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ ile dźwięków na raz usłyszałeś.",
                Title = "Ile słyszysz dźwięków?",
                FirstAnswer = new Answer("Dwa", true),
                SecondAnswer = new Answer("Więcej niż dwa" ,false)
                }
            },
            new Audiofile(18)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie określ ile dźwięków na raz usłyszałeś.",
                Title = "Ile słyszysz dźwięków?",
                FirstAnswer = new Answer("Dwa", true),
                SecondAnswer = new Answer("Więcej niż dwa" ,false)
                }
            },
            new Audiofile(19)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie przyciśnij przycisk nagrywania i zaśpiewaj wysłuchany dźwięk.",
                Title = "Powtórz dźwięk"
                }
            },
            new Audiofile(20)
            {
                Question = new Question()
                {
                Description = "Posłuchaj nagrania, a następnie przyciśnij przycisk nagrywania i zaśpiewaj wysłuchany dźwięk.",
                Title = "Powtórz dźwięk"
                }
            },
        };

        //public static IEnumerable<Audiofile> Audiofiles
        //{
        //    get { return audiofiles; }
        //}

    }
}
