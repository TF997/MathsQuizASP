using System;


namespace MathsQuiz
{
    class Answer
    {
        private int trueAnswer;
        public int userAnswer { get; set; }
        public int questionResult { get; set; }
        private int divisionIdentifier = 3;

        public int compareAnswer(LastQuestion lastQuestion, int userAnswer)
        {
            trueAnswer = getTrueAnswer(lastQuestion);
            return checkAnswer(userAnswer, trueAnswer);
        }

        public int getUserAnswer(string userAnswerString)
        {
            return(int.Parse(userAnswerString));
        }

        public string getCorrectOrIncorrect(int questionResult)
        {
            if (questionResult == 1)
            {
                return "CORRECT!";
            }
            else if (questionResult == 0)
            {
                return "INCORRECT!";
            }
            return null;
        }

        public string checkAnswerAndDisplay(string inputString, LastQuestion lastQuestion)
        {
            int userAnswer = getUserAnswer(inputString);
            questionResult = compareAnswer(lastQuestion, userAnswer);
            string correctOrIncorrect = getCorrectOrIncorrect(questionResult);
            return correctOrIncorrect;
        }

        private int getTrueAnswer(LastQuestion lastQuestion)
        {
            if (lastQuestion.operatorsIndex == 5)
            {
                return (int)Math.Pow(lastQuestion.firstNum, lastQuestion.secondNum);
            }
            else if (lastQuestion.operatorsIndex == 4)
            {
                return (int)Math.Sqrt(lastQuestion.firstNum);
            }
            else
            {
                return Eval(lastQuestion.question, lastQuestion.operatorsIndex, lastQuestion.operatorsIndexTwo, lastQuestion.extraOperators);
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
