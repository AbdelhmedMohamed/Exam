using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        protected Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        public abstract void Display();
    }


    public class TrueOrFalseQuestion : Question
    {
        public Answer CorrectAnswer { get; set; }

        public TrueOrFalseQuestion(string header, string body, int mark, Answer correctAnswer)
            : base(header, body, mark)
        {
            CorrectAnswer = correctAnswer;
        }

        public override void Display()
        {
            Console.WriteLine($"{Header}: {Body} (True/False)");
        }
    }

    public class MCQQuestion : Question
    {
        public List<Answer> Options { get; set; }
        public Answer CorrectAnswer { get; set; }

        public MCQQuestion(string header, string body, int mark, List<Answer> options, Answer correctAnswer)
            : base(header, body, mark)
        {
            Options = options;
            CorrectAnswer = correctAnswer;
        }

        public override void Display()
        {
            Console.WriteLine($"{Header}: {Body}");
            foreach (var option in Options)
            {
                Console.WriteLine($"{option.AnswerId}. {option.AnswerText}");
            }
        }
    }











}
