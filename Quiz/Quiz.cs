namespace MathsQuiz
{
    public class Quiz
    {
        public readonly Question question = new Question();
        private readonly Answer answer = new Answer();
        public MaxQuestionData maxQuestionData = new MaxQuestionData();
        public LastQuestion lastQuestion = new LastQuestion();
        public DifficultyData difficultyData = new DifficultyData();
        private bool IsThisTheFirstQuestion = false;
        public int Total = 0;
        public int QuestionCounter = 0;
        public int Result;
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

        public void CheckSetupIsCompleted()
        {
            difficultyData.NeedsSetting();
            maxQuestionData.NeedsSetting();
            CheckThisIsTheFirstQuestion();
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
                string IntialiserQuestion = maxQuestionData.GetData(UserInput);
                if (IntialiserQuestion != null)
                {
                    return IntialiserQuestion;
                }
            }
            return null;
        }

        public string CheckForDifficultyandMaxQuestions() 
        {

            string QuestionToReturn = null;
            string DifficultyInitialiseQuestion = CheckDifficultyIsSet();
            string MaxQuestionInitialiseQuestion = CheckMaxQuestionsIsSet();

            if (DifficultyInitialiseQuestion != null)
            {
                QuestionToReturn = DifficultyInitialiseQuestion;
            }
            else if (MaxQuestionInitialiseQuestion != null)
            {
                QuestionToReturn = MaxQuestionInitialiseQuestion;
            }
            return QuestionToReturn;
        }

        public string AskQuestion()
        {
            question.GenerateQuestion(difficultyData.Value);
            return (question.DisplayQuestion());

        }

        public QuizOutput GetQuestionAndSubmitLastAnswer(string inputString) {
            UserInput = inputString;
            QuizOutput quizOutput = new QuizOutput();
            if (QuestionCounter < maxQuestionData.Value)
            {
                quizOutput.QuestionTextString = AskQuestion();
                if (!IsThisTheFirstQuestion)
                {
                    quizOutput.AnswerTextString = SubmitLastAnswer();
                }
            }
            else if (QuestionCounter != 0)
            {
                quizOutput.AnswerTextString = SubmitLastAnswer();
                quizOutput.QuestionTextString = ResultsToDisplay();
            }
            lastQuestion.CopyDataFromCurrentQuestion(question);
            QuestionCounter++;
            return quizOutput;
        }

        public string InterperateCorrectOrIncorrectFromResult()
        {
            string TextToDisplay = null;
            if (Result == 1)
            {
                TextToDisplay = "Last Answer was CORRECT!";
            }
            else if (Result == 0)
            {
                TextToDisplay = "Last Answer was INCORRECT!";
            }
            return TextToDisplay;
        }

        public string SubmitLastAnswer() 
        {
            Result = answer.CheckIfUserAnswerIsCorrect(UserInput, lastQuestion);
            Total += Result;
            string answerTextString = InterperateCorrectOrIncorrectFromResult();

            return answerTextString;
        }

        public void CheckThisIsTheFirstQuestion()
        {
            if (lastQuestion.QuestionToAsk == null)
            {
                IsThisTheFirstQuestion = true;
            }
            else
            {
                IsThisTheFirstQuestion = false;
            }
        }

        public void CheckEndOfQuiz()
        {
            if (QuestionCounter > maxQuestionData.Value && QuestionCounter != 0)
            {
                ResetVariables();
            }
        }

        private void ResetVariables() 
        {
            QuestionCounter = 0;
            difficultyData.IsInitiated = false;
            maxQuestionData.IsInitiated = false;
        }


        private string ResultsToDisplay()
        {
            return($"You scored: {Total} out of a total: {maxQuestionData.Value}");
        }

    }
}
