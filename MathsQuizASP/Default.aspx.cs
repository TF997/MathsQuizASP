using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using MathsQuiz;

namespace MathsQuizASP
{
    
    public partial class Default : System.Web.UI.Page
    {
        Quiz quiz = new Quiz();
        FileWriter file = new FileWriter();
        int questionCounter = 0;
        bool isDifficultyIntitated = false;
        bool ismaxQuestionsInitated = false;
        bool needRefresh = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            initaliseQuizStates();
            getUninitalisedDifficultyandMaxQuestions();
            mainLoop();
            saveQuizStates();
        }

        public void mainLoop()
        {
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
            else if (questionCounter != 0)
            {
                getAnswer();
                checkAnswer();
                displayAnswer();
                questionText.InnerText = "THATS ALL THE QUESTIONS";
            }
        }

        public void saveQuizStates()
        {
            string toSave = JsonSerializer.Serialize(quiz.question);
            File.WriteAllText(@"C:\TEMP\quiz.json", toSave);
        }


        int userAnswer = 0;
        int questionResult;


        public void initaliseQuizStates()
        {
            string toload = File.ReadAllText(@"C:\TEMP\quiz.json");
            quiz.lastQuestion = JsonSerializer.Deserialize<LastQuestion>(toload);
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