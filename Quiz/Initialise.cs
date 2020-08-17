
namespace MathsQuiz
{
    public class Initialise
    {

        public MaxQuestionData GetMaxQuestions(string UserInput, bool IsDifficultyInitiated)
        {
            MaxQuestionData maxQuestionData = new MaxQuestionData();
            if (UserInput != null)
            {
                maxQuestionData.Value = int.Parse(UserInput);
                maxQuestionData.IsInitiated = true;
            }
            else if (IsDifficultyInitiated)
            {
                maxQuestionData.InitialiserQuestion =  "How many questions?";
            }
            return maxQuestionData;
        }

        public DifficultyData GetDifficulty(string UserInput)
        {
            DifficultyData difficultyData = new DifficultyData();

            if (UserInput != null)
            {
                difficultyData.Value = int.Parse(UserInput);
                difficultyData.IsInitiated = true;
            }
            else
            {
                difficultyData.InitialiserQuestion = "Difficulty?";
            }
            return difficultyData;
        }

    }

}