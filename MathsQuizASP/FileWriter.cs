using System.IO;

namespace MathsQuiz
{
    class FileWriter
    {
        public void createFile()
        {
            using (StreamWriter writer = new StreamWriter(@"C:\TEMP\quiz.txt"))
            {
                writer.WriteLine("#### QUIZ REPORT ####");
            }
        }

        public void writeQuestionToFile(Question question, int questionNumber, Answer answer, int answerCorrect)
        {
            using (StreamWriter writer = File.AppendText(@"C:\TEMP\quiz.txt"))
            {
                questionNumber += 1;
                writer.WriteLine("");
                writer.WriteLine("##### QUESTION " + questionNumber + " #####");
                writer.WriteLine(question.question);
                writer.WriteLine("Your Answer: " + answer.userAnswer);
                writer.WriteLine("Actual Answer: " + question.trueAnswer);
                if (answerCorrect == 1)
                {
                    writer.WriteLine("Correct!");
                }
                else
                {
                    writer.WriteLine("Incorrect");
                }

            }
        }
        public void writeTotalToFile(int total, int maxQuestions)
        {
            using (StreamWriter writer = File.AppendText(@"C:\TEMP\quiz.txt"))
            {
                writer.WriteLine("");
                writer.WriteLine("Total Marks: " + total + "/" + maxQuestions);
            }
        }
    }
}
