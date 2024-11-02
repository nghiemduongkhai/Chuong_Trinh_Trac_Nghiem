using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class User
    {
        private string name;
        private int countTest;
        public string Name { get => name; set => name = value; }
        public int CountTest { get => countTest; set => countTest = value; }
        public User(string name)
        {
            Name = name;
            CountTest = 0;
        }
        public void IncrementTestCount()
        {
            CountTest++;
        }
    }
}
