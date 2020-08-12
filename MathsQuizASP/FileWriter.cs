using System.IO;
using Newtonsoft.Json;

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

        public void deleteFiles()
        {
            File.Delete(@"C:\TEMP\LastQuestion.json");
            File.Delete(@"C:\TEMP\difficulty.json");
            File.Delete(@"C:\TEMP\maxQuestions.json");
            File.Delete(@"C:\TEMP\questionCounter.json");
        }

        public void loadQuizStates(ref LastQuestion lastQuestion, ref int difficulty, ref int maxQuestions, ref int questionCounter)
        {
            string toload;
            if (File.Exists(@"C:\TEMP\LastQuestion.json"))
            {
                toload = File.ReadAllText(@"C:\TEMP\LastQuestion.json");
                lastQuestion = JsonConvert.DeserializeObject<LastQuestion>(toload);
            }
            if (File.Exists(@"C:\TEMP\difficulty.json"))
            {
                toload = File.ReadAllText(@"C:\TEMP\difficulty.json");
                difficulty = JsonConvert.DeserializeObject<int>(toload);
            }
            if (File.Exists(@"C:\TEMP\maxQuestions.json"))
            {
                toload = File.ReadAllText(@"C:\TEMP\maxQuestions.json");
                maxQuestions = JsonConvert.DeserializeObject<int>(toload);
            }
            if (File.Exists(@"C:\TEMP\questionCounter.json"))
            {
                toload = File.ReadAllText(@"C:\TEMP\questionCounter.json");
                questionCounter = JsonConvert.DeserializeObject<int>(toload);
            }
        }

        public void saveQuizStates(Question question, int difficulty, int maxQuestions, int questionCounter)
        {
            string toSave = JsonConvert.SerializeObject(question);
            File.WriteAllText(@"C:\TEMP\LastQuestion.json", toSave);
            toSave = JsonConvert.SerializeObject(difficulty);
            File.WriteAllText(@"C:\TEMP\difficulty.json", toSave);
            toSave = JsonConvert.SerializeObject(maxQuestions);
            File.WriteAllText(@"C:\TEMP\maxQuestions.json", toSave);
            toSave = JsonConvert.SerializeObject(questionCounter);
            File.WriteAllText(@"C:\TEMP\questionCounter.json", toSave);
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
