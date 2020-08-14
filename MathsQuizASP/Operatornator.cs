using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class Operatornator
    {
        private static Random randomNumberGenerator;
        private int easyOperatorLowerBound = 0;
        private int easyOperatorUpperBound = 4;
        private int mediumOperatorLowerBound = 2;
        private int mediumOperatorUpperBound = 6;

        public Tuple<int,int,bool> generateOperatorBasedOnDifficulty(int difficulty)
        {
            int operatorsIndex;
            int operatorsIndexTwo = -1;
            bool extraOperators = false;
            randomNumberGenerator = new Random();
            if (difficulty == 1)
            {
                operatorsIndex = randomNumberGenerator.Next(easyOperatorLowerBound, easyOperatorUpperBound);
            }
            else if (difficulty == 2)
            {
                operatorsIndex = randomNumberGenerator.Next(mediumOperatorLowerBound, mediumOperatorUpperBound);
            }
            else
            {
                if (randomNumberGenerator.Next(101) > 75)
                {
                    operatorsIndex = randomNumberGenerator.Next(easyOperatorLowerBound, easyOperatorUpperBound);
                    operatorsIndexTwo = randomNumberGenerator.Next(easyOperatorLowerBound, easyOperatorUpperBound);
                    extraOperators = true;
                }
                else
                {
                    operatorsIndex = randomNumberGenerator.Next(easyOperatorLowerBound, mediumOperatorUpperBound);
                    extraOperators = false;
                }
            }
            return new Tuple<int, int, bool>(operatorsIndex, operatorsIndexTwo, extraOperators);
        }
    }
}