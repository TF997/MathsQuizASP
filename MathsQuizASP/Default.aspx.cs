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
        OutputWriter outputWriter = new OutputWriter();
        string inputString;

        protected void Page_Load(object sender, EventArgs e)
        {
            inputString = Request.QueryString["answer"];
            outputWriter.constructor(answer, questionText);
            string initalisingQuestion = quiz.quizSetup(inputString);
            if (initalisingQuestion != null)
            {
                outputWriter.writeQuestion(initalisingQuestion);
            }
            if (quiz.isDifficultyInitiated && quiz.ismaxQuestionsInitiated)
            {
                (string questionTextString, string answerTextString) = quiz.getQuestionAndAnswer(inputString);
                outputWriter.writeQuestion(questionTextString);
                outputWriter.writeAnswer(answerTextString);
            }
            quiz.checkEndOfQuizOrSave();
        }
    }
}