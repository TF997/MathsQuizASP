using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json; 
using MathsQuiz;

namespace MathsQuizASP
{
    
    public partial class Default : System.Web.UI.Page
    {
        Quiz quiz = new Quiz();
        string inputString;

        protected void Page_Load(object sender, EventArgs e)
        {
            quiz.outputWriter.constructor(answer, questionText);
            quiz.initaliseQuizStates();
            inputString = Request.QueryString["answer"];
            quiz.askInitialisingQuestions(inputString);
            quiz.mainLoop(inputString);
            quiz.checkEndOfQuizOrSave();
        }
    }
}