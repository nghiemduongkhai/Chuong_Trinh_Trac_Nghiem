using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class Selection
    {
        private string selectedAnswer;
        private int questionId;
        public string SelectedAnswer { get => selectedAnswer; set => selectedAnswer = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public Selection(string selectedAnswer, int questionId)
        {
            this.selectedAnswer = selectedAnswer;
            this.questionId = questionId;
        }
    }
}
