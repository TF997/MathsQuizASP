using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public static class Caster
    {
        public static LastQuestion CopyDataFromCurrentQuestion(this LastQuestion lastQuestion, Question question)
        {

            lastQuestion.QuestionToAsk = question.QuestionToAsk;
            lastQuestion.FirstNum = question.questionNumbers.FirstNumber;
            lastQuestion.SecondNum = question.questionNumbers.SecondNumber;
            lastQuestion.ThirdNum = question.questionNumbers.ThirdNumber;
            lastQuestion.OperatorsIndexOne = question.questionOperators.OperatorsIndexOne;
            lastQuestion.OperatorsIndexTwo = question.questionOperators.OperatorsIndexTwo;
            lastQuestion.ExtraOperators = question.questionOperators.ExtraOperators;
            return lastQuestion;
        }
    }
}