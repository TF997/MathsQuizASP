using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class LastSession
    {
        public LastQuestion lastQuestion { get; set; } = new LastQuestion(); 
        public int difficulty { get; set; }
        public int maxQuestions { get; set; }
        public int questionCounter { get; set; } = 1; 
        public int total { get; set; }
    }
}