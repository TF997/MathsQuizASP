using System;

namespace MathsQuiz
{
    public class Question
    {
        private static Random rng;
        //add private setters
        public int firstNum { get; set; }
        public int secondNum { get; set;}
        public int thirdNum { get; set; }
        private char[] mathOperators  = { '+', '-', '*', '/', '√', '^'};
        public int operatorsIndex { get; set; }
        public int operatorsIndexTwo { get; set; }
        public bool extraOperators { get; set; }
        public string question { get; set;}
        public int trueAnswer { get; set; }
        private int easyLowerBound = 1;
        private int easyUpperBound = 11;
        private int easyOperatorLowerBound = 0;
        private int easyOperatorUpperBound = 4;
        private int mediumOperatorLowerBound = 2;
        private int mediumOperatorUpperBound = 6;
        private int squareIdentifier = 5;
        private int squareRootIdentifier = 4;
        private int divisionIdentifier = 3;
        public void generateQuestion(int difficulty)
        {
            rng = new Random();
            getOp(difficulty);
            assignNumbers();
            makeLargerNumberOne();
            checkOp();
        }

        private void assignNumbers()
        {
            firstNum = rng.Next(easyLowerBound, easyUpperBound);
            secondNum = rng.Next(easyLowerBound, easyUpperBound);
            while (secondNum == firstNum)
            {
                secondNum = rng.Next(easyLowerBound, easyUpperBound);
            };
            if (extraOperators)
            {
                thirdNum = rng.Next(easyLowerBound, easyUpperBound);
            }
        }

        private void checkOp()
        {
            if (operatorsIndex == squareIdentifier) 
            {
                secondNum = 2;
            }

            if (operatorsIndex == divisionIdentifier & (firstNum % secondNum != 0)) 
            {
                firstNum = firstNum * secondNum;
            }

            else if (operatorsIndex == squareRootIdentifier) 
            {
                if (!checkIfSquareNumber(firstNum))
                {
                    operatorsIndex = 2;
                }
            }
        }

        private void makeLargerNumberOne()
        {
            if (firstNum < secondNum)
            {
                int temporaryFirstNum = firstNum;
                firstNum = secondNum;
                secondNum = temporaryFirstNum;
            }
        }

        private bool checkIfSquareNumber(int firstNum)
        {
            double result = Math.Sqrt(firstNum);
            bool isSquare = result % 1 == 0;
            return isSquare;
        }

        public string displayQuestion()
        {
            if (operatorsIndex == 4)
            {
                question = mathOperators[operatorsIndex] + firstNum.ToString();
            }
            else if(!extraOperators)
            {
                question = firstNum.ToString() + " " + mathOperators[operatorsIndex] + " " + secondNum.ToString();
            }
            else
            {
                question = firstNum.ToString() + " " + mathOperators[operatorsIndex] + " " + secondNum.ToString() + " " + mathOperators[operatorsIndexTwo] + " " + thirdNum.ToString();
 
            }

            return(question);
        }
      

        private void getOp(int difficulty)
        {
            if (difficulty == 1)
            {
                operatorsIndex = rng.Next(easyOperatorLowerBound, easyOperatorUpperBound);
            }
            else if (difficulty == 2)
            {
                operatorsIndex = rng.Next(mediumOperatorLowerBound, mediumOperatorUpperBound);
            }
            else
            {
                if (rng.Next(101) > 75)
                {
                    operatorsIndex = rng.Next(easyOperatorLowerBound, easyOperatorUpperBound);
                    operatorsIndexTwo = rng.Next(easyOperatorLowerBound, easyOperatorUpperBound);
                    extraOperators = true;
                }
                else
                {
                    operatorsIndex = rng.Next(easyOperatorLowerBound, mediumOperatorUpperBound);
                    extraOperators = false;
                }
            }
        }

    }
}
