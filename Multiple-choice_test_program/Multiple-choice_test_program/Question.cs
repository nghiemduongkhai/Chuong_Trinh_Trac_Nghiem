using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public abstract class Question
    {
        private int id;
        private string questionText;
        public int Id { get => id; set => id = value; }
        public string QuestionText { get => questionText; set => questionText = value; }
        public Question(int id, string questionText) 
        { 
            this.id = id;
            this.questionText = questionText;
        }
        public abstract void DisplayQuestion();
    }
}
