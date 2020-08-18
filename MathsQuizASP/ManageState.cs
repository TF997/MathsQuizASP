using MathsQuiz;
namespace MathsQuizUI
{
    public class ManageState : System.Web.UI.Page
    {
        public LastSession LoadQuiz()
        {
            LastSession lastSession = new LastSession();
            if(Session["total"] != null)
            {
                lastSession.Total = int.Parse(Session["total"].ToString());

            }
            if (Session["difficulty"] != null)
            {
                lastSession.Difficulty = int.Parse(Session["difficulty"].ToString());

            }
            if (Session["maxQuestions"] != null)
            {
                lastSession.MaxQuestions = int.Parse(Session["maxQuestions"].ToString());

            }
            if (Session["questionCounter"] != null)
            {
                lastSession.QuestionCounter = int.Parse(Session["questionCounter"].ToString());

            }
            if (Session["lastQuestion"] != null)
            {
                lastSession.LastSessionQuestion = (LastQuestion)Session["lastQuestion"]; 
            }

            return lastSession;
        }

        public void SaveQuiz(LastQuestion lastQuestion, int difficulty, int maxQuestions, int questionCounter, int total)
        {
            Session["total"] = total;
            Session["lastQuestion"] = lastQuestion;
            Session["questionCounter"] = questionCounter;
            Session["difficulty"] = difficulty;
            Session["maxQuestions"] = maxQuestions;
        }

        public void SaveConfig(int difficulty, int maxQuestions)
        {
            Session["difficulty"] = difficulty;
            Session["maxQuestions"] = maxQuestions;
        }
    }
}