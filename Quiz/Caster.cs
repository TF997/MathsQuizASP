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
            lastQuestion.FirstNum = question.numbers.FirstNumber;
            lastQuestion.SecondNum = question.numbers.SecondNumber;
            lastQuestion.ThirdNum = question.numbers.ThirdNumber;
            lastQuestion.OperatorsIndexOne = question.questionOperators.OperatorsIndexOne;
            lastQuestion.OperatorsIndexTwo = question.questionOperators.OperatorsIndexTwo;
            lastQuestion.ExtraOperators = question.questionOperators.ExtraOperators;
            return lastQuestion;
        }
    }
}