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
        OutputWriter outputWriter;
        string inputString;

        protected void Page_Load(object sender, EventArgs e)
        {
            inputString = Request.QueryString["answer"];
            outputWriter = new OutputWriter(answer, questionText);
            string initalisingQuestion = quiz.quizSetup(inputString);
            if (initalisingQuestion != null)
            {
                outputWriter.writeQuestion(initalisingQuestion);
            }
            if (quiz.difficultyData.isDifficultyInitiated && quiz.maxQuestionData.isMaxQuestionsInitiated)
            {
                (string questionTextString, string answerTextString) = quiz.getQuestionAndSubmitAnswer(inputString);
                outputWriter.writeQuestion(questionTextString);
                outputWriter.writeAnswer(answerTextString);
            }
            quiz.checkEndOfQuizOrSave();
        }
    }
}