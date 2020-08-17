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
        public bool DoesPageNeedRefresh;
        protected void Page_Load(object sender, EventArgs e)
        {
            InputString = Request.QueryString["answer"];
            outputWriter = new OutputWriter(answer, questionText);
            LastSession lastSession = state.LoadQuiz();
            ReallocateValuesFromLastSession(lastSession);
            string initalisingQuestion = quiz.QuizSetup(InputString);
            DoesPageNeedRefresh = state.DoesPageNeedRefresh(quiz.lastQuestion.QuestionToAsk);
            if (initalisingQuestion != null)
            {
                outputWriter.WriteQuestion(initalisingQuestion);
            }
            if (quiz.difficultyData.IsInitiated && quiz.maxQuestionData.IsInitiated)
            {
                quizOutput = quiz.GetQuestionAndSubmitLastAnswer(InputString, DoesPageNeedRefresh);
                outputWriter.WriteQuestion(quizOutput.QuestionTextString);
                outputWriter.WriteAnswer(quizOutput.AnswerTextString);
            }
            quiz.CheckEndOfQuiz();
            state.SaveQuiz(quiz.question, quiz.difficultyData.Value, quiz.maxQuestionData.Value, quiz.QuestionCounter, quiz.Total);
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