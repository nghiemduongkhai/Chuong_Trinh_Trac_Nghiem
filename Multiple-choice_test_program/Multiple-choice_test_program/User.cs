using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    [Serializable]
    public class User
    {
        private string name;
        private int countTest;
        public string Name { get => name; set => name = value; }
        public int CountTest { get => countTest; set => countTest = value; }
        public User()
        {
        }
        public User(string name)
        {
            Name = name;
            CountTest = 0;
        }
        public void IncrementTestCount()
        {
            CountTest++;
        }
        public void SaveUser(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
        }
        public static User LoadUser(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (User)serializer.Deserialize(stream);
            }
        }
    }
}
