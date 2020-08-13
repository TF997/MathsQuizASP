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
        private int total = 0;
        private int maxQuestions = -1;
        private int questionCounter = 1;
        private int difficulty = 0;
        private bool needRefresh = true;
        public bool isDifficultyInitiated = false;
        public bool ismaxQuestionsInitiated = false;

        public Question getQuestion()
        {
            return question;
        }

        public string quizSetup(string inputString) 
        {
            string initialiseQuestion = null;
            state.initaliseQuizStates(ref  lastQuestion, ref  difficulty, ref  maxQuestions, ref  questionCounter, ref  needRefresh, ref  isDifficultyInitiated, ref  ismaxQuestionsInitiated, ref total);
            if (!isDifficultyInitiated)
            {
                initialiseQuestion = initialise.Difficulty(ref inputString, ref isDifficultyInitiated, ref difficulty);
            }

            if (!ismaxQuestionsInitiated && isDifficultyInitiated)
            {
                initialiseQuestion = initialise.MaxQuestions(ref inputString, ref isDifficultyInitiated, ref ismaxQuestionsInitiated, ref maxQuestions);
            }

            return initialiseQuestion;
        }

        public string askQuestion()
        {
            question.generateQuestion(difficulty);
            return (question.displayQuestion());

        }

        public Tuple<string,string> getQuestionAndSubmitAnswer(string inputString) {
            string questionTextString = null;
            string answerTextString = null;
            if (questionCounter < maxQuestions)
            {
                questionTextString = askQuestion();
                if (!needRefresh)
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
                state.saveQuiz(question, difficulty, maxQuestions, questionCounter, total);
            }
        }

        private void resetVariables() 
        {
            questionCounter = 1;
            isDifficultyInitiated = false;
            ismaxQuestionsInitiated = false;
            needRefresh = true;
        }


        private string resultsToDisplay()
        {
            return($"You scored: {total} out of a total: {maxQuestions}");
        }

    }
}
