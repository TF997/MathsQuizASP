using System;

namespace MathsQuiz
{
    public class Question
    {
        private Operatornator operatornator = new Operatornator();
        private NumberGenerator numberGenerator = new NumberGenerator();
        private QuestionChecker questionChecker = new QuestionChecker();
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
        
        public void generateQuestion(int difficulty)
        {
            (operatorsIndex, operatorsIndexTwo, extraOperators) = operatornator.generateOperatorBasedOnDifficulty(difficulty);
            getQuestionNumbers();
            (firstNum,secondNum) = questionChecker.makeLargerNumberOne(firstNum, secondNum);
            (string changeIdentifier, int changedProperty) = questionChecker.checkQuestionResults(operatorsIndex, firstNum, secondNum);
            makeNeededChangesToQuestion(changeIdentifier, changedProperty);
        }

        public void makeNeededChangesToQuestion(string changeIdentifier, int changedProperty) 
        {
            switch (changeIdentifier)
            {
                case "secondNum":
                    secondNum = changedProperty;
                    break;
                case "firstNum":
                    firstNum = changedProperty;
                    break;
                case "operatorsIndex":
                    operatorsIndex = changedProperty;
                    break;
            }

        }

        private void getQuestionNumbers()
        {
            firstNum = numberGenerator.assignNumberBasedOnRange(easyLowerBound, easyUpperBound);
            secondNum = numberGenerator.assignNumberBasedOnRange(easyLowerBound, easyUpperBound);
            if (extraOperators)
            {
                thirdNum = numberGenerator.assignNumberBasedOnRange(easyLowerBound, easyUpperBound);
            }
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

    }
}
