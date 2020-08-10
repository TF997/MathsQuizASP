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
        private char[] op  = { '+', '-', '*', '/', '√', '^'};
        public int opIndex { get; set; }
        public int opIndexTwo { get; set; }
        public bool extraOp { get; set; }
        public string question { get; set;}
        public int trueAnswer { get; set; }

        public void generateQuestion(int difficulty)
        {
            rng = new Random();
            getOp(difficulty);
            assignNumbers();
            makeLargerNumberOne();
            checkOp();
        }
        //remove magic numbers add related
        private void assignNumbers()
        {
            firstNum = rng.Next(1, 11);
            secondNum = rng.Next(1, 11);
            while (secondNum == firstNum)
            {
                secondNum = rng.Next(1, 11);
            };
            if (extraOp)
            {
                thirdNum = rng.Next(1, 11);
            }
        }

        private void checkOp()
        {
            if (opIndex == 5) 
            {
                secondNum = 2;
            }

            if (opIndex == 3 & (firstNum % secondNum != 0)) 
            {
                opIndex = 2;
            }

            else if (opIndex == 4) 
            {
                if (!checkIfSquareNumber(firstNum))
                {
                    opIndex = 2;
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
            if (opIndex == 4)
            {
                question = op[opIndex] + firstNum.ToString();
            }
            else if(!extraOp)
            {
                question = firstNum.ToString() + " " + op[opIndex] + " " + secondNum.ToString();
            }
            else
            {
                question = firstNum.ToString() + " " + op[opIndex] + " " + secondNum.ToString() + " " + op[opIndexTwo] + " " + thirdNum.ToString();
 
            }

            return(question);
        }
      

        private void getOp(int difficulty)
        {
            if (difficulty == 1)
            {
                opIndex = rng.Next(0, 4);
            }
            else if (difficulty == 2)
            {
                opIndex = rng.Next(2, 6);
            }
            else
            {
                if (rng.Next(101) > 75)
                {
                    opIndex = rng.Next(0, 4);
                    opIndexTwo = rng.Next(0, 4);
                    extraOp = true;
                }
                else
                {
                    opIndex = rng.Next(0, 6);
                    extraOp = false;
                }
            }
        }

    }
}
