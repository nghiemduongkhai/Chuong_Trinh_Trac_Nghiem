using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class Result
    {
        private Test test;
        private User user;
        private int correctCount;
        private float score;
        private DateTime dateTest;
        public Test Test { get => test; set => test = value; }
        public User User { get => user; set => user = value; }
        public int CorrectCount { get => correctCount; set => correctCount = value; }
        public float Score { get => score; set => score = value; }
        public DateTime DateTest { get => dateTest; set => dateTest = value; }
        public Result()
        {
        }
        public Result(Test test, User user, int correctCount, float score, DateTime dateTest)
        {
            this.test = test;
            this.user = user;   
            this.correctCount = correctCount;
            this.score = score;
            this.dateTest = dateTest;
        }
    }
}
