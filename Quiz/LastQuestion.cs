using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class LastQuestion //  Add interface, make names consistant
    {
       public string QuestionToAsk { get; set; }
       public int FirstNum { get; set; }
       public int SecondNum { get; set; }
       public int ThirdNum { get; set; }
       public int OperatorsIndexOne { get; set; }
       public int OperatorsIndexTwo { get; set; }
       public bool ExtraOperators { get; set; } = false;
    }
}

