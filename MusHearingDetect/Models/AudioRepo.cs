using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MusHearingDetect.Models
{
    public static class AudioRepo
    {
        //question patterns
        public static Audiofile durmoll = new Audiofile()
        {
            Question = new Question()
            {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany trójdźwięk brzmi wesoło, czy smutno.",
                Title = "Wesoły czy smutny?",
                FirstAnswer = new Answer("Wesoły"),
                SecondAnswer = new Answer("Smutny")
            },
        };
        public static Audiofile updown = new Audiofile()
        {
            Question = new Question()
            {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszana melodia prowadzi w górę czy w dół.",
                Title = "W górę czy w dół?",
                FirstAnswer = new Answer("W górę"),
                SecondAnswer = new Answer("W dół")
            },
        };
        public static Audiofile highlow = new Audiofile()
        {
            Question = new Question()
            {
                Description = "Posłuchaj nagrania, a następnie określ, czy usłyszany dźwięk jest niski (gruby) czy wysoki (cienki).",
                Title = "Niski czy wysoki?",
                FirstAnswer = new Answer("Niski"),
                SecondAnswer = new Answer("Wysoki")
            },
        };
        public static Audiofile soundsnum = new Audiofile()
        {
            Question = new Question()
            {
                Description = "Posłuchaj nagrania, a następnie określ ile dźwięków na raz usłyszałeś.",
                Title = "Ile słyszysz dźwięków?",
                FirstAnswer = new Answer("Dwa"),
                SecondAnswer = new Answer("Więcej niż dwa")
            },
        };
        public static Audiofile samemelody = new Audiofile()
        {
            Question = new Question()
            {
                Description = "Posłuchaj nagrań, a następnie określ czy wysłuchane melodie są jednakowe, czy różnią się od siebie.",
                Title = "Jednakowe czy różne?",
                FirstAnswer = new Answer("Jednakowe"),
                SecondAnswer = new Answer("Różne")
            },
        };
        public static Audiofile higher = new Audiofile()
        {
            Question = new Question()
            {
                Description = "Posłuchaj nagrania, a następnie określ, który dźwięk był wyższy (cienszy).",
                Title = "Który wyższy?",
                FirstAnswer = new Answer("Pierwszy"),
                SecondAnswer = new Answer("Drugi")
            },
        };
        public static Audiofile sing = new Audiofile()
        {
            Question = new Question()
            {
                Description = "Posłuchaj nagrania, a następnie przyciśnij przycisk nagrywania i zaśpiewaj wysłuchany dźwięk.",
                Title = "Powtórz dźwięk"
            },
        };


        //list of test questions
        public static List<Audiofile> audiofiles = new List<Audiofile>()
        {
            new Audiofile(durmoll, 1)
            {
                
            },
            new Audiofile(durmoll, 2)
            {

            },
            new Audiofile(durmoll, 3)
            {

            },
            new Audiofile(durmoll, 4)
            {

            },
            new Audiofile(durmoll, 5)
            {

            },
            new Audiofile(highlow, 6)
            {

            },
            new Audiofile(highlow, 7)
            {

            },
            new Audiofile(highlow, 8)
            {

            },
        
        };

        //public static IEnumerable<Audiofile> Audiofiles
        //{
        //    get { return audiofiles; }
        //}

    }
}
