using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class QuestionElementsToCheck
    {
        public int __OperatorsIndexOne { get; set; }
        public int __FirstNumber { get; set; }
        public int __SecondNumber { get; set; }

        public QuestionElementsToCheck(int operatorsIndexOne, int firstNumber, int secondNumber)
        {
            __OperatorsIndexOne = operatorsIndexOne;
            __FirstNumber = firstNumber;
            __SecondNumber = secondNumber;
        }
    }
}