using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Tạo danh sách câu hỏi
            List<MultipleChoiceQuestion> questions = new List<MultipleChoiceQuestion>
        {
            new MultipleChoiceQuestion(1, "What is the capital of France?", new List<string> { "Paris", "London", "Berlin", "Madrid" }, "Paris"),
            new MultipleChoiceQuestion(2, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(3, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(4, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(5, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(6, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(7, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(8, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(9, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(10, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(11, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(12, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(13, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(14, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(15, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(16, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(17, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(18, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(19, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new MultipleChoiceQuestion(20, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4")
        };

            // Tạo đối tượng XmlSerializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<MultipleChoiceQuestion>), new XmlRootAttribute("Questions"));

            // Ghi vào file XML
            using (FileStream stream = new FileStream("questions.xml", FileMode.Create))
            {
                serializer.Serialize(stream, questions);
            }

            Console.WriteLine("XML file has been created successfully!");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
