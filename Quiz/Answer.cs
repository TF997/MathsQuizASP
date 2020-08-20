using System;


namespace MathsQuiz
{
    class Answer
    {
        private readonly int divisionIdentifier = 3;

        public int ParseUserAnswerFromString(string userAnswerString)
        {
            return(int.Parse(userAnswerString));
        }

        public int CheckIfUserAnswerIsCorrect(string InputString, LastQuestion lastQuestion)
        {
            int UserAnswer = ParseUserAnswerFromString(InputString);
            int TrueAnswer = CalculateTrueAnswer(lastQuestion);
            int Result = CompareAnswers(UserAnswer, TrueAnswer);
            return Result;
        }

        private int CalculateTrueAnswer(LastQuestion lastQuestion)
        {
            if (lastQuestion.OperatorsIndexOne == 5)
            {
                return (int)Math.Pow(lastQuestion.FirstNum, lastQuestion.SecondNum);
            }
            else if (lastQuestion.OperatorsIndexOne == 4)
            {
                return (int)Math.Sqrt(lastQuestion.FirstNum);
            }
            else
            {
                return Eval(lastQuestion.QuestionToAsk, lastQuestion.OperatorsIndexOne, lastQuestion.OperatorsIndexTwo, lastQuestion.ExtraOperators);
            }
        }

        private int CompareAnswers(int userAnswer, int trueAnswer)
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



        public int Eval(string question, int operatorsIndex, int operatorsIndexTwo, bool extraOperators)
        {
            int evalAnswer;
            System.Data.DataTable table = new System.Data.DataTable();
            if (operatorsIndex == divisionIdentifier || (operatorsIndexTwo == divisionIdentifier && extraOperators))
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
