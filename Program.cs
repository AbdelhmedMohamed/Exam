namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Choose the exam type
            Console.WriteLine("Select the type of exam:");
            Console.WriteLine("1. Final Exam");
            Console.WriteLine("2. Practical Exam");
            int examTypeChoice = int.Parse(Console.ReadLine());

            string examName = examTypeChoice == 1 ? "Final Exam" : "Practical Exam";
            Exam exam = new Exam(examName);

            // Get the number of questions
            Console.WriteLine("How many questions would you like to add?");
            int numOfQuestions = int.Parse(Console.ReadLine());

            // Add questions
            for (int i = 0; i < numOfQuestions; i++)
            {
                Console.WriteLine($"Enter details for question {i + 1}:");

                Console.WriteLine("Header:");
                string header = Console.ReadLine();

                Console.WriteLine("Body:");
                string body = Console.ReadLine();

                Console.WriteLine("Mark:");
                int mark = int.Parse(Console.ReadLine());

                Console.WriteLine("Select the type of question:");
                Console.WriteLine("1. True/False");
                Console.WriteLine("2. MCQ");
                int questionTypeChoice = int.Parse(Console.ReadLine());

                Question question = null;

                switch (questionTypeChoice)
                {
                    case 1:
                        // Handling True/False questions
                        Console.WriteLine("Correct Answer:");
                        Console.WriteLine("1. True");
                        Console.WriteLine("2. False");
                        int correctAnswerChoice = int.Parse(Console.ReadLine());

                        var correctAnswerTrueFalse = new Answer(correctAnswerChoice, correctAnswerChoice == 1 ? "True" : "False");
                        question = new TrueOrFalseQuestion(header, body, mark, correctAnswerTrueFalse);
                        break;

                    case 2:
                        // Handling MCQ questions
                        Console.WriteLine("Enter the number of options:");
                        int numOptions = int.Parse(Console.ReadLine());

                        var options = new List<Answer>();
                        for (int j = 0; j < numOptions; j++)
                        {
                            Console.WriteLine($"Option {j + 1}:");
                            string optionText = Console.ReadLine();
                            options.Add(new Answer(j + 1, optionText));
                        }

                        Console.WriteLine("Correct Answer:");
                        foreach (var option in options)
                        {
                            Console.WriteLine($"{option.AnswerId}. {option.AnswerText}");
                        }
                        int correctOptionId = int.Parse(Console.ReadLine());
                        Answer correctOption = options.Find(option => option.AnswerId == correctOptionId);

                        question = new MCQQuestion(header, body, mark, options, correctOption);
                        break;

                    default:
                        Console.WriteLine("Invalid question type.");
                        continue;
                }

                // Add question to the exam
                exam.AddQuestion(question);

                // Display the added question
                Console.WriteLine("\nQuestion Added:");
                question.Display();
                Console.WriteLine();
            }

            // Display all questions
            Console.WriteLine("All Questions:");
            exam.DisplayQuestions();
        }
    }
}











