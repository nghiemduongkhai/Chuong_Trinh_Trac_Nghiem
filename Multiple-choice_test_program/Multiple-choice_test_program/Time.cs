using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class Time
    {
        private int duration; 
        private int elapsedTime; 
        private Timer timer; 
        public Time() 
        {
            duration = 1200; 
            elapsedTime = 0; 
            timer = new Timer(1000); 
            timer.Elapsed += OnTimedEvent; 
        }
        public void Start()
        {//Winform
            Console.WriteLine($"Thời gian còn lại: {duration / 60} phút {duration % 60} giây");
            timer.Start(); 
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            elapsedTime++; 
            int remainingTime = duration - elapsedTime;
            Console.Clear();
            //Winform
            Console.WriteLine($"Thời gian còn lại: {remainingTime / 60} phút {remainingTime % 60} giây");
            if (IsTimeUp()) 
            {
                Console.WriteLine("Thời gian đã hết!");
                timer.Stop();
            }
        }
        public bool IsTimeUp()
        {
            return elapsedTime >= duration; 
        }
    }
}
