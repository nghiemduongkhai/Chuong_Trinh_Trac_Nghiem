using System;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    [Serializable]
    public class ExamRecord
    {
        public string TestDate { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Score { get; set; }
        public ExamRecord() { }
        public ExamRecord(string testDate, string name, string category, string score)
        {
            Name = name;
            Score = score;
            TestDate = testDate;
            Category = category;
        }
    }
}