using System;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    [Serializable]
    public class ExamRecord
    {
        private string testDate;
        private string name;
        private string category;
        private string score;
        public string TestDate { get => testDate; set => testDate = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Score { get => score; set => score = value; }
        public ExamRecord() { }
        public ExamRecord(string testDate, string name, string category, string score)
        {
            this.name = name;
            this.score = score;
            this.testDate = testDate;
            this.category = category;
        }
    }
}