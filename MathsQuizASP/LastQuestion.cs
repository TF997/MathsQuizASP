using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class LastQuestion
    {
       public string question { get; set; } = "";
       public int firstNum { get; set; }
       public int secondNum { get; set; }
       public int thirdNum { get; set; }
       public int operatorsIndex { get; set; }
       public int operatorsIndexTwo { get; set; }
       public bool extraOperators { get; set; } = false;
    }

}

