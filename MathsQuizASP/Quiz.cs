using System;

namespace MathsQuiz
{
    class Quiz
    {
        public Question question = new Question();
        FileWriter file = new FileWriter();
        Answer answer = new Answer();
        public LastQuestion lastQuestion = new LastQuestion();
        private int total = 0;
        public int maxQuestions = -1;
        public int questionCounter = 0;
        public int difficulty;
        private int result;
        
        //file.createfile needed
        
        public Question getQuestion()
        {
            return question;
        }

        public string askQuestion()
        {
            question.generateQuestion(difficulty);
            return (question.displayQuestion());

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
