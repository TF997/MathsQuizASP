using System;

namespace MathsQuiz
{
    public class Question : IQuestion
    {
        private readonly Operatornator __operatornator = new Operatornator();
        private readonly NumberGenerator __numberGenerator = new NumberGenerator();
        private readonly QuestionChecker __questionChecker = new QuestionChecker();
        public QuestionNumbers __questionNumbers = new QuestionNumbers();
        public QuestionOperators __questionOperators = new QuestionOperators();
        private readonly char[] __mathOperators  = { '+', '-', '*', '/', '√', '^'};
        public string __QuestionToAsk { get; set;}
        public int __TrueAnswer { get; set; }
        private readonly int __easyLowerBound = 1;
        private readonly int __easyUpperBound = 11;
        
        public void _GenerateQuestion(int difficulty)
        {
            __questionOperators = __operatornator.GenerateOperatorBasedOnDifficulty(difficulty);
            GetQuestionNumbers();
            __questionNumbers = __questionChecker.MakeLargerNumberOne(__questionNumbers);
            QuestionElementsToCheck questionElementsToCheck = new QuestionElementsToCheck(__questionOperators.__OperatorsIndexOne, __questionNumbers.__FirstNumber, __questionNumbers.__SecondNumber);
            QuestionCheckResults questionCheckResults = __questionChecker.CheckQuestionResults(questionElementsToCheck);
            MakeNeededChangesToQuestion(questionCheckResults);
        }

        public void MakeNeededChangesToQuestion(QuestionCheckResults questionCheckResults) 
        {
            switch (questionCheckResults.__ChangeIdentifier)
            {
                case "secondNum":
                    __questionNumbers.__SecondNumber = questionCheckResults.__ChangedProperty;
                    break;
                case "firstNum":
                    __questionNumbers.__FirstNumber = questionCheckResults.__ChangedProperty;
                    break;
                case "operatorsIndex":
                    __questionOperators.__OperatorsIndexOne = questionCheckResults.__ChangedProperty;
                    break;
            }

        }

        private void GetQuestionNumbers()
        {
            __questionNumbers.__FirstNumber = __numberGenerator.AssignNumberBasedOnRange(__easyLowerBound, __easyUpperBound);
            __questionNumbers.__SecondNumber = __numberGenerator.AssignNumberBasedOnRange(__easyLowerBound, __easyUpperBound);
            if (__questionOperators.__ExtraOperators)
            {
                __questionNumbers.__ThirdNumber = __numberGenerator.AssignNumberBasedOnRange(__easyLowerBound, __easyUpperBound);
            }
        }
        
        public string DisplayQuestion()
        {
            if (__questionOperators.__OperatorsIndexOne == 4)
            {
                __QuestionToAsk = __mathOperators[__questionOperators.__OperatorsIndexOne] + __questionNumbers.__FirstNumber.ToString();
            }
            else if(!__questionOperators.__ExtraOperators)
            {
                __QuestionToAsk = __questionNumbers.__FirstNumber.ToString() + " " + __mathOperators[__questionOperators.__OperatorsIndexOne] + " " + __questionNumbers.__SecondNumber.ToString();
            }
            else
            {
                __QuestionToAsk = __questionNumbers.__FirstNumber.ToString() + " " + __mathOperators[__questionOperators.__OperatorsIndexOne] + " " + __questionNumbers.__SecondNumber.ToString() + " " + __mathOperators[__questionOperators.__OperatorsIndexTwo] + " " + __questionNumbers.__ThirdNumber.ToString();
 
            }

            return(__QuestionToAsk);
        }

    }
}
