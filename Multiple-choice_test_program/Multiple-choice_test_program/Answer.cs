using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    public class Answer
    {
        [XmlElement("CorrectAnswer")]
        private string correctAnswer;
        [XmlElement("QuestionId")]
        private int questionId;
        public string CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public Answer() { }
        public Answer(string correctAnswer, int questionId)
        {
            this.correctAnswer = correctAnswer;
            this.questionId = questionId;
        }
        public bool IsCorrect(Selection selection)
        {
            return selection.QuestionId == QuestionId && selection.SelectedAnswer == CorrectAnswer;
        }
    }
}
