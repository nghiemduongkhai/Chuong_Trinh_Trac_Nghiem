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
        private List<string> names;
        private List<int> countTests;
        public List<string> Names { get => names; set => names = value; }
        public List<int> CountTests { get => countTests; set => countTests = value; }
        public User()
        {
            names = new List<string>();
            countTests = new List<int>();
        }
        public void AddUser(string name)
        {
            names.Add(name);
            countTests.Add(0);
        }
        public void IncrementTestCount(int userIndex)
        {
            if (userIndex >= 0 && userIndex < countTests.Count)
            {
                countTests[userIndex]++;
            }
        }
        public void SaveUser(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(User));
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(stream, this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}");
            }
        }
        public static User LoadUser(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    User newUser = new User();
                    newUser.SaveUser(filePath);
                    return newUser;
                }
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(User));
                    return (User)serializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
                return null;
            }
        }
        public int GetUserIndex(string name)
        {
            return names.IndexOf(name);
        }
    }
}
