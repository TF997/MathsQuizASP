using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class QuestionChecker
    {
        private readonly int __squareIdentifier = 5;
        private readonly int __squareRootIdentifier = 4;
        private readonly int __divisionIdentifier = 3;

        public QuestionCheckResults CheckQuestionResults(QuestionElementsToCheck questionElementsToCheck)
        {
            QuestionCheckResults _questionCheckResults = new QuestionCheckResults();
            if (questionElementsToCheck.__OperatorsIndexOne == __squareIdentifier)
            {
                _questionCheckResults.__ChangeIdentifier = "secondNum";
                _questionCheckResults.__ChangedProperty = 2;
            }

            if (questionElementsToCheck.__OperatorsIndexOne == __divisionIdentifier)
            {
                _questionCheckResults.__ChangeIdentifier = "firstNum";
                _questionCheckResults.__ChangedProperty = CheckDivisionResult(questionElementsToCheck.__FirstNumber, questionElementsToCheck.__SecondNumber);
            }


            if (questionElementsToCheck.__OperatorsIndexOne == __squareRootIdentifier)
            {
                if (!CheckIfSquareNumber(questionElementsToCheck.__FirstNumber))
                {
                    _questionCheckResults.__ChangeIdentifier = "operatorsIndex";
                    _questionCheckResults.__ChangedProperty = 2;
                }
            }
            return _questionCheckResults;
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
            if (numbers.__FirstNumber < numbers.__SecondNumber)
            {
                int _temporaryFirstNum = numbers.__FirstNumber;
                numbers.__FirstNumber = numbers.__SecondNumber;
                numbers.__SecondNumber = _temporaryFirstNum;
            }
            return numbers;
        }

        private bool CheckIfSquareNumber(int firstNum)
        {
            double _result = Math.Sqrt(firstNum);
            bool _isSquare = _result % 1 == 0;
            return _isSquare;
        }
    }
}