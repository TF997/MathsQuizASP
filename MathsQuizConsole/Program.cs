using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathsQuiz;

namespace MathsQuizConsole
{
    class Program
    {
        static void Main()
        {
            Quiz quiz = new Quiz();
            string InputString;
            Console.WriteLine("Press Enter To Start");
            while (true)
            {
                InputString = Console.ReadLine();
                string initalisingQuestion = quiz.QuizSetup(InputString);
                if (initalisingQuestion != null)
                {
                    Console.WriteLine(initalisingQuestion);
                }
                quiz.CheckThisIsTheFirstQuestion();
                if (quiz.difficultyData.IsInitiated && quiz.maxQuestionData.IsInitiated)
                {
                    QuizOutput quizOutput = quiz.GetQuestionAndSubmitLastAnswer(InputString);
                    Console.WriteLine(quizOutput.AnswerTextString);
                    Console.WriteLine(quizOutput.QuestionTextString);
                }
                quiz.CheckEndOfQuiz();
            }
        }
    }
}

