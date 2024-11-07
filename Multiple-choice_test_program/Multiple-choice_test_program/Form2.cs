using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Multiple_choice_test_program
{
    public partial class Form2 : Form
    {
        private Time time;
        private Dictionary<int, int> selectedAnswers = new Dictionary<int, int>();
        private Button selectedQuestionButton;
        private int currentQuestion = 0;
        public string NameUser { get; set; }
        public Form2()
        {
            InitializeComponent();
            time = new Time(label2);
            time.Start();
            // Đăng ký sự kiện CheckedChanged cho tất cả các RadioButton
            radioButton1.CheckedChanged += AnswerSelected;
            radioButton2.CheckedChanged += AnswerSelected;
            radioButton3.CheckedChanged += AnswerSelected;
            radioButton4.CheckedChanged += AnswerSelected;
            SelectQuestion(1, button1);
            time.TimeUp += OnTimeUp;
            this.FormClosed += Form2_FormClosed;
        }
        public string SelectedValue
        {
            get { return label4.Text; }
            set { label4.Text = value; } 
        }
        public string GetDate { get; set; }
        //
        private void button1_Click(object sender, EventArgs e)
        {
            SelectQuestion(1, button1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SelectQuestion(2, button2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SelectQuestion(3, button3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SelectQuestion(4, button4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SelectQuestion(5, button5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SelectQuestion(6, button6); 
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SelectQuestion(7, button7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            SelectQuestion(8, button8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            SelectQuestion(9, button9);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            SelectQuestion(10, button10);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            SelectQuestion(11, button11);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            SelectQuestion(12, button12);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            SelectQuestion(13, button13);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            SelectQuestion(14, button14);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            SelectQuestion(15, button15);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            SelectQuestion(16, button16);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            SelectQuestion(17, button17);
        }
        private void button18_Click(object sender, EventArgs e)
        {
            SelectQuestion(18, button18);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            SelectQuestion(19, button19);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            SelectQuestion(20, button20);
        }
        private void SelectQuestion(int questionNumber, Button questionButton)
        {
            label6.Text = questionNumber.ToString();
            currentQuestion = questionNumber;
            selectedQuestionButton = questionButton;
            ResetRadioButtons();
            RestoreSelectedAnswer();
            if (selectedAnswers.ContainsKey(currentQuestion))
            {
                selectedQuestionButton.BackColor = Color.Green;
            }
            else
            {
                selectedQuestionButton.BackColor = SystemColors.Control;
            }
        }
        private void ResetRadioButtons()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        private void RestoreSelectedAnswer()
        {
            if (selectedAnswers.TryGetValue(currentQuestion, out int answerIndex))
            {
                switch (answerIndex)
                {
                    case 0:
                        radioButton1.Checked = true;
                        break;
                    case 1:
                        radioButton2.Checked = true;
                        break;
                    case 2:
                        radioButton3.Checked = true;
                        break;
                    case 3:
                        radioButton4.Checked = true;
                        break;
                }
            }
        }
        private void AnswerSelected(object sender, EventArgs e)
        {
            if (currentQuestion > 0)
            {
                if (radioButton1.Checked)
                    selectedAnswers[currentQuestion] = 0; // Lưu lại đáp án A cho câu hỏi hiện tại
                else if (radioButton2.Checked)
                    selectedAnswers[currentQuestion] = 1; // Lưu lại đáp án B cho câu hỏi hiện tại
                else if (radioButton3.Checked)
                    selectedAnswers[currentQuestion] = 2; // Lưu lại đáp án C cho câu hỏi hiện tại
                else if (radioButton4.Checked)
                    selectedAnswers[currentQuestion] = 3; // Lưu lại đáp án D cho câu hỏi hiện tại

                selectedQuestionButton.BackColor = Color.Green; // Đổi màu nút câu hỏi đã trả lời
            }
        }
        //
        private void button21_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn nộp bài !", "Xác Nhận", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                time.Stop();
                string elapsedTime = time.GetElapsedTime();
                Form3 form3 = new Form3();
                form3.SetName(NameUser);
                form3.SetCategory(SelectedValue);
                form3.SetDate(GetDate);
                form3.ElapsedTime = elapsedTime;
                form3.Show();
                form3.Location = Location;
                Hide();
            }
            else if (result == DialogResult.Cancel)
            {
                // Người dùng đã chọn Cancel
            }
        }
        private void OnTimeUp()
        {
            string elapsedTime = time.GetElapsedTime();
            Form3 form3 = new Form3();
            form3.SetName(NameUser);
            form3.SetCategory(SelectedValue);
            form3.SetDate(GetDate);
            form3.ElapsedTime = elapsedTime;
            form3.Show();
            form3.Location = Location;
            Hide(); 
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Đóng toàn bộ chương trình
        }
    }
}
