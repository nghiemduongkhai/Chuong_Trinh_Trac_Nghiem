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

namespace Multiple_choice_test_program
{
    public partial class Form2 : Form
    {
        private Time time;
        private int correctCount ;
        private Dictionary<int, int> selectedAnswers = new Dictionary<int, int>();
        private Button selectedQuestionButton;
        private MultipleChoiceQuestion question;
        private int currentQuestion = 0;
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataUser.xml");
        public string NameUser { get; set; }
        public User User { get; set; }
        public string SelectedValue
        {
            get { return label4.Text; }
            set { label4.Text = value; } 
        }
        public string GetDate { get; set; }
        public Test Test { get; set; }

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
            this.Load += new EventHandler(MainForm_Load);
            time.TimeUp += OnTimeUp;
            this.FormClosed += Form2_FormClosed;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }
        //
        private void GetQuestion(int i)
        { 
            // Lấy câu hỏi từ danh sách
            MultipleChoiceQuestion question = Test.Questions[i - 1] as MultipleChoiceQuestion;
            if (question != null)
            {
                List<RadioButton> radioButtons = new List<RadioButton> 
                {   
                    radioButton1, radioButton2, radioButton3, radioButton4
                };
                // Hiển thị câu hỏi và các lựa chọn
                question.DisplayQuestion(label8, radioButtons);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SelectQuestion(1, button1);
            GetQuestion(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SelectQuestion(2, button2);
            GetQuestion(2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SelectQuestion(3, button3);
            GetQuestion(3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SelectQuestion(4, button4);
            GetQuestion(4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SelectQuestion(5, button5);
            GetQuestion(5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SelectQuestion(6, button6);
            GetQuestion(6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SelectQuestion(7, button7);
            GetQuestion(7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            SelectQuestion(8, button8);
            GetQuestion(8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            SelectQuestion(9, button9);
            GetQuestion(9);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            SelectQuestion(10, button10);
            GetQuestion(10);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            SelectQuestion(11, button11);
            GetQuestion(11);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            SelectQuestion(12, button12);
            GetQuestion(12);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            SelectQuestion(13, button13);
            GetQuestion(13);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            SelectQuestion(14, button14);
            GetQuestion(14);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            SelectQuestion(15, button15);
            GetQuestion(15);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            SelectQuestion(16, button16);
            GetQuestion(16);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            SelectQuestion(17, button17);
            GetQuestion(17);
        }
        private void button18_Click(object sender, EventArgs e)
        {
            SelectQuestion(18, button18);
            GetQuestion(18);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            SelectQuestion(19, button19);
            GetQuestion(19);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            SelectQuestion(20, button20);
            GetQuestion(10);
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
                int selectedAnswerIndex = -1;
                if (radioButton1.Checked)
                    selectedAnswerIndex = 0; // Lưu lại đáp án A cho câu hỏi hiện tại
                else if (radioButton2.Checked)
                    selectedAnswerIndex = 1; // Lưu lại đáp án B cho câu hỏi hiện tại
                else if (radioButton3.Checked)
                    selectedAnswerIndex = 2; // Lưu lại đáp án C cho câu hỏi hiện tại
                else if (radioButton4.Checked)
                    selectedAnswerIndex = 3; // Lưu lại đáp án D cho câu hỏi hiện tại
                // Kiểm tra xem đã chọn đáp án hay chưa
                if (selectedAnswerIndex >= 0)  
                {
                    selectedAnswers[currentQuestion] = selectedAnswerIndex;
                    CheckAnswer(selectedAnswerIndex);

                    // Chỉ thay đổi màu của nút câu hỏi nếu đáp án đã được chọn
                    selectedQuestionButton.BackColor = Color.Green;
                }
            }
        }
        private void CheckAnswer(int selectedAnswerIndex)
        {
            // Lấy câu hỏi hiện tại
            MultipleChoiceQuestion currentQues = Test.Questions[currentQuestion - 1] as MultipleChoiceQuestion;

            if (currentQues != null)
            {
                // Lấy đáp án của câu hỏi
                string selectedAnswer = GetSelectedAnswerText(selectedAnswerIndex);
                // Kiểm tra xem đáp án có đúng không
                int categoryCurrentId = Test.Category.CategoryId;
                switch (categoryCurrentId)
                {
                    case 1:
                        break;
                    case 2:
                        currentQuestion += 20;
                        break;
                    case 3:
                        currentQuestion += 40;
                        break;
                    case 4:
                        currentQuestion += 60;
                        break;
                    case 5:
                        currentQuestion += 80;
                        break;
                }
                bool isCorrect = currentQues.CheckAnswer(new Selection(selectedAnswer, currentQuestion));
                if (isCorrect)
                {
                    correctCount++; 
                }
            }
        }
        // Hàm lấy văn bản đáp án từ chỉ số đáp án
        private string GetSelectedAnswerText(int answerIndex)
        {
            switch (answerIndex)
            {
                case 0: return radioButton1.Text;
                case 1: return radioButton2.Text;
                case 2: return radioButton3.Text;
                case 3: return radioButton4.Text;
                default: return string.Empty;
            }
        }
        //
        private void button21_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn nộp bài !", "Xác Nhận", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                int userIndex = User.GetUserIndex(NameUser);
                if (userIndex != -1)
                {
                    User.IncrementTestCount(userIndex);
                    User.SaveUser(filePath);
                }
                time.Stop();
                string elapsedTime = time.GetElapsedTime();
                // Tính điểm 
                ScoreCalculator calculator = new ScoreCalculator();
                float score = calculator.CalculateScore(correctCount, Test.Questions.Count);
                Form3 form3 = new Form3();
                form3.SetName(NameUser);
                form3.SetCategory(SelectedValue);
                form3.SetDate(GetDate);
                form3.ElapsedTime = elapsedTime;
                form3.SetScore(score.ToString());
                form3.Location = Location;
                form3.Show();
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
