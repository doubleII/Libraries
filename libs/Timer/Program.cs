using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            Watchdog.SetTimer();
            Console.ReadLine();
        }
    }

    public static class Watchdog
    {
        private static Timer aTimer;

        public static void SetTimer()
        {
            // TODO in config file
            aTimer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            Console.WriteLine($"SetTimer method is called:: {DateTime.Now}");
        }

        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Tick {DateTime.Now:F}");
        }
    }
}
