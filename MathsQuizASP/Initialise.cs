using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsQuizASP
{
    public class Initialise
    {
        public string Difficulty(ref string inputString, ref bool isDifficultyInitiated, ref int difficulty) 
        {
            return getDifficulty(ref inputString, ref isDifficultyInitiated, ref difficulty);
        }

        public string MaxQuestions(ref string inputString, ref bool isDifficultyInitiated, ref bool ismaxQuestionsInitiated, ref int maxQuestions) 
        {
            return getMaxQuestions(ref inputString, ref ismaxQuestionsInitiated, ref maxQuestions, isDifficultyInitiated);
        }

        public string getMaxQuestions(ref string inputString, ref bool ismaxQuestionsInitiated, ref int maxQuestions, bool isDifficultyInitiated)
        {
            if (!ismaxQuestionsInitiated && inputString != null)
            {
                maxQuestions = int.Parse(inputString);
                ismaxQuestionsInitiated = true;
                inputString = null;
            }
            else if (!ismaxQuestionsInitiated && isDifficultyInitiated)
            {
                return "How many questions?";
            }
            return null;
        }

        public string getDifficulty(ref string inputString, ref bool isDifficultyInitiated, ref int difficulty)
        {
            if (!isDifficultyInitiated && inputString != null)
            {
                difficulty = int.Parse(inputString);
                isDifficultyInitiated = true;
                inputString = null;
            }
            else if (!isDifficultyInitiated)
            {
                return "Difficulty?";
            }
            return null;
        }

    }

}