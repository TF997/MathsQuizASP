using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class QuestionData
    {
        public bool IsInitiated { get; set; }
        public int Value { get; set; }
        virtual public string InitialiserQuestion { get; set; }

        public void NeedsSetting()
        {
            if (Value > 0)
            {
                IsInitiated = true;
            }
            else
            {
                IsInitiated = false;
            }
        }

        public string GetData(string UserInput)
        {
            if (UserInput != null && UserInput != "")
            {
                Value = int.Parse(UserInput);
                IsInitiated = true;
            }
            else
            {
                return InitialiserQuestion;
            }
            return null;
        }
    }
}