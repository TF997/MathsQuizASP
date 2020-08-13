using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MathsQuiz
{
    public class ManageState : System.Web.UI.Page
    {
        public void initaliseQuizStates(ref LastQuestion lastQuestion, ref int difficulty, ref int maxQuestions, ref int questionCounter, ref bool needRefresh, ref bool isDifficultyInitiated, ref bool ismaxQuestionsInitiated, ref int total)
        {
            loadQuiz(ref lastQuestion, ref difficulty, ref maxQuestions, ref questionCounter, ref total);
            if (lastQuestion.question != null)
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
        }

        public void loadQuiz(ref LastQuestion lastQuestion, ref int difficulty, ref int maxQuestions, ref int questionCounter, ref int total)
        {
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