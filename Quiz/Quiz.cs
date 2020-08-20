namespace MathsQuiz
{
    public class Quiz
    {
        public readonly Question __question = new Question();
        private readonly Answer __answer = new Answer();
        public MaxQuestionData __maxQuestionData = new MaxQuestionData();
        public LastQuestion __lastQuestion = new LastQuestion();
        public DifficultyData __difficultyData = new DifficultyData();
        private bool __IsThisTheFirstQuestion = false;
        public int __Total = 0;
        public int __QuestionCounter = 0;
        public int __Result;
        private string __UserInput;

        public Question GetQuestion()
        {
            return __question;
        }

        public string QuizSetup(string inputString) 
        {
            __UserInput = inputString;
            __difficultyData.NeedsSetting();
            __maxQuestionData.NeedsSetting();
            string _initialiseQuestion = CheckForDifficultyandMaxQuestions();
            return _initialiseQuestion;
        }

        public void CheckSetupIsCompleted()
        {
            __difficultyData.NeedsSetting();
            __maxQuestionData.NeedsSetting();
            CheckThisIsTheFirstQuestion();
        }

        public string CheckDifficultyIsSet() 
        {
            if (!__difficultyData.__IsInitiated)
            {
                string _IntialiserQuestion = __difficultyData.GetData(__UserInput);
                if (__difficultyData.__IsInitiated)
                {
                    __UserInput = null;
                }
                if (_IntialiserQuestion != null)
                {
                    return _IntialiserQuestion;
                }
            }
            return null;
        }

        public string CheckMaxQuestionsIsSet()
        {
            if (!__maxQuestionData.__IsInitiated && __difficultyData.__IsInitiated)
            {
                string _IntialiserQuestion = __maxQuestionData.GetData(__UserInput);
                if (_IntialiserQuestion != null)
                {
                    return _IntialiserQuestion;
                }
            }
            return null;
        }

        public string CheckForDifficultyandMaxQuestions() 
        {

            string _QuestionToReturn = null;
            string _DifficultyInitialiseQuestion = CheckDifficultyIsSet();
            string _MaxQuestionInitialiseQuestion = CheckMaxQuestionsIsSet();

            if (_DifficultyInitialiseQuestion != null)
            {
                _QuestionToReturn = _DifficultyInitialiseQuestion;
            }
            else if (_MaxQuestionInitialiseQuestion != null)
            {
                _QuestionToReturn = _MaxQuestionInitialiseQuestion;
            }
            return _QuestionToReturn;
        }

        public string AskQuestion()
        {
            __question._GenerateQuestion(__difficultyData.__Value);
            return (__question.DisplayQuestion());

        }

        public QuizOutput GetQuestionAndSubmitLastAnswer(string inputString) {
            __UserInput = inputString;
            QuizOutput _quizOutput = new QuizOutput();
            if (__QuestionCounter < __maxQuestionData.__Value)
            {
                _quizOutput.__QuestionTextString = AskQuestion();
                if (!__IsThisTheFirstQuestion)
                {
                    _quizOutput.__AnswerTextString = SubmitLastAnswer();
                }
            }
            else if (__QuestionCounter != 0)
            {
                _quizOutput.__AnswerTextString = SubmitLastAnswer();
                _quizOutput.__QuestionTextString = ResultsToDisplay();
            }
            __lastQuestion.CopyDataFromCurrentQuestion(__question);
            __QuestionCounter++;
            return _quizOutput;
        }

        public string InterperateCorrectOrIncorrectFromResult()
        {
            string _TextToDisplay = null;
            if (__Result == 1)
            {
                _TextToDisplay = "Last Answer was CORRECT!";
            }
            else if (__Result == 0)
            {
                _TextToDisplay = "Last Answer was INCORRECT!";
            }
            return _TextToDisplay;
        }

        public string SubmitLastAnswer() 
        {
            __Result = __answer.CheckIfUserAnswerIsCorrect(__UserInput, __lastQuestion);
            __Total += __Result;
            string _answerTextString = InterperateCorrectOrIncorrectFromResult();

            return _answerTextString;
        }

        public void CheckThisIsTheFirstQuestion()
        {
            if (__lastQuestion.__QuestionToAsk == null)
            {
                __IsThisTheFirstQuestion = true;
            }
            else
            {
                __IsThisTheFirstQuestion = false;
            }
        }

        public void CheckEndOfQuiz()
        {
            if (__QuestionCounter > __maxQuestionData.__Value && __QuestionCounter != 0)
            {
                ResetVariables();
            }
        }

        private void ResetVariables() 
        {
            __QuestionCounter = 0;
            __difficultyData.__IsInitiated = false;
            __maxQuestionData.__IsInitiated = false;
        }


        private string ResultsToDisplay()
        {
            return($"You scored: {__Total} out of a total: {__maxQuestionData.__Value}");
        }

    }
}
