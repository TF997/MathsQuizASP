using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class QuestionElementsToCheck
    {
        public int OperatorsIndexOne { get; set; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public QuestionElementsToCheck(int OperatorsIndexOne, int FirstNumber, int SecondNumber)
        {
            this.OperatorsIndexOne = OperatorsIndexOne;
            this.FirstNumber = FirstNumber;
            this.SecondNumber = SecondNumber;
        }
    }
}