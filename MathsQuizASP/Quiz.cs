using System;

namespace MathsQuiz
{
    class Quiz
    {
        public Question question = new Question();
        FileWriter file = new FileWriter();
        Answer answer = new Answer();
        private int total = 0;
        private int maxQuestions;
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

        public int getResult(string question, int firstNum, int secondNum, int opIndex, int opIndexTwo, bool extraOp, int userAnswer)
        {
           return(answer.compareAnswer(question, firstNum, secondNum, opIndex, opIndexTwo, extraOp, userAnswer));
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

        private int getDifficulty()
        {
            Console.WriteLine("Select difficulty");
            Console.WriteLine("[1] EASY (+,-,*,/)");
            Console.WriteLine("[2] Medium (*,/,^,√)");
            Console.WriteLine("[3] Hard (+,-,*,/,^,√) 25% chance of 3 operators");
            return (int.Parse(Console.ReadLine()));
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
