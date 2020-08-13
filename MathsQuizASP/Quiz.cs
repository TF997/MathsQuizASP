using System;
using MathsQuizASP;
namespace MathsQuiz
{
    public class Quiz
    {
        private ManageState state = new ManageState();
        private Question question = new Question();
        private Answer answer = new Answer();
        private LastQuestion lastQuestion = new LastQuestion();
        private int total = 0;
        private int maxQuestions = -1;
        private int questionCounter = 1;
        private int difficulty = 0;
        public bool isDifficultyInitiated  = false;
        public bool ismaxQuestionsInitiated = false;
        private bool needRefresh = true;
       
        public Question getQuestion()
        {
            return question;
        }

        public string quizSetup(string inputString) 
        {
            state.initaliseQuizStates(ref  lastQuestion, ref  difficulty, ref  maxQuestions, ref  questionCounter, ref  needRefresh, ref  isDifficultyInitiated, ref  ismaxQuestionsInitiated, ref total);
            return state.getUninitialisedDifficultyandMaxQuestions(ref inputString, ref isDifficultyInitiated, ref ismaxQuestionsInitiated, ref difficulty, ref maxQuestions);
        }

        public string askQuestion()
        {
            question.generateQuestion(difficulty);
            return (question.displayQuestion());

        }

        public Tuple<string,string> getQuestionAndAnswer(string inputString) {
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
                questionCounter = 1;
                isDifficultyInitiated = false;
                ismaxQuestionsInitiated = false;
                needRefresh = true;
            }
            else
            {
                state.saveQuiz(question, difficulty, maxQuestions, questionCounter, total);
            }
        }

        public int getAmountOfQuestions()
        {
            Console.WriteLine("Amount of questions?");
            maxQuestions = (int.Parse(Console.ReadLine()));
            return maxQuestions;
        }

        private string resultsToDisplay()
        {
            return($"You scored: {total} out of a total: {maxQuestions}");
        }

    }
}
