using System;
using MathsQuizASP;
namespace MathsQuiz
{
    class Quiz
    {
        public Question question = new Question();
        FileWriter file = new FileWriter();
        Answer answer = new Answer();
        public OutputWriter outputWriter = new OutputWriter();
        public LastQuestion lastQuestion = new LastQuestion();
        private int total = 0;
        private int maxQuestions = -1;
        private int questionCounter = 1;
        private int difficulty = 0;
        private int result;
        private bool isDifficultyInitiated = false;
        private bool ismaxQuestionsInitiated = false;
        private bool needRefresh = true;
        private int userAnswer = 0;
        private int questionResult;
        public Question getQuestion()
        {
            file.createFile();
            return question;
        }

        public void loadQuiz() 
        {
            file.loadQuizStates(ref lastQuestion, ref difficulty, ref maxQuestions, ref questionCounter);
        }

        public void resetQuiz()
        {
            file.deleteFiles();
        }

        public void saveQuiz()
        {
            file.saveQuizStates(question, difficulty, maxQuestions, questionCounter);
        }

        public string askQuestion()
        {
            question.generateQuestion(difficulty);
            return (question.displayQuestion());

        }

        public void initaliseQuizStates()
        {
            loadQuiz();
            if (lastQuestion.question != null)
            {
                needRefresh = false;
            }
            if (difficulty > 0)
            {
                isDifficultyInitiated = true;
            }
            if (maxQuestions > 0)
            {
                ismaxQuestionsInitiated = true;
            }
        }

        public string getUninitialisedDifficultyandMaxQuestions(ref string inputString)
        {
            string InitialisingQuestion = null;
            if (!isDifficultyInitiated)
            {
                InitialisingQuestion = getDifficulty(ref inputString);
                if (InitialisingQuestion != null)
                {
                    return InitialisingQuestion;
                }

            }
            if (!ismaxQuestionsInitiated && isDifficultyInitiated)
            {
                InitialisingQuestion = getMaxQuestions(ref inputString);
                if (InitialisingQuestion != null)
                {
                    return InitialisingQuestion;
                }
            }
            return InitialisingQuestion;
        }

        public string getMaxQuestions(ref string inputString)
        {
            if (!ismaxQuestionsInitiated && inputString != null)
            {
                maxQuestions = int.Parse(inputString);
                ismaxQuestionsInitiated = true;
                inputString = null;
            }
            else if(!ismaxQuestionsInitiated && isDifficultyInitiated)
            {
                return "How many questions?";
            }
            return null;
        }

        public string getDifficulty(ref string inputString)
        {
            if (!isDifficultyInitiated && inputString != null)
            {
                difficulty = int.Parse(inputString);
                isDifficultyInitiated = true;
                inputString = null;
            }
            else if (!isDifficultyInitiated)
            {
                return "Difficulty?";
            }
            return null;
        }

        public void getAnswer(string userAnswerString)
        {
            userAnswer = int.Parse(userAnswerString);
        }

        public void mainLoop(string inputString)
        {
            if(isDifficultyInitiated && ismaxQuestionsInitiated)
            {
                (string questionTextString, string answerTextString) = getQuestionAndAnswer(inputString);
                outputWriter.writeQuestion(questionTextString);
                outputWriter.writeAnswer(answerTextString);
            }
        }

        public void askInitialisingQuestions(string inputString)
        {
            string initalisingQuestion = getUninitialisedDifficultyandMaxQuestions(ref inputString);
            if (initalisingQuestion != null)
            {
                outputWriter.writeQuestion(initalisingQuestion);

            }
        }

        public Tuple<string,string> getQuestionAndAnswer(string inputString) {
            string questionTextString = null;
            string answerTextString = null;
            if (questionCounter < maxQuestions)
            {
                questionTextString = askQuestion();
                if (!needRefresh)
                {
                    answerTextString = checkAnswerAndDisplay(inputString);
                }
            }
            else if (questionCounter != 1)
            {
                answerTextString = checkAnswerAndDisplay(inputString);
                questionTextString = "Quiz Completed!";
            }
            return new Tuple<string, string>(questionTextString, answerTextString);
        }


        public string displayAnswer()
        {
            if (questionResult == 1)
            {
                return "CORRECT!";
            }
            else if (questionResult == 0)
            {
                return "INCORRECT!";
            }
            return null;
        }

        public void checkEndOfQuizOrSave()
        {
            if (questionCounter > maxQuestions && questionCounter != 1)
            {
                resetQuiz();
                questionCounter = 1;
                isDifficultyInitiated = false;
                ismaxQuestionsInitiated = false;
                needRefresh = true;
            }
            else
            {
                saveQuiz();
            }
        }

        public string checkAnswerAndDisplay(string inputString) {
            getAnswer(inputString);
            questionResult = getResult(userAnswer);
            string correctOrIncorrect = displayAnswer();
            questionCounter++;
            return correctOrIncorrect;
        }


        public int getResult(int userAnswer)
        {
           return(answer.compareAnswer(lastQuestion, userAnswer));
        }

        public void addToTotalScore()
        {
            total += result;
        }

        public void addQuestionToFile(int questionNumber)
        {
            file.writeQuestionToFile(question, questionNumber, answer, result);
        }

        public int getAmountOfQuestions()
        {
            Console.WriteLine("Amount of questions?");
            maxQuestions = (int.Parse(Console.ReadLine()));
            return maxQuestions;
        }

        public void generateResults()
        {
            showResults();
            writeResultsToFile();
        }

        private void writeResultsToFile()
        {
            file.writeTotalToFile(total, maxQuestions);
        }

        private void showResults()
        {
            Console.Write("You scored: " + total + " out of a total: " + maxQuestions);
        }

    }
}
