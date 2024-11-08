using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class Test
    {
        private string title;
        private Category category;
        private int numberOfQuestions;
        private List<Question> questions;
        public string Title { get => title; set => title = value; }
        public List<Question> Questions { get => questions; set => questions = value; }

        public Test(string title, Category category, List<Question> questions)
        {
            this.title = title;
            this.category = category;
            this.questions = questions;
            numberOfQuestions = questions.Count;
        }
    }
}
