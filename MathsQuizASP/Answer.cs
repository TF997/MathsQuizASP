using System;


namespace MathsQuiz
{
    class Answer
    {
        private int trueAnswer;
        public int userAnswer { get; set; }

        public int compareAnswer(LastQuestion lastQuestion, int userAnswer)
        {
            trueAnswer = getTrueAnswer(lastQuestion);
            System.Diagnostics.Debug.WriteLine(trueAnswer);
            return checkAnswer(userAnswer, trueAnswer);
        }

        public int getUserAnswer()
        {
            string temp;
            int answer = int.Parse(string.IsNullOrEmpty(temp = Console.ReadLine()) ? "0" : temp);
            return answer;
        }

        private int getTrueAnswer(LastQuestion lastQuestion)
        {
            if (lastQuestion.opIndex == 5)
            {
                return (int)Math.Pow(lastQuestion.firstNum, lastQuestion.secondNum);
            }
            else if (lastQuestion.opIndex == 4)
            {
                return (int)Math.Sqrt(lastQuestion.firstNum);
            }
            else
            {
                return Eval(lastQuestion.question, lastQuestion.opIndex, lastQuestion.opIndexTwo, lastQuestion.extraOp);
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
