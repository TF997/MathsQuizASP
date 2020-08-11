using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathsQuiz;

namespace MathsQuizASP
{
    
    public partial class Default : System.Web.UI.Page
    {
        Quiz quiz = new Quiz();
        int questionCounter = 0;
        bool isDifficultyIntitated = false;
        bool ismaxQuestionsInitated = false;
        bool needRefresh = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            initaliseQuizStates();
            getUninitalisedDifficultyandMaxQuestions();
            if (questionCounter < quiz.maxQuestions)
            {
                askQuestion();
                if (!needRefresh)
                {
                    getAnswer();
                    checkAnswer();
                    displayAnswer();
                }
                questionCounter++;
            }
            else if(questionCounter != 0)
            {
                getAnswer();
                checkAnswer();
                displayAnswer();
                questionText.InnerText = "THATS ALL THE QUESTIONS";
            }

            saveQuizStates();
        }

        public void saveQuizStates()
        {
            ViewState["question"] = quiz.question.question;
            ViewState["firstNum"] = quiz.question.firstNum;
            ViewState["secondNum"] = quiz.question.secondNum;
            ViewState["opIndex"] = quiz.question.opIndex;
            ViewState["opIndexTwo"] = quiz.question.opIndexTwo;
            ViewState["extraOp"] = quiz.question.extraOp;

            if (quiz.difficulty != 0)
            {
                ViewState["difficulty"] = quiz.difficulty;
            }
            if (quiz.maxQuestions != -1)
            {
                ViewState["maxQuestions"] = quiz.maxQuestions;
                ViewState["questionCounter"] = questionCounter;
            }
        }


        int userAnswer = 0;
        int questionResult;


        public void initaliseQuizStates()
        {
            if (ViewState["question"] != null)
            {
                quiz.lastQuestion.question = (string)ViewState["question"];
            }
            if (ViewState["firstNum"] != null)
            {
                quiz.lastQuestion.firstNum = (int)ViewState["firstNum"];
            }
            if (ViewState["secondNum"] != null)
            {
                quiz.lastQuestion.secondNum = (int)ViewState["secondNum"];
            }
            if (ViewState["opIndex"] != null)
            {
                quiz.lastQuestion.opIndex = (int)ViewState["opIndex"];
            }
            if (ViewState["opIndexTwo"] != null)
            {
                quiz.lastQuestion.opIndexTwo = (int)ViewState["opIndexTwo"];
            }
            if (ViewState["extraOp"] != null)
            {
                quiz.lastQuestion.extraOp = (bool)ViewState["extraOp"];
            }
            if (ViewState["difficulty"] != null)
            {
                quiz.difficulty = (int)ViewState["difficulty"];
                isDifficultyIntitated = true;
            }
            if (ViewState["maxQuestions"] != null)
            {
                quiz.maxQuestions = (int)ViewState["maxQuestions"];
                ismaxQuestionsInitated = true;
            }
            if (ViewState["questionCounter"] != null)
            {
                questionCounter = (int)ViewState["questionCounter"];
            }
            if (ViewState["question"] != null)
            {
                needRefresh = false;
            }
        }

        public void getUninitalisedDifficultyandMaxQuestions()
        {
            string inputString = Request.QueryString["answer"];

            if (!isDifficultyIntitated)
            {
                getDifficulty(inputString);

            }
            if (!ismaxQuestionsInitated && isDifficultyIntitated)
            {
                getMaxQuestions(inputString);
            }
        }

        public void getMaxQuestions(string inputString)
        {
            if (!ismaxQuestionsInitated && inputString != null)
            {
                quiz.maxQuestions = int.Parse(inputString);
                System.Diagnostics.Debug.WriteLine("quiz.maxQuestions");
            }
        }

        public void getDifficulty(string inputString)
        {

            if (!isDifficultyIntitated && inputString != null)
            {
                quiz.difficulty = int.Parse(inputString);
                System.Diagnostics.Debug.WriteLine("difficulty");
                questionText.InnerText = "How many questions?";
                System.Diagnostics.Debug.WriteLine("quiz.maxQuestions InnerText");
            }
            else if (!isDifficultyIntitated)
            {
                questionText.InnerText = "Difficulty?";
                System.Diagnostics.Debug.WriteLine("difficulty InnerText");
            }
        }

        public void getAnswer()
        {
            string userAnswerString = Request.QueryString["answer"];
            userAnswer = int.Parse(userAnswerString);
        }

        public void askQuestion()
        {
            questionText.InnerText = quiz.askQuestion();
        }

        public void checkAnswer()
        {
            questionResult = quiz.getResult(userAnswer);
        }

        public void displayAnswer()
        {
            if (questionResult == 1)
            {
                answer.InnerText = "CORRECT!";
            }
            else if (questionResult == 0)
            {
                answer.InnerText = "INCORRECT!";
            }
        }

    }
}