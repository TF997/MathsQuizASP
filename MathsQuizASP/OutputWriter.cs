using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace MathsQuizASP
{
    public class OutputWriter 
    {
        HtmlGenericControl answer, question;

        public OutputWriter(HtmlGenericControl answer, HtmlGenericControl question)
        {
            this.answer = answer;
            this.question = question;
        }

        public void writeAnswer(string Text) 
        {
            answer.InnerText = Text;
        }

        public void writeQuestion(string Text)
        {
            question.InnerText = Text;
        }
    }
}