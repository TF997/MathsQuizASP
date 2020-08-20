using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class LastQuestion : IQuestion
    {
       public string __QuestionToAsk { get; set; }
       public int __FirstNum { get; set; }
       public int __SecondNum { get; set; }
       public int __ThirdNum { get; set; }
       public int __OperatorsIndexOne { get; set; }
       public int __OperatorsIndexTwo { get; set; }
       public bool __ExtraOperators { get; set; } = false;
    }
}

