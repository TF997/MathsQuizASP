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
        private LastQuestion lastQuestion = new LastQuestion();
        public StateInitialiserBooleans stateInitialiserBooleans = new StateInitialiserBooleans();
        public DifficultyData difficultyData = new DifficultyData();
        private int total = 0;
        private int maxQuestions;
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
            string initialiseQuestion = checkForDifficultyandMaxQuestions(inputString);
            stateInitialiserBooleans = state.initaliseQuizStates(lastQuestion.question, maxQuestions);

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

            if (!stateInitialiserBooleans.ismaxQuestionsInitiated && difficultyData.isDifficultyInitiated)
            {
                string initialiseQuestion = initialise.getMaxQuestions(ref inputString, ref stateInitialiserBooleans.ismaxQuestionsInitiated, ref maxQuestions, difficultyData.isDifficultyInitiated);
                if (stateInitialiserBooleans.ismaxQuestionsInitiated)
                {
                    inputString = null;
                }
                if (initialiseQuestion != null)
                {
                    return initialiseQuestion;
                }
            }
            return null;
        }

        public void reallocateValuesFromLastSession(LastSession lastSession) 
        {
            lastQuestion = lastSession.lastQuestion;
            difficultyData.difficulty = lastSession.difficulty;
            maxQuestions = lastSession.maxQuestions;
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
            if (questionCounter < maxQuestions)
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
            if (questionCounter > maxQuestions && questionCounter != 1)
            {
                resetVariables();
            }
            else
            {
                state.saveQuiz(question, difficultyData.difficulty, maxQuestions, questionCounter, total);
            }
        }

        private void resetVariables() 
        {
            questionCounter = 1;
            difficultyData.isDifficultyInitiated = false;
            stateInitialiserBooleans.ismaxQuestionsInitiated = false;
            stateInitialiserBooleans.needRefresh = true;
        }


        private string resultsToDisplay()
        {
            return($"You scored: {total} out of a total: {maxQuestions}");
        }

    }
}
