using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathsQuiz;

namespace MathsQuizASP
{
    public class Initialise
    {

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

        public DifficultyData getDifficulty(string inputString)
        {
            DifficultyData difficultyData = new DifficultyData();

            if (!difficultyData.isDifficultyInitiated && inputString != null)
            {
                difficultyData.difficulty = int.Parse(inputString);
                difficultyData.isDifficultyInitiated = true;
            }
            else if (!difficultyData.isDifficultyInitiated)
            {
                difficultyData.initialiserQuestion = "Difficulty?";
            }
            return difficultyData;
        }

    }

}