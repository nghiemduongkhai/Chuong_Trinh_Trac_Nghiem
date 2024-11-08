using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    public class QuestionBank
    {
        [XmlArray("Questions")]
        [XmlArrayItem("MultipleChoiceQuestion")]
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
        public List<Question> GetQuestions(int startId, int endId)
        {
            List<Question> result = new List<Question>();
            // Duyệt qua tất cả câu hỏi và chỉ thêm câu hỏi có Id trong khoảng từ startId đến endId
            foreach (Question question in Questions)
            {
                if (question.Id >= startId && question.Id <= endId)
                {
                    result.Add(question);
                }
            }
            return result;
        }
        public void LoadQuestionsFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<MultipleChoiceQuestion>), new XmlRootAttribute("Questions"));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                List<MultipleChoiceQuestion> loadedQuestions = (List<MultipleChoiceQuestion>)serializer.Deserialize(stream);
                foreach (MultipleChoiceQuestion question in loadedQuestions)
                {
                    AddQuestion(question);
                }
            }
        }
    }
}
