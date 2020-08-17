using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class QuestionChecker
    {
        private readonly int squareIdentifier = 5;
        private readonly int squareRootIdentifier = 4;
        private readonly int divisionIdentifier = 3;

        public Tuple<string,int> CheckQuestionResults(int operatorsIndex, int firstNum, int secondNum)
        {
            string changeIdentifier = null;
            int changedProperty = -1;
            if (operatorsIndex == squareIdentifier)
            {
                changeIdentifier = "secondNum";
                changedProperty = 2;
            }

            if (operatorsIndex == divisionIdentifier)
            {
                changeIdentifier = "firstNum";
                changedProperty = CheckDivisionResult(firstNum, secondNum);
            }


            if (operatorsIndex == squareRootIdentifier)
            {
                changeIdentifier = "operatorsIndex";
                if (!CheckIfSquareNumber(firstNum))
                {
                    changedProperty = 2;
                }
            }
            return new Tuple<string, int>(changeIdentifier, changedProperty);
        }

        private int CheckDivisionResult(int firstNum, int secondNum)
        {
            if ((firstNum % secondNum != 0))
            {
                firstNum *= secondNum;
            }

            return firstNum;
        }

        public QuestionNumbers MakeLargerNumberOne(QuestionNumbers numbers)
        {
            if (numbers.FirstNumber < numbers.SecondNumber)
            {
                int temporaryFirstNum = numbers.FirstNumber;
                numbers.FirstNumber = numbers.SecondNumber;
                numbers.SecondNumber = temporaryFirstNum;
            }
            return numbers;
        }

        private bool CheckIfSquareNumber(int firstNum)
        {
            double result = Math.Sqrt(firstNum);
            bool isSquare = result % 1 == 0;
            return isSquare;
        }
    }
}