using System;

namespace MathsQuiz
{
    public class Question
    {
        private readonly Operatornator operatornator = new Operatornator();
        private readonly NumberGenerator numberGenerator = new NumberGenerator();
        private readonly QuestionChecker questionChecker = new QuestionChecker();
        public QuestionNumbers numbers = new QuestionNumbers();
        public QuestionOperators questionOperators = new QuestionOperators();
        private readonly char[] mathOperators  = { '+', '-', '*', '/', '√', '^'};
        public string QuestionToAsk { get; set;}
        public int TrueAnswer { get; set; }
        private readonly int easyLowerBound = 1;
        private readonly int easyUpperBound = 11;
        
        public void GenerateQuestion(int difficulty)
        {
            (questionOperators.OperatorsIndexOne, questionOperators.OperatorsIndexTwo, questionOperators.ExtraOperators) = operatornator.GenerateOperatorBasedOnDifficulty(difficulty);
            GetQuestionNumbers();
            numbers = questionChecker.MakeLargerNumberOne(numbers);
            (string changeIdentifier, int changedProperty) = questionChecker.CheckQuestionResults(questionOperators.OperatorsIndexOne, numbers.FirstNumber, numbers.SecondNumber);
            MakeNeededChangesToQuestion(changeIdentifier, changedProperty);
        }

        public void MakeNeededChangesToQuestion(string changeIdentifier, int changedProperty) 
        {
            switch (changeIdentifier)
            {
                case "secondNum":
                    numbers.SecondNumber = changedProperty;
                    break;
                case "firstNum":
                    numbers.FirstNumber = changedProperty;
                    break;
                case "operatorsIndex":
                    questionOperators.OperatorsIndexOne = changedProperty;
                    break;
            }

        }

        private void GetQuestionNumbers()
        {
            numbers.FirstNumber = numberGenerator.AssignNumberBasedOnRange(easyLowerBound, easyUpperBound);
            numbers.SecondNumber = numberGenerator.AssignNumberBasedOnRange(easyLowerBound, easyUpperBound);
            if (questionOperators.ExtraOperators)
            {
                numbers.ThirdNumber = numberGenerator.AssignNumberBasedOnRange(easyLowerBound, easyUpperBound);
            }
        }
        
        public string DisplayQuestion()
        {
            if (questionOperators.OperatorsIndexOne == 4)
            {
                QuestionToAsk = mathOperators[questionOperators.OperatorsIndexOne] + numbers.FirstNumber.ToString();
            }
            else if(!questionOperators.ExtraOperators)
            {
                QuestionToAsk = numbers.FirstNumber.ToString() + " " + mathOperators[questionOperators.OperatorsIndexOne] + " " + numbers.SecondNumber.ToString();
            }
            else
            {
                QuestionToAsk = numbers.FirstNumber.ToString() + " " + mathOperators[questionOperators.OperatorsIndexOne] + " " + numbers.SecondNumber.ToString() + " " + mathOperators[questionOperators.OperatorsIndexTwo] + " " + numbers.ThirdNumber.ToString();
 
            }

            return(QuestionToAsk);
        }

    }
}
