using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    public partial class Form1 : Form
    {
        private User currentUser;
        private List<Category> categories;
        private QuestionBank questionBank;
        private Test test;
        private bool isInitializing = true;
        public Form1()
        {
            User user = new User();
            InitializeComponent();
            timerDate.Tick += new EventHandler(timerDate_Tick);
            timerDate.Start();
            LoadCategories();
            isInitializing = false;
            // Deserialize User từ file XML
            currentUser = GetLatestUser();
            // Nếu currentUser không null, hiển thị tên người dùng trong textBox
            if (currentUser != null)
            {
                textBox1.Text = currentUser.Name;
            }
            else
            {
                textBox1.Text = string.Empty; // Nếu không có User, ô nhập để trống
            }
            this.FormClosed += Form1_FormClosed;
        }
        private User GetLatestUser()
        {
            Form3 form3 = new Form3();
            List<ExamRecord> examRecords = form3.LoadExamRecords();

            if (examRecords.Count == 0)
            {
                return null;
            }
            ExamRecord latestRecord = examRecords[0];  // Giả sử bản ghi đầu tiên là mới nhất
            // Lặp qua danh sách và tìm bản ghi có TestDate mới nhất
            foreach (var record in examRecords)
            {
                // So sánh các ngày để tìm bản ghi mới nhất
                if (DateTime.Parse(record.TestDate) > DateTime.Parse(latestRecord.TestDate))
                {
                    latestRecord = record;
                }
            }
            return new User
            {
                Name = latestRecord.Name,
            };
        }
        private void LoadCategories()
        {
            // Khởi tạo danh sách các Category
            categories = new List<Category>     
            {
                new Category(0, "Chọn đề"),
                new Category(1, "Toán"),
                new Category(2, "Lý"),
                new Category(3, "Hóa"),
                new Category(4, "Sinh"),
                new Category(5, "Anh")        
            };
            // Gán danh sách vào ComboBox
            comboBox1.DataSource = categories;
            comboBox1.DisplayMember = "CategoryName"; // Hiển thị tên chủ đề
            comboBox1.ValueMember = "CategoryId";     // Lấy Id khi cần
        }
        private void timerDate_Tick(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                Category selectedCategory = comboBox1.SelectedItem as Category;
                if (selectedCategory != null && selectedCategory.CategoryId != 0)
                {
                    int categoryId = selectedCategory.CategoryId;
                    string categoryName = selectedCategory.CategoryName;
                    questionBank = new QuestionBank();
                    questionBank.LoadQuestionsFromXml("questions.xml");
                    List<Question> questions = null;
                    switch (selectedCategory.CategoryId)
                    {
                        case 1:
                            questions = questionBank.GetQuestions(1, 20);
                            break;
                        case 2:
                            questions = questionBank.GetQuestions(21, 40);
                            break;
                        case 3:
                            questions = questionBank.GetQuestions(41, 60);
                            break;
                        case 4:
                            questions = questionBank.GetQuestions(61, 80);
                            break;
                        case 5:
                            questions = questionBank.GetQuestions(81, 100);
                            break;
                        default:
                            break;
                    }
                    if (questions != null)
                    {
                        test = new Test($"{selectedCategory.CategoryName} Test", categories[selectedCategory.CategoryId], questions);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy tên từ TextBox
            string userName = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(userName))
            {
                // Gán tên cho User (khởi tạo mới hoặc cập nhật)
                if (currentUser == null)
                {
                    currentUser = new User(userName); // Tạo mới User nếu chưa có
                }
                else
                {
                    currentUser.Name = userName; // Cập nhật tên nếu User đã tồn tại
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên!");
                return;
            }
            if (!isInitializing)
            {
                Category selectedCategory = comboBox1.SelectedItem as Category;
                if (selectedCategory.CategoryId == 0)
                {
                    MessageBox.Show("Vui lòng chọn đề thi");
                    return;
                }
            }
            //Chuyen sang form 2
            DialogResult result = MessageBox.Show("Bạn sẽ bắt đầu thi !!", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Xử lý kết quả từ MessageBox
            if (result == DialogResult.OK)
            {
                Form2 form2 = new Form2();
                form2.SelectedValue = comboBox1.SelectedItem.ToString();
                form2.User = currentUser;
                form2.NameUser = userName;
                form2.GetDate = DateTime.Now.ToString("dd/MM/yyyy");
                form2.Test = test;
                form2.Show();
                form2.Location = Location;
                Hide();
            }
            else if (result == DialogResult.Cancel)
            {
                // Người dùng đã chọn Cancel
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            form4.Location = Location;
            Hide();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
