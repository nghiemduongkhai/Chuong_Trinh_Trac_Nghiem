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
    public partial class Form3 : Form
    {
        private List<ExamRecord> examRecords = new List<ExamRecord>();
        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResult.xml");
        private string elapsedTime;
        public string ElapsedTime
        {
            get => elapsedTime;
            set
            {
                elapsedTime = value;
                label10.Text = $"{elapsedTime}";
            }
        }
        public void SaveExamRecord()
        {
            // Tạo đối tượng ExamRecord mới từ các label
            ExamRecord record = new ExamRecord(
                label9.Text,   // Date
                label7.Text,   // Name
                label8.Text,   // Category
                label11.Text   // Score
            );

            // Lấy danh sách các ExamRecord đã lưu từ file
            List<ExamRecord> examRecords = LoadExamRecords();

            // Thêm bản ghi mới vào đầu danh sách
            examRecords.Insert(0, record);

            // Mở file và ghi lại danh sách các ExamRecord vào file
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer sr = new XmlSerializer(typeof(List<ExamRecord>));
                sr.Serialize(fs, examRecords);
            }
        }
        public List<ExamRecord> LoadExamRecords()
        {
            List<ExamRecord> examRecords = new List<ExamRecord>();

            // Kiểm tra nếu file không tồn tại
            if (!File.Exists(filePath))
            {
                return examRecords;  // Trả về danh sách trống nếu file không tồn tại
            }

            // Đọc file và deserialize dữ liệu vào examRecords
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ExamRecord>));
                examRecords = (List<ExamRecord>)serializer.Deserialize(fs);
            }

            return examRecords;
        }

        public Form3()
        {
            InitializeComponent();
            this.FormClosed += Form3_FormClosed;
        }
        public void SetName(string name)
        {
            label7.Text = name; // Hiển thị tên trong Label
        }
        public void SetCategory(string Category) 
        { 
            label8.Text = Category;
        }
        public void SetDate(string date) 
        {
            label9.Text = date;
        }
        public void SetScore(string score) 
        { 
            label11.Text = score;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveExamRecord();
            Form1 form1 = new Form1();
            form1.Show();
            form1.Location = Location;
            Hide();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Đóng toàn bộ chương trình
        }
    }
}
