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
        int maxQuestions = -1;
        bool isDifficultyIntitated = false;
        bool ismaxQuestionsInitated = false;
        bool needRefresh = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["difficulty"] != null)
            {
                quiz.difficulty = (int)ViewState["difficulty"];
                isDifficultyIntitated = true;
            }
            if (ViewState["maxQuestions"] != null)
            {
                System.Diagnostics.Debug.WriteLine(ViewState["maxQuestions"]);
                maxQuestions = (int)ViewState["maxQuestions"];
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

            string inputString = Request.QueryString["answer"];

            if (!isDifficultyIntitated)
            {
                getDifficulty(inputString);
                
            }
            if (!ismaxQuestionsInitated && isDifficultyIntitated)
            {
                getMaxQuestions(inputString);
            }


            if (questionCounter < maxQuestions)
            {
                askQuestion();
                questionCounter++;
            }
            else if(questionCounter != 0)
            {
                questionText.InnerText = "THATS ALL THE QUESTIONS";
            }


            if (quiz.difficulty != 0)
            {
                ViewState["difficulty"] = quiz.difficulty;
            }
            if (maxQuestions != -1)
            {
                ViewState["maxQuestions"] = maxQuestions;
                ViewState["questionCounter"] = questionCounter;
            }
            System.Diagnostics.Debug.WriteLine("##END##");
        }

        public void getMaxQuestions(string inputString)
        {
            if (!ismaxQuestionsInitated && inputString != null)
            {
                maxQuestions = int.Parse(inputString);
                System.Diagnostics.Debug.WriteLine("maxQuestions");
            }
        }

        public void getDifficulty(string inputString)
        {

            if (!isDifficultyIntitated && inputString != null)
            {
                quiz.difficulty = int.Parse(inputString);
                System.Diagnostics.Debug.WriteLine("difficulty");
                questionText.InnerText = "How many questions?";
                System.Diagnostics.Debug.WriteLine("maxQuestions InnerText");
            }
            else if (!isDifficultyIntitated)
            {
                questionText.InnerText = "Difficulty?";
                System.Diagnostics.Debug.WriteLine("difficulty InnerText");
            }
        }

        int userAnswer = 0;
        int result = 2;
        string LastQuestion = "";
        int firstNum = -1;
        int secondNum = -1;
        int opIndex = -1;
        int opIndexTwo = -1;
        bool extraOp = false;

        public void askQuestion()
        {
            string userAnswerString = Request.QueryString["answer"];
            questionText.InnerText = quiz.askQuestion();

            LoadState();

            if (userAnswerString != null && !needRefresh)
            {
                userAnswer = int.Parse(userAnswerString);
                result = quiz.getResult(LastQuestion, firstNum, secondNum, opIndex, opIndexTwo, extraOp, userAnswer);
            }

            saveState();

            if (result == 1)
            {
                answer.InnerText = "CORRECT!";
            }
            else if(result == 0)
            {
                answer.InnerText = "INCORRECT!";
            }
            else
            {
                answer.InnerText = "Input Your Answer";
            }
        }

        public void saveState()
        {
            ViewState["question"] = quiz.question.question;
            ViewState["firstNum"] = quiz.question.firstNum;
            ViewState["secondNum"] = quiz.question.secondNum;
            ViewState["opIndex"] = quiz.question.opIndex;
            ViewState["opIndexTwo"] = quiz.question.opIndexTwo;
            ViewState["extraOp"] = quiz.question.extraOp;
        }

        public void LoadState()
        {
            if (ViewState["question"] != null)
            {
                LastQuestion = (string)ViewState["question"];
            }
            if (ViewState["firstNum"] != null)
            {
                firstNum = (int)ViewState["firstNum"];
            }
            if (ViewState["secondNum"] != null)
            {
                secondNum = (int)ViewState["secondNum"];
            }
            if (ViewState["opIndex"] != null)
            {
                opIndex = (int)ViewState["opIndex"];
            }
            if (ViewState["opIndexTwo"] != null)
            {
                opIndexTwo = (int)ViewState["opIndexTwo"];
            }
            if (ViewState["extraOp"] != null)
            {
                extraOp = (bool)ViewState["extraOp"];
            }
        }
    }
}