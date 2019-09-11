

using System;

namespace TimeTrack
{
    public class ProcessTime
    {
        public string ProcessName { get; set; }
        public string ProcessTitle { get; set; }

        private ulong timeInSec;
        private bool tracked = false;
        public ProcessTime(string name, string title, ulong currentTime = 0)
        {
            timeInSec = currentTime;
            this.ProcessName = name;
            this.ProcessTitle = title;
        }

        public void AddSeconds(ulong sec)
        {
            timeInSec += sec;
        }

        public string GetTimeFormatted()
        {
            return $"{(timeInSec / 3600)}:{(timeInSec / 60) % 60}:{timeInSec % 60}";
        }

        public ulong GetTime()
        {
            return timeInSec;
        }

        public bool GetTracked()
        {
            return tracked;
        }

        public void SetTracked(bool isTracked)
        {
            tracked = isTracked;
        }
    }

}