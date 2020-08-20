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

            lastQuestion.__QuestionToAsk = question.__QuestionToAsk;
            lastQuestion.__FirstNum = question.__questionNumbers.__FirstNumber;
            lastQuestion.__SecondNum = question.__questionNumbers.__SecondNumber;
            lastQuestion.__ThirdNum = question.__questionNumbers.__ThirdNumber;
            lastQuestion.__OperatorsIndexOne = question.__questionOperators.__OperatorsIndexOne;
            lastQuestion.__OperatorsIndexTwo = question.__questionOperators.__OperatorsIndexTwo;
            lastQuestion.__ExtraOperators = question.__questionOperators.__ExtraOperators;
            return lastQuestion;
        }
    }
}