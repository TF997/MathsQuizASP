using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace MathsQuizUI
{
    public class OutputWriter 
    {
        private readonly HtmlGenericControl answer;
        private readonly HtmlGenericControl question;

        public OutputWriter(HtmlGenericControl answer, HtmlGenericControl question)
        {
            this.answer = answer;
            this.question = question;
        }

        public void WriteAnswer(string Text) 
        {
            answer.InnerText = Text;
        }

        public void WriteQuestion(string Text)
        {
            question.InnerText = Text;
        }
    }
}