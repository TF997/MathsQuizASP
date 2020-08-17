namespace MathsQuiz
{
    public class Quiz
    {
        private readonly Initialise initialise = new Initialise();
        public readonly Question question = new Question();
        private readonly Answer answer = new Answer();
        public MaxQuestionData maxQuestionData = new MaxQuestionData();
        public LastQuestion lastQuestion = new LastQuestion();
        public DifficultyData difficultyData = new DifficultyData();
        public int Total = 0;
        public int QuestionCounter = 1;
        private string UserInput;

        public Question GetQuestion()
        {
            return question;
        }

        public string QuizSetup(string inputString) 
        {
            UserInput = inputString;
            difficultyData.NeedsSetting();
            maxQuestionData.NeedsSetting();
            string initialiseQuestion = CheckForDifficultyandMaxQuestions();

            return initialiseQuestion;
        }

        public string CheckDifficultyIsSet() 
        {
            if (!difficultyData.IsInitiated)
            {
                string IntialiserQuestion = difficultyData.GetData(UserInput);
                if (difficultyData.IsInitiated)
                {
                    UserInput = null;
                }
                if (IntialiserQuestion != null)
                {
                    return IntialiserQuestion;
                }
            }
            return null;
        }

        public string CheckMaxQuestionsIsSet()
        {
            if (!maxQuestionData.IsInitiated && difficultyData.IsInitiated)
            {
                maxQuestionData = initialise.GetMaxQuestions(UserInput, difficultyData.IsInitiated);
                if (maxQuestionData.InitialiserQuestion != null)
                {
                    return maxQuestionData.InitialiserQuestion;
                }
            }
            return null;
        }

        public string CheckForDifficultyandMaxQuestions() 
        {
            string DifficultyInitialiseQuestion = CheckDifficultyIsSet();
            string MaxQuestionInitialiseQuestion = CheckMaxQuestionsIsSet();
            if (DifficultyInitialiseQuestion != null)
            {
                return DifficultyInitialiseQuestion;
            }
            else if (MaxQuestionInitialiseQuestion != null)
            {
                return MaxQuestionInitialiseQuestion;
            }
            return null;
        }

        public string AskQuestion()
        {
            question.GenerateQuestion(difficultyData.Value);
            return (question.DisplayQuestion());

        }

        public QuizOutput GetQuestionAndSubmitLastAnswer(string inputString, bool DoesPageNeedRefresh) {
            UserInput = inputString;
            QuizOutput quizOutput = new QuizOutput();
            if (QuestionCounter < maxQuestionData.Value)
            {
                quizOutput.QuestionTextString = AskQuestion();
                if (!DoesPageNeedRefresh)
                {
                    quizOutput.AnswerTextString = SubmitLastAnswer();
                }
            }
            else if (QuestionCounter != 1)
            {
                quizOutput.AnswerTextString = SubmitLastAnswer();
                quizOutput.QuestionTextString = ResultsToDisplay();
            }
            return quizOutput;
        }

        public string InterperateCorrectOrIncorrectFromResult(int Result)
        {
            if (Result == 1)
            {
                return "Last Answer was CORRECT!";
            }
            else if (Result == 0)
            {
                return "Last Answer was INCORRECT!";
            }
            return null;
        }

        public string SubmitLastAnswer() 
        {
            int Result = answer.CheckIfUserAnswerIsCorrect(UserInput, lastQuestion);
            Total += Result;
            string answerTextString = InterperateCorrectOrIncorrectFromResult(Result);
            QuestionCounter++;

            return answerTextString;
        }

        public void CheckEndOfQuiz()
        {
            if (QuestionCounter > maxQuestionData.Value && QuestionCounter != 1)
            {
                ResetVariables();
            }
        }

        private void ResetVariables() 
        {
            QuestionCounter = 1;
            difficultyData.IsInitiated = false;
            maxQuestionData.IsInitiated = false;
        }


        private string ResultsToDisplay()
        {
            return($"You scored: {Total} out of a total: {maxQuestionData.Value}");
        }

    }
}
