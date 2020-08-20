using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class Operatornator
    {
        private static Random __randomNumberGenerator;
        private const int __easyOperatorLowerBound = 0;
        private const int __easyOperatorUpperBound = 4;
        private const int __mediumOperatorLowerBound = 2;
        private const int __mediumOperatorUpperBound = 6;

        public QuestionOperators GenerateOperatorBasedOnDifficulty(int difficulty)
        {
            QuestionOperators _questionOperators = new QuestionOperators();
            __randomNumberGenerator = new Random();
            if (difficulty == 1)
            {
                _questionOperators.__OperatorsIndexOne = __randomNumberGenerator.Next(__easyOperatorLowerBound, __easyOperatorUpperBound);
            }
            else if (difficulty == 2)
            {
                _questionOperators.__OperatorsIndexOne = __randomNumberGenerator.Next(__mediumOperatorLowerBound, __mediumOperatorUpperBound);
            }
            else
            {
                if (__randomNumberGenerator.Next(101) > 75)
                {
                    _questionOperators.__OperatorsIndexOne = __randomNumberGenerator.Next(__easyOperatorLowerBound, __easyOperatorUpperBound);
                    _questionOperators.__OperatorsIndexTwo = __randomNumberGenerator.Next(__easyOperatorLowerBound, __easyOperatorUpperBound);
                    _questionOperators.__ExtraOperators = true;
                }
                else
                {
                    _questionOperators.__OperatorsIndexOne = __randomNumberGenerator.Next(__easyOperatorLowerBound, __mediumOperatorUpperBound);
                    _questionOperators.__ExtraOperators = false;
                }
            }
            return _questionOperators;
        }
    }
}