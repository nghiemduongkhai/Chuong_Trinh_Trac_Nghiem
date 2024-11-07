using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class MultipleChoiceQuestion : Question
    {
        private List<string> choices;
        private Answer correctAnswer;
        public List<string> Choices { get => choices; set => choices = value; }
        public Answer CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
        public MultipleChoiceQuestion(int id, string questionText, List<string> choices, string correctAnswer)
        : base(id, questionText)
        {
            Choices = choices;
            CorrectAnswer = new Answer(correctAnswer);
        }
        public override void DisplayQuestion()
        {
            Console.WriteLine(QuestionText);
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }
    }
}
