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
            state.SaveConfig(quiz.difficultyData.Value, quiz.maxQuestionData.Value);
            if (quiz.maxQuestionData.IsInitiated && quiz.difficultyData.IsInitiated)
            {
                Response.Redirect("Default.aspx");
            }
        }

        public void ReallocateValuesFromLastSession(LastSession lastSession)
        {
            quiz.lastQuestion = lastSession.LastSessionQuestion;
            quiz.difficultyData.Value = lastSession.Difficulty;
            quiz.maxQuestionData.Value = lastSession.MaxQuestions;
            quiz.QuestionCounter = lastSession.QuestionCounter;
            quiz.Total = lastSession.Total;
        }
    }
}