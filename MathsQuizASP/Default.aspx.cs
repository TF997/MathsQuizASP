using System;
using MathsQuiz;

namespace MathsQuizUI
{

    public partial class Default : System.Web.UI.Page
    {
        readonly Quiz quiz = new Quiz();
        QuizOutput quizOutput = new QuizOutput();
        private readonly ManageState state = new ManageState();
        OutputWriter outputWriter;
        string InputString;

        protected void Page_Load(object sender, EventArgs e)
        {
            outputWriter = new OutputWriter(answer, questionText);
            LastSession lastSession = state.LoadQuiz();
            InputString = Request.QueryString["answer"];
            ReallocateValuesFromLastSession(lastSession);
            quiz.CheckSetupIsCompleted();

            if (!quiz.__difficultyData.__IsInitiated || !quiz.__maxQuestionData.__IsInitiated)
            {
                Response.Redirect("Setup.aspx");
            }
            UpdateProgressBar();
            quizOutput = quiz.GetQuestionAndSubmitLastAnswer(InputString);
            DisplayQuestionAndAnswer();
            quiz.CheckEndOfQuiz();

            state.SaveQuiz(quiz.__lastQuestion, quiz.__difficultyData.__Value, quiz.__maxQuestionData.__Value, quiz.__QuestionCounter, quiz.__Total);
        }

        public void ReallocateValuesFromLastSession(LastSession lastSession)
        {
            quiz.__lastQuestion = lastSession.LastSessionQuestion;
            quiz.__difficultyData.__Value = lastSession.Difficulty;
            quiz.__maxQuestionData.__Value = lastSession.MaxQuestions;
            quiz.__QuestionCounter = lastSession.QuestionCounter;
            quiz.__Total = lastSession.Total;
        }
        
        public void DisplayQuestionAndAnswer()
        {
            outputWriter.WriteQuestion(quizOutput.__QuestionTextString);
            outputWriter.WriteAnswer(quizOutput.__AnswerTextString);
        }

        public void UpdateProgressBar()
        {
            float barProgress = quiz.__QuestionCounter;
            float barTotal = quiz.__maxQuestionData.__Value;
            float width = (barProgress / barTotal) * 100;
            if (width >= 100)
            {
                width = 100;
                timer.Visible = false;
            }
            string WidthCSS = width.ToString() + "%";
            InnerBar.Attributes.CssStyle.Add("width", WidthCSS);
        }
    }
}