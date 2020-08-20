using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class Operatornator
    {
        private static Random randomNumberGenerator;
        private const int easyOperatorLowerBound = 0;
        private const int easyOperatorUpperBound = 4;
        private const int mediumOperatorLowerBound = 2;
        private const int mediumOperatorUpperBound = 6;

        public QuestionOperators GenerateOperatorBasedOnDifficulty(int difficulty)
        {
            QuestionOperators questionOperators = new QuestionOperators();
            randomNumberGenerator = new Random();
            if (difficulty == 1)
            {
                questionOperators.OperatorsIndexOne = randomNumberGenerator.Next(easyOperatorLowerBound, easyOperatorUpperBound);
            }
            else if (difficulty == 2)
            {
                questionOperators.OperatorsIndexOne = randomNumberGenerator.Next(mediumOperatorLowerBound, mediumOperatorUpperBound);
            }
            else
            {
                if (randomNumberGenerator.Next(101) > 75)
                {
                    questionOperators.OperatorsIndexOne = randomNumberGenerator.Next(easyOperatorLowerBound, easyOperatorUpperBound);
                    questionOperators.OperatorsIndexTwo = randomNumberGenerator.Next(easyOperatorLowerBound, easyOperatorUpperBound);
                    questionOperators.ExtraOperators = true;
                }
                else
                {
                    questionOperators.OperatorsIndexOne = randomNumberGenerator.Next(easyOperatorLowerBound, mediumOperatorUpperBound);
                    questionOperators.ExtraOperators = false;
                }
            }
            return questionOperators;
        }
    }
}