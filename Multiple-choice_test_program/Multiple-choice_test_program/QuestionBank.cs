using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class QuestionBank
    {
        private List<Question> questions;
        public List<Question> Questions { get => questions; set => questions = value; }
        public QuestionBank()
        {
            Questions = new List<Question>();
        }
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
        public List<Question> GetQuestions()
        {
            return Questions;
        }
    }
}
