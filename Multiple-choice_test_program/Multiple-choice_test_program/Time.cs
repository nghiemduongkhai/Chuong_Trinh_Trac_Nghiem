using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Multiple_choice_test_program
{
    public class Time
    {
        private int duration; 
        private int elapsedTime; 
        private Timer timer; 
        private Label label;
        public event Action TimeUp;
        public Time(Label label) 
        {
            this.label = label;
            duration = 1200; 
            elapsedTime = 0; 
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += OnTimedEvent; 
        }
        public void Start()
        {
            UpdateLabel($"{duration / 60} phút {duration % 60} giây");
            timer.Start(); 
        }
        public void Stop()
        {
            timer.Stop();
        }
        public string GetElapsedTime()
        {
            return $"{elapsedTime / 60} phút {elapsedTime % 60} giây"; 
        }
        private void OnTimedEvent(Object source, EventArgs e)
        {
            elapsedTime++; 
            int remainingTime = duration - elapsedTime;
            UpdateLabel($"{remainingTime / 60} phút {remainingTime % 60} giây");
            if (IsTimeUp()) 
            {
                timer.Stop();
                MessageBox.Show("Hết thời gian !!");
                TimeUp?.Invoke();
            }
        }
        private void UpdateLabel(string text)
        {
            label.Text = text;
        }
        public bool IsTimeUp()
        {
            return elapsedTime >= duration; 
        }
    }
}
