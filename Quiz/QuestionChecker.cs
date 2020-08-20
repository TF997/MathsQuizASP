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

        public QuestionCheckResults CheckQuestionResults(QuestionElementsToCheck questionElementsToCheck)
        {
            QuestionCheckResults questionCheckResults = new QuestionCheckResults();
            if (questionElementsToCheck.OperatorsIndexOne == squareIdentifier)
            {
                questionCheckResults.ChangeIdentifier = "secondNum";
                questionCheckResults.ChangedProperty = 2;
            }

            if (questionElementsToCheck.OperatorsIndexOne == divisionIdentifier)
            {
                questionCheckResults.ChangeIdentifier = "firstNum";
                questionCheckResults.ChangedProperty = CheckDivisionResult(questionElementsToCheck.FirstNumber, questionElementsToCheck.SecondNumber);
            }


            if (questionElementsToCheck.OperatorsIndexOne == squareRootIdentifier)
            {
                questionCheckResults.ChangeIdentifier = "operatorsIndex";
                if (!CheckIfSquareNumber(questionElementsToCheck.FirstNumber))
                {
                    questionCheckResults.ChangedProperty = 2;
                }
            }
            return questionCheckResults;
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