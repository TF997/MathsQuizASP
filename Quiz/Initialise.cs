using MathsQuiz;

namespace MathsQuizASP
{
    public class Initialise
    {

        public MaxQuestionData getMaxQuestions(string inputString, bool isDifficultyInitiated)
        {
            MaxQuestionData maxQuestionData = new MaxQuestionData();
            if (inputString != null)
            {
                maxQuestionData.MaxQuestions = int.Parse(inputString);
                maxQuestionData.isMaxQuestionsInitiated = true;
            }
            else if (isDifficultyInitiated)
            {
                maxQuestionData.initialiserQuestion =  "How many questions?";
            }
            return maxQuestionData;
        }

        public DifficultyData getDifficulty(string inputString)
        {
            DifficultyData difficultyData = new DifficultyData();

            if (inputString != null)
            {
                difficultyData.difficulty = int.Parse(inputString);
                difficultyData.isDifficultyInitiated = true;
            }
            else
            {
                difficultyData.initialiserQuestion = "Difficulty?";
            }
            return difficultyData;
        }

    }

}