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
        FileWriter file = new FileWriter();
        int questionCounter = 1;
        bool isDifficultyIntitated = false;
        bool ismaxQuestionsInitated = false;
        bool needRefresh = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            initaliseQuizStates();
            getUninitalisedDifficultyandMaxQuestions();
            mainLoop();
            if(questionCounter == quiz.maxQuestions && questionCounter != 1)
            {
                deleteFiles();
                questionCounter = 1;
                isDifficultyIntitated = false;
                ismaxQuestionsInitated = false;
                needRefresh = true;
            }
            else
            {
                saveQuizStates();
            }
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
                    questionCounter++;
                }
            }
            else if (questionCounter != 1)
            {
                getAnswer();
                checkAnswer();
                displayAnswer();
                questionText.InnerText = "Quiz Completed!";
            }
        }

        public void deleteFiles()
        {
            File.Delete(@"C:\TEMP\LastQuestion.json");
            File.Delete(@"C:\TEMP\difficulty.json");
            File.Delete(@"C:\TEMP\maxQuestions.json");
            File.Delete(@"C:\TEMP\questionCounter.json");
        }

        public void saveQuizStates()
        {
            string toSave = JsonConvert.SerializeObject(quiz.question);
            File.WriteAllText(@"C:\TEMP\LastQuestion.json", toSave);
            toSave = JsonConvert.SerializeObject(quiz.difficulty);
            File.WriteAllText(@"C:\TEMP\difficulty.json", toSave);
            toSave = JsonConvert.SerializeObject(quiz.maxQuestions);
            File.WriteAllText(@"C:\TEMP\maxQuestions.json", toSave);
            toSave = JsonConvert.SerializeObject(questionCounter);
            File.WriteAllText(@"C:\TEMP\questionCounter.json", toSave);
        }


        int userAnswer = 0;
        int questionResult;


        public void initaliseQuizStates()
        {
            string toload;
            if (File.Exists(@"C:\TEMP\LastQuestion.json"))
            {
                toload = File.ReadAllText(@"C:\TEMP\LastQuestion.json");
                quiz.lastQuestion = JsonConvert.DeserializeObject<LastQuestion>(toload);
            }
            if (File.Exists(@"C:\TEMP\difficulty.json"))
            {
                toload = File.ReadAllText(@"C:\TEMP\difficulty.json");
                quiz.difficulty = JsonConvert.DeserializeObject<int>(toload);
            }
            if (File.Exists(@"C:\TEMP\maxQuestions.json"))
            {
                toload = File.ReadAllText(@"C:\TEMP\maxQuestions.json");
                quiz.maxQuestions = JsonConvert.DeserializeObject<int>(toload);
            }
            if (File.Exists(@"C:\TEMP\questionCounter.json"))
            {
                toload = File.ReadAllText(@"C:\TEMP\questionCounter.json");
                questionCounter = JsonConvert.DeserializeObject<int>(toload);
            }
            if (quiz.lastQuestion.question != null)
            {
                needRefresh = false;
            }
            if(quiz.difficulty > 0)
            {
                isDifficultyIntitated = true;
            }
            if (quiz.maxQuestions > 0)
            {
                ismaxQuestionsInitated = true;
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