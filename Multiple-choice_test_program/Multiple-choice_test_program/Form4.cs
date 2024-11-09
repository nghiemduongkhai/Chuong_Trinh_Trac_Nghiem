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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            BindDataToGrid();
            this.FormClosed += Form4_FormClosed;
        }
        // phương thức gán dữ liệu vào bảng Data
        private void BindDataToGrid()
        {
            Form3 form3 = new Form3();
            List<ExamRecord> examRecords = form3.LoadExamRecords();  // Load dữ liệu
            dataGridView1.DataSource = examRecords;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            form1.Location = Location;
            Hide();
        }
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
