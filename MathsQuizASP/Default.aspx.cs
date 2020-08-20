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

            if (!quiz.difficultyData.IsInitiated || !quiz.maxQuestionData.IsInitiated)
            {
                Response.Redirect("Setup.aspx");
            }

            quizOutput = quiz.GetQuestionAndSubmitLastAnswer(InputString);
            DisplayQuestionAndAnswer();
            SetHiddenPageText();
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
        
        public void DisplayQuestionAndAnswer()
        {
            outputWriter.WriteQuestion(quizOutput.QuestionTextString);
            outputWriter.WriteAnswer(quizOutput.AnswerTextString);
        }

        public void SetHiddenPageText()
        {
            counter.InnerText = quiz.QuestionCounter.ToString();
            total.InnerText = quiz.maxQuestionData.Value.ToString();
        }
    }
}