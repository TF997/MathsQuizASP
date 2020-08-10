using System;


namespace MathsQuiz
{
    class Answer
    {
        private int trueAnswer;
        public int userAnswer { get; set; }

        public int compareAnswer(string question, int firstNum, int secondNum, int opIndex, int opIndexTwo, bool extraOp, int userAnswer)
        {
            trueAnswer = getTrueAnswer(question,firstNum, secondNum, opIndex, opIndexTwo, extraOp);
            System.Diagnostics.Debug.WriteLine(trueAnswer);
            return checkAnswer(userAnswer, trueAnswer);
        }

        public int getUserAnswer()
        {
            string temp;
            int answer = int.Parse(string.IsNullOrEmpty(temp = Console.ReadLine()) ? "0" : temp);
            return answer;
        }

        private int getTrueAnswer(string question, int firstNum, int secondNum, int opIndex, int opIndexTwo, bool extraOp)
        {
            if (opIndex == 5)
            {
                return (int)Math.Pow(firstNum, secondNum);
            }
            else if (opIndex == 4)
            {
                return (int)Math.Sqrt(firstNum);
            }
            else
            {
                return Eval(question, opIndex, opIndexTwo, extraOp);
            }
        }

        private int checkAnswer(int userAnswer, int trueAnswer)
        {
            if (userAnswer == trueAnswer)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public int Eval(string question, int opIndex, int opIndexTwo, bool extraOp)
        {
            int evalAnswer;
            System.Data.DataTable table = new System.Data.DataTable();
            if (opIndex == 3 || (opIndexTwo == 3 && extraOp))
            {
                evalAnswer = Convert.ToInt32((double)table.Compute(question, string.Empty));
            }
            else
            {
                evalAnswer = (int)table.Compute(question, string.Empty);
            }
            return evalAnswer;
        }
    }
}
