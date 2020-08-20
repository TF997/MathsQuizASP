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
                if (quiz.__difficultyData.__IsInitiated && quiz.__maxQuestionData.__IsInitiated)
                {
                    QuizOutput quizOutput = quiz.GetQuestionAndSubmitLastAnswer(InputString);
                    Console.WriteLine(quizOutput.__AnswerTextString);
                    Console.WriteLine(quizOutput.__QuestionTextString);
                }
                quiz.CheckEndOfQuiz();
            }
        }
    }
}

