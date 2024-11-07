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
        private bool isInitializing = true;
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataUser.xml");
        public Form1()
        {
            InitializeComponent();
            timerDate.Tick += new EventHandler(timerDate_Tick);
            timerDate.Start();
            LoadCategories();
            isInitializing = false;
            // Deserialize User từ file XML
            currentUser = DeserializeFromXML(filePath) as User;
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
        private void SerializeToXML(object data, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            XmlSerializer sr = new XmlSerializer(typeof(User));
            sr.Serialize(fs, data);
            fs.Close();
        }
        private object DeserializeFromXML(string filePath)
        {
            // Kiểm tra xem tệp có tồn tại không
            if (!File.Exists(filePath))
            {
                // Tạo tệp mới với User mặc định nếu tệp không tồn tại
                User newUser = new User(""); // Hoặc có thể để tên trống
                SerializeToXML(newUser, filePath); // Lưu User vào tệp
                return newUser; // Trả về User mặc định
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    XmlSerializer sr = new XmlSerializer(typeof(User));
                    object result = sr.Deserialize(fs);
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
                    return null; // Trả về null trong trường hợp có lỗi
                }
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Lưu đối tượng currentUser vào file XML
            if (currentUser != null)
            {
                SerializeToXML(currentUser, filePath);  
            }
            Application.Exit();
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
                    // Hoặc thực hiện các thao tác khác dựa trên categoryId và categoryName
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
                form2.NameUser = userName;
                form2.GetDate = DateTime.Now.ToString("dd/MM/yyyy");
                form2.Show();
                form2.Location = Location;
                Hide();
            }
            else if (result == DialogResult.Cancel)
            {
                // Người dùng đã chọn Cancel
            }
        }
    }
}
