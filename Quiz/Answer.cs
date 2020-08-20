using System;


namespace MathsQuiz
{
    class Answer
    {
        private readonly int __divisionIdentifier = 3;

        public int ParseUserAnswerFromString(string userAnswerString)
        {
            return(int.Parse(userAnswerString));
        }

        public int CheckIfUserAnswerIsCorrect(string inputString, LastQuestion lastQuestion)
        {
            int _UserAnswer = ParseUserAnswerFromString(inputString);
            int _TrueAnswer = CalculateTrueAnswer(lastQuestion);
            int _Result = CompareAnswers(_UserAnswer, _TrueAnswer);
            return _Result;
        }

        private int CalculateTrueAnswer(LastQuestion lastQuestion)
        {
            if (lastQuestion.__OperatorsIndexOne == 5)
            {
                return (int)Math.Pow(lastQuestion.__FirstNum, lastQuestion.__SecondNum);
            }
            else if (lastQuestion.__OperatorsIndexOne == 4)
            {
                return (int)Math.Sqrt(lastQuestion.__FirstNum);
            }
            else
            {
                return Eval(lastQuestion.__QuestionToAsk, lastQuestion.__OperatorsIndexOne, lastQuestion.__OperatorsIndexTwo, lastQuestion.__ExtraOperators);
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
            int _evalAnswer;
            System.Data.DataTable table = new System.Data.DataTable();
            if (operatorsIndex == __divisionIdentifier || (operatorsIndexTwo == __divisionIdentifier && extraOperators))
            {
                _evalAnswer = Convert.ToInt32((double)table.Compute(question, string.Empty));
            }
            else
            {
                _evalAnswer = (int)table.Compute(question, string.Empty);
            }
            return _evalAnswer;
        }
    }
}
