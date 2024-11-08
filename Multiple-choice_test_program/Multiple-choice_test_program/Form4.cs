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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.FormClosed += Form4_FormClosed;
        }
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Đóng toàn bộ chương trình
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            form1.Location = Location;
            Hide();
        }
    }
}
