using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    [Serializable]
    public class User
    {
        private string name;
        private List<string> names;
        private List<int> countTests;
        public string Name { get => name; set => name = value; }
        public List<string> Names { get => names; set => names = value; }
        public List<int> CountTests { get => countTests; set => countTests = value; }
        public User()
        {
            names = new List<string>();
            countTests = new List<int>();
        }
        public User(string name)
        {

        }
        public void IncrementTestCount(int userIndex)
        {
            if (userIndex >= 0 && userIndex < countTests.Count)
            {
                countTests[userIndex]++;
            }
        }
        public int GetUserIndex(string name)
        {
            return names.IndexOf(name);
        }
    }
}
