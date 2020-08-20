using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class QuestionData
    {
        public bool __IsInitiated { get; set; }
        public int __Value { get; set; }
        virtual public string __InitialiserQuestion { get; set; }

        public void NeedsSetting()
        {
            if (__Value > 0)
            {
                __IsInitiated = true;
            }
            else
            {
                __IsInitiated = false;
            }
        }

        public string GetData(string UserInput)
        {
            if (UserInput != null && UserInput != "")
            {
                __Value = int.Parse(UserInput);
                __IsInitiated = true;
            }
            else
            {
                return __InitialiserQuestion;
            }
            return null;
        }
    }
}