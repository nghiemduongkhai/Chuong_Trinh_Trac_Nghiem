using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class ScoreCalculator
    {
        public float CalculateScore(int correctCount, int totalQuestions)
        {
            return (float)correctCount / totalQuestions * 100;
        }
    }
}
