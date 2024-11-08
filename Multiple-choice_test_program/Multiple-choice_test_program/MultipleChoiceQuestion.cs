using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    public class MultipleChoiceQuestion : Question
    {
        [XmlArray("Choices")] 
        [XmlArrayItem("Choice")]
        private List<string> choices;
        [XmlElement("CorrectAnswer")]
        private Answer correctAnswer;
        public List<string> Choices { get => choices; set => choices = value; }
        public Answer CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
        public MultipleChoiceQuestion() { }
        public MultipleChoiceQuestion(int id, string questionText, List<string> choices, string correctAnswer)
        : base(id, questionText)
        {
            Choices = choices;
            CorrectAnswer = new Answer(correctAnswer, id);
        }
        public bool CheckAnswer(Selection selection)
        {
            return CorrectAnswer.IsCorrect(selection);
        }
        public override void DisplayQuestion(Label questionLabel, List<RadioButton> radioButtons)
        {
            questionLabel.Text = QuestionText;
            for (int i = 0; i < Choices.Count; i++)
            {
                if (i < radioButtons.Count)
                {
                    radioButtons[i].Text = Choices[i];
                }
            }
        }
    }
}
