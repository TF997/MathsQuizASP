using MathsQuiz;
namespace MathsQuizUI
{
    public class LastSession
    {
        public LastQuestion LastSessionQuestion { get; set; } = new LastQuestion(); 
        public int Difficulty { get; set; }
        public int MaxQuestions { get; set; }
        public int QuestionCounter { get; set; } = 1; 
        public int Total { get; set; }
    }
}