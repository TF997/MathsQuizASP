using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MathsQuiz
{
    public class ManageState : System.Web.UI.Page
    {
        public StateInitialiserBooleans initaliseQuizStates(string question, int maxQuestions)
        {
            StateInitialiserBooleans stateInitialiserBooleans = new StateInitialiserBooleans();

            if (question != null)
            {
                stateInitialiserBooleans.needRefresh = false;
            }
            if (maxQuestions > 0)
            {
                stateInitialiserBooleans.ismaxQuestionsInitiated = true;
            }

            return stateInitialiserBooleans;
        }

        public LastSession loadQuiz()
        {
            LastSession lastSession = new LastSession();
            if(Session["total"] != null)
            {
                lastSession.total = int.Parse(Session["total"].ToString());

            }
            if (Session["difficulty"] != null)
            {
                lastSession.difficulty = int.Parse(Session["difficulty"].ToString());

            }
            if (Session["maxQuestions"] != null)
            {
                lastSession.maxQuestions = int.Parse(Session["maxQuestions"].ToString());

            }
            if (Session["questionCounter"] != null)
            {
                lastSession.questionCounter = int.Parse(Session["questionCounter"].ToString());

            }
            if (Session["lastQuestion"] != null)
            {
                lastSession.lastQuestion = (LastQuestion)Session["lastQuestion"]; 
            }

            return lastSession;
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