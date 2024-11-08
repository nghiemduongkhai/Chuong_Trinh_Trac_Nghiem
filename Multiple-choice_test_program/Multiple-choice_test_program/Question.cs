using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    public abstract class Question
    {
        [XmlElement("Id")]
        private int id;
        [XmlElement("QuestionText")]
        private string questionText;
        public int Id { get => id; set => id = value; }
        public string QuestionText { get => questionText; set => questionText = value; }
        public Question() { }
        public Question(int id, string questionText) 
        { 
            this.id = id;
            this.questionText = questionText;
        }
        public abstract void DisplayQuestion(Label questionLabel, List<RadioButton> radioButtons);
    }
}
