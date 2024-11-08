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
    public partial class Form3 : Form
    {
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
