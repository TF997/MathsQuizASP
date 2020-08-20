using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathsQuiz;
namespace MathsQuizUI
{
    public partial class Setup : System.Web.UI.Page
    {
        readonly Quiz quiz = new Quiz();
        readonly ManageState state = new ManageState();
        protected void Page_Load(object sender, EventArgs e)
        {
            LastSession lastSession = state.LoadQuiz();
            ReallocateValuesFromLastSession(lastSession);
            string InputString = Request.QueryString["answer"];
            string initalisingQuestion = quiz.QuizSetup(InputString);
            if (initalisingQuestion != null)
            { 
                questionText.InnerText = initalisingQuestion;
            }
            state.SaveConfig(quiz.__difficultyData.__Value, quiz.__maxQuestionData.__Value);
            if (quiz.__maxQuestionData.__IsInitiated && quiz.__difficultyData.__IsInitiated)
            {
                Response.Redirect("Default.aspx");
            }
        }

        public void ReallocateValuesFromLastSession(LastSession lastSession)
        {
            quiz.__lastQuestion = lastSession.LastSessionQuestion;
            quiz.__difficultyData.__Value = lastSession.Difficulty;
            quiz.__maxQuestionData.__Value = lastSession.MaxQuestions;
            quiz.__QuestionCounter = lastSession.QuestionCounter;
            quiz.__Total = lastSession.Total;
        }
    }
}