using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_choice_test_program
{
    public partial class Form1 : Form
    {
        private User currentUser;
        private List<Category> categories;
        private bool isInitializing = true;
        public Form1()
        {
            InitializeComponent();
            timerDate.Tick += new EventHandler(timerDate_Tick);
            timerDate.Start();
            LoadCategories();
            isInitializing = false;
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
