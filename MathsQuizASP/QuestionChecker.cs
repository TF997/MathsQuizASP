using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class QuestionChecker
    {
        private int squareIdentifier = 5;
        private int squareRootIdentifier = 4;
        private int divisionIdentifier = 3;

        public Tuple<string,int> checkQuestionResults(int operatorsIndex, int firstNum, int secondNum)
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
                changedProperty = checkDivisionResult(firstNum, secondNum);
            }


            if (operatorsIndex == squareRootIdentifier)
            {
                changeIdentifier = "operatorsIndex";
                if (!checkIfSquareNumber(firstNum))
                {
                    changedProperty = 2;
                }
            }
            return new Tuple<string, int>(changeIdentifier, changedProperty);
        }

        private int checkDivisionResult(int firstNum, int secondNum)
        {
            if ((firstNum % secondNum != 0))
            {
                firstNum = firstNum * secondNum;
            }

            return firstNum;
        }

        public Tuple<int,int> makeLargerNumberOne(int firstNum, int secondNum)
        {
            if (firstNum < secondNum)
            {
                int temporaryFirstNum = firstNum;
                firstNum = secondNum;
                secondNum = temporaryFirstNum;
            }
            return new Tuple<int, int>(firstNum, secondNum);
        }

        private bool checkIfSquareNumber(int firstNum)
        {
            double result = Math.Sqrt(firstNum);
            bool isSquare = result % 1 == 0;
            return isSquare;
        }
    }
}