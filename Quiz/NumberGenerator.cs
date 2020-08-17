using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class NumberGenerator
    {
        private static Random randomNumberGenerator;
        int lastGeneratedNumber = 0;

        public int assignNumberBasedOnRange(int LowerBound, int UpperBound)
        {
            randomNumberGenerator = new Random();
            int number = randomNumberGenerator.Next(LowerBound, UpperBound);
            if (lastGeneratedNumber != 0)
            {
                while(lastGeneratedNumber == number)
                {
                    number = randomNumberGenerator.Next(LowerBound, UpperBound);
                }
            }
            lastGeneratedNumber = number;
            return number;
        }
    }
}