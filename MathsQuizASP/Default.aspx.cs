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
        public int BarProgress;
        string InputString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["questionCounter"] != null)
            {
                BarProgress = int.Parse(Session["questionCounter"].ToString());
            }
            outputWriter = new OutputWriter(answer, questionText);
            LastSession lastSession = state.LoadQuiz();
            InputString = Request.QueryString["answer"];
            ReallocateValuesFromLastSession(lastSession);
            quiz.CheckSetupIsCompleted();

            if (!quiz.difficultyData.IsInitiated || !quiz.maxQuestionData.IsInitiated)
            {
                Response.Redirect("Setup.aspx");
            }

            quiz.CheckThisIsTheFirstQuestion();
            quizOutput = quiz.GetQuestionAndSubmitLastAnswer(InputString);
            outputWriter.WriteQuestion(quizOutput.QuestionTextString);
            outputWriter.WriteAnswer(quizOutput.AnswerTextString);

            quiz.CheckEndOfQuiz();
            state.SaveQuiz(quiz.lastQuestion, quiz.difficultyData.Value, quiz.maxQuestionData.Value, quiz.QuestionCounter, quiz.Total);
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