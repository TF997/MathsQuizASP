using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuiz
{
    public class NumberGenerator
    {
        private static Random __randomNumberGenerator;
        int __lastGeneratedNumber = 0;

        public int AssignNumberBasedOnRange(int lowerBound, int upperBound)
        {
            __randomNumberGenerator = new Random();
            int number = __randomNumberGenerator.Next(lowerBound, upperBound);
            if (__lastGeneratedNumber != 0)
            {
                while(__lastGeneratedNumber == number)
                {
                    number = __randomNumberGenerator.Next(lowerBound, upperBound);
                }
            }
            __lastGeneratedNumber = number;
            return number;
        }
    }
}