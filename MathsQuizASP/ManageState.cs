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
            Session["lastQuestion"] = lastQuestionShell;
            Session["difficulty"] = difficulty;
            Session["maxQuestions"] = maxQuestions;
            Session["questionCounter"] = questionCounter;
        }

        public string getUninitialisedDifficultyandMaxQuestions(ref string inputString, ref bool isDifficultyInitiated, ref bool ismaxQuestionsInitiated, ref int difficulty, ref int maxQuestions)
        {
            string InitialisingQuestion = null;
            if (!isDifficultyInitiated)
            {
                InitialisingQuestion = getDifficulty(ref inputString, ref isDifficultyInitiated, ref difficulty);
                if (InitialisingQuestion != null)
                {
                    return InitialisingQuestion;
                }

            }
            if (!ismaxQuestionsInitiated && isDifficultyInitiated)
            {
                InitialisingQuestion = getMaxQuestions(ref inputString, ref ismaxQuestionsInitiated, ref maxQuestions, isDifficultyInitiated);
                if (InitialisingQuestion != null)
                {
                    return InitialisingQuestion;
                }
            }
            return InitialisingQuestion;
        }

        public string getMaxQuestions(ref string inputString, ref bool ismaxQuestionsInitiated, ref int maxQuestions, bool isDifficultyInitiated)
        {
            if (!ismaxQuestionsInitiated && inputString != null)
            {
                maxQuestions = int.Parse(inputString);
                ismaxQuestionsInitiated = true;
                inputString = null;
            }
            else if (!ismaxQuestionsInitiated && isDifficultyInitiated)
            {
                return "How many questions?";
            }
            return null;
        }

        public string getDifficulty(ref string inputString, ref bool isDifficultyInitiated, ref int difficulty)
        {
            if (!isDifficultyInitiated && inputString != null)
            {
                difficulty = int.Parse(inputString);
                isDifficultyInitiated = true;
                inputString = null;
            }
            else if (!isDifficultyInitiated)
            {
                return "Difficulty?";
            }
            return null;
        }

    }
}