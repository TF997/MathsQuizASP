using System;
using MathsQuizASP;
namespace MathsQuiz
{
    public class Quiz
    {
        private Initialise initialise = new Initialise();
        private ManageState state = new ManageState();
        private Question question = new Question();
        private Answer answer = new Answer();
        public MaxQuestionData maxQuestionData = new MaxQuestionData();
        private LastQuestion lastQuestion = new LastQuestion();
        public StateInitialiserBooleans stateInitialiserBooleans = new StateInitialiserBooleans();
        public DifficultyData difficultyData = new DifficultyData();
        private int total = 0;
        private int questionCounter = 1;

        public Question getQuestion()
        {
            return question;
        }

        public string quizSetup(string inputString) 
        {
            LastSession lastSession = state.loadQuiz();
            reallocateValuesFromLastSession(lastSession);
            difficultyData.isDifficultyInitiated = checkDifficultyNeedsSetting();
            maxQuestionData.isMaxQuestionsInitiated = checkIfMaxQuestionsNeedsSetting();
            stateInitialiserBooleans = state.initaliseQuizStates(lastQuestion.question);
            string initialiseQuestion = checkForDifficultyandMaxQuestions(inputString);

            return initialiseQuestion;
        }

        public bool checkDifficultyNeedsSetting() 
        {
            if (difficultyData.difficulty > 0)
            {
                return true;
            }
            return false;
        }

        public bool checkIfMaxQuestionsNeedsSetting() 
        {
            if (maxQuestionData.MaxQuestions > 0)
            {
                return true;
            }
            return false;
        }

        public string checkForDifficultyandMaxQuestions(string inputString) 
        {
            if (!difficultyData.isDifficultyInitiated)
            {
                difficultyData = initialise.getDifficulty(inputString);
                if (difficultyData.isDifficultyInitiated)
                {
                    inputString = null;
                }
                if(difficultyData.initialiserQuestion != null)
                {
                    return difficultyData.initialiserQuestion;
                }
            }

            if (!maxQuestionData.isMaxQuestionsInitiated && difficultyData.isDifficultyInitiated)
            {
                maxQuestionData = initialise.getMaxQuestions(inputString, difficultyData.isDifficultyInitiated);
                if (maxQuestionData.isMaxQuestionsInitiated)
                {
                    inputString = null;
                }
                if (maxQuestionData.initialiserQuestion != null)
                {
                    return maxQuestionData.initialiserQuestion;
                }
            }
            return null;
        }

        public void reallocateValuesFromLastSession(LastSession lastSession) 
        {
            lastQuestion = lastSession.lastQuestion;
            difficultyData.difficulty = lastSession.difficulty;
            maxQuestionData.MaxQuestions = lastSession.maxQuestions;
            questionCounter = lastSession.questionCounter;
            total = lastSession.total;
        }

        public string askQuestion()
        {
            question.generateQuestion(difficultyData.difficulty);
            return (question.displayQuestion());

        }

        public Tuple<string,string> getQuestionAndSubmitAnswer(string inputString) {
            string questionTextString = null;
            string answerTextString = null;
            if (questionCounter < maxQuestionData.MaxQuestions)
            {
                questionTextString = askQuestion();
                if (!stateInitialiserBooleans.needRefresh)
                {
                    answerTextString = submitLastAnswer(inputString);
                }
            }
            else if (questionCounter != 1)
            {
                answerTextString = submitLastAnswer(inputString);
                questionTextString = resultsToDisplay();
            }
            return new Tuple<string, string>(questionTextString, answerTextString);
        }

        public string submitLastAnswer(string inputString) 
        {
            string answerTextString = answer.checkAnswerAndDisplay(inputString, lastQuestion);
            total += answer.questionResult;
            questionCounter++;

            return answerTextString;
        }

        public void checkEndOfQuizOrSave()
        {
            if (questionCounter > maxQuestionData.MaxQuestions && questionCounter != 1)
            {
                resetVariables();
            }
            else
            {
                state.saveQuiz(question, difficultyData.difficulty, maxQuestionData.MaxQuestions, questionCounter, total);
            }
        }

        private void resetVariables() 
        {
            questionCounter = 1;
            difficultyData.isDifficultyInitiated = false;
            maxQuestionData.isMaxQuestionsInitiated = false;
            stateInitialiserBooleans.needRefresh = true;
        }


        private string resultsToDisplay()
        {
            return($"You scored: {total} out of a total: {maxQuestionData.MaxQuestions}");
        }

    }
}
