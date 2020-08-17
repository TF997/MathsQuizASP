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
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz();
            string InputString;
            InputString = Console.ReadLine();
            string initalisingQuestion = quiz.QuizSetup(InputString);
            if (initalisingQuestion != null)
            {
                Console.WriteLine(initalisingQuestion);
            }
            if (quiz.difficultyData.IsInitiated && quiz.maxQuestionData.IsInitiated)
            {
                QuizOutput quizOutput = quiz.GetQuestionAndSubmitLastAnswer(InputString,false);
                Console.WriteLine(quizOutput.QuestionTextString);
                Console.WriteLine(quizOutput.AnswerTextString);
            }
            quiz.CheckEndOfQuiz();
        }
    }
}

