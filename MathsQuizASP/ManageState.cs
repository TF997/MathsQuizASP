using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MathsQuiz
{
    public class ManageState : System.Web.UI.Page
    {
        public Tuple<bool, bool, bool> initaliseQuizStates(string question, int difficulty, int maxQuestions)
        {
            bool needRefresh = true;
            bool isDifficultyInitiated = false;
            bool ismaxQuestionsInitiated = false;
            if (question != null)
            {
                needRefresh = false;
            }
            if (difficulty > 0)
            {
                isDifficultyInitiated = true;
            }
            if (maxQuestions > 0)
            {
                ismaxQuestionsInitiated = true;
            }

            return new Tuple<bool, bool, bool>(needRefresh, isDifficultyInitiated, ismaxQuestionsInitiated);
        }

        public Tuple<LastQuestion, int, int, int, int> loadQuiz()
        {
            int total = 0;
            int difficulty = -1;
            int maxQuestions = -1;
            int questionCounter = 1;
            LastQuestion lastQuestion = new LastQuestion();
            if(Session["total"] != null)
            {
                total = int.Parse(Session["total"].ToString());

            }
            if (Session["difficulty"] != null)
            {
                difficulty = int.Parse(Session["difficulty"].ToString());

            }
            if (Session["maxQuestions"] != null)
            {
                maxQuestions = int.Parse(Session["maxQuestions"].ToString());

            }
            if (Session["questionCounter"] != null)
            {
                questionCounter = int.Parse(Session["questionCounter"].ToString());

            }
            if (Session["lastQuestion"] != null)
            {
                lastQuestion = (LastQuestion)Session["lastQuestion"]; 
            }

            return new Tuple<LastQuestion, int, int, int, int>(lastQuestion, difficulty, maxQuestions, questionCounter, total);
        }

        public void saveQuiz(Question question,  int difficulty,  int maxQuestions,  int questionCounter, int total)
        {
            var serializedQuestion = JsonConvert.SerializeObject(question);
            LastQuestion lastQuestionShell = JsonConvert.DeserializeObject<LastQuestion>(serializedQuestion);
            Session["total"] = total;
            Session["difficulty"] = difficulty;
            Session["maxQuestions"] = maxQuestions;
            Session["lastQuestion"] = lastQuestionShell;
            Session["questionCounter"] = questionCounter;
        }
    }
}