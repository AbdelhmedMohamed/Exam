using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Exam
    {
        public string ExamName { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(string examName)
        {
            ExamName = examName;
            Questions = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public void DisplayQuestions()
        {
            Console.WriteLine($"Exam: {ExamName}");
            foreach (var question in Questions)
            {
                question.Display();
                Console.WriteLine();
            }
        }
    }

}
