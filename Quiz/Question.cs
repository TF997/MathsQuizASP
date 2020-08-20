using System;

namespace MathsQuiz
{
    public class Question
    {
        private readonly Operatornator operatornator = new Operatornator();
        private readonly NumberGenerator numberGenerator = new NumberGenerator();
        private readonly QuestionChecker questionChecker = new QuestionChecker();
        public QuestionNumbers questionNumbers = new QuestionNumbers();
        public QuestionOperators questionOperators = new QuestionOperators();
        private readonly char[] mathOperators  = { '+', '-', '*', '/', '√', '^'};
        public string QuestionToAsk { get; set;}
        public int TrueAnswer { get; set; }
        private readonly int easyLowerBound = 1;
        private readonly int easyUpperBound = 11;
        
        public void GenerateQuestion(int difficulty)
        {
            questionOperators = operatornator.GenerateOperatorBasedOnDifficulty(difficulty);
            GetQuestionNumbers();
            questionNumbers = questionChecker.MakeLargerNumberOne(questionNumbers);
            QuestionElementsToCheck questionElementsToCheck = new QuestionElementsToCheck(questionOperators.OperatorsIndexOne, questionNumbers.FirstNumber, questionNumbers.SecondNumber);
            QuestionCheckResults questionCheckResults = questionChecker.CheckQuestionResults(questionElementsToCheck);
            MakeNeededChangesToQuestion(questionCheckResults);
        }

        public void MakeNeededChangesToQuestion(QuestionCheckResults questionCheckResults) 
        {
            switch (questionCheckResults.ChangeIdentifier)
            {
                case "secondNum":
                    questionNumbers.SecondNumber = questionCheckResults.ChangedProperty;
                    break;
                case "firstNum":
                    questionNumbers.FirstNumber = questionCheckResults.ChangedProperty;
                    break;
                case "operatorsIndex":
                    questionOperators.OperatorsIndexOne = questionCheckResults.ChangedProperty;
                    break;
            }

        }

        private void GetQuestionNumbers()
        {
            questionNumbers.FirstNumber = numberGenerator.AssignNumberBasedOnRange(easyLowerBound, easyUpperBound);
            questionNumbers.SecondNumber = numberGenerator.AssignNumberBasedOnRange(easyLowerBound, easyUpperBound);
            if (questionOperators.ExtraOperators)
            {
                questionNumbers.ThirdNumber = numberGenerator.AssignNumberBasedOnRange(easyLowerBound, easyUpperBound);
            }
        }
        
        public string DisplayQuestion()
        {
            if (questionOperators.OperatorsIndexOne == 4)
            {
                QuestionToAsk = mathOperators[questionOperators.OperatorsIndexOne] + questionNumbers.FirstNumber.ToString();
            }
            else if(!questionOperators.ExtraOperators)
            {
                QuestionToAsk = questionNumbers.FirstNumber.ToString() + " " + mathOperators[questionOperators.OperatorsIndexOne] + " " + questionNumbers.SecondNumber.ToString();
            }
            else
            {
                QuestionToAsk = questionNumbers.FirstNumber.ToString() + " " + mathOperators[questionOperators.OperatorsIndexOne] + " " + questionNumbers.SecondNumber.ToString() + " " + mathOperators[questionOperators.OperatorsIndexTwo] + " " + questionNumbers.ThirdNumber.ToString();
 
            }

            return(QuestionToAsk);
        }

    }
}
