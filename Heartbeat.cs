using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartbeatService
{
    public class Heartbeat
    {
        private readonly System.Timers.Timer timer;

        public Heartbeat()
        {
            timer = new(1000) { AutoReset = true };
            timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Temp\ServiceDemo\Heartbeat.txt", lines);
        }

        public void Start() { timer.Start(); }
        public void Stop() { timer.Stop(); }
    }
}
