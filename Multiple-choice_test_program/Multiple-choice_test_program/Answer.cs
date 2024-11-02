using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class Answer
    {
        private string correctAnswer;
        public string CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
        public Answer(string correctAnswer)
        {
            CorrectAnswer = correctAnswer;
        }
    }
}
