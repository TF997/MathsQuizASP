using System;
using System.Web;
using System.Web.UI;
using MathsQuiz;

namespace MathsQuizASP
{
    public class Save : Control
    {
        public void saveQuizStates(Question question, int difficulty, int maxQuestions, int questionCounter)
        {
            ViewState["question"] = question.question;
            ViewState["firstNum"] = question.firstNum;
            ViewState["secondNum"] = question.secondNum;
            ViewState["opIndex"] = question.opIndex;
            ViewState["opIndexTwo"] = question.opIndexTwo;
            ViewState["extraOp"] = question.extraOp;

            if (difficulty != 0)
            {
                ViewState["difficulty"] = difficulty;
            }
            if (maxQuestions != -1)
            {
                ViewState["maxQuestions"] = maxQuestions;
                ViewState["questionCounter"] = questionCounter;
            }
        }
    }


}