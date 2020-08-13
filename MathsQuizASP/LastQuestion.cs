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
       public int opIndex { get; set; }
       public int opIndexTwo { get; set; }
       public bool extraOp { get; set; } = false;
    }

}

