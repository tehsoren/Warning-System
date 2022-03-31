using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WarnerSystem.warners
{
    public class SimpleCountdown : IWarner
    {
        Task task;
        string title;
        public SimpleCountdown(string title)
        {
            this.title = title;
        }
        public Task StartWarner()
        {
            Task task = Task.Run(() => Timer());
            this.task = task;
            return task;
        }

        private void Timer()
        {
            Thread.Sleep(2000);
            Debug.WriteLine("hej");
        }

        public string GetTitle()
        {
            return title;
        }

        public void StopWarner()
        {
            throw new NotImplementedException();
        }

        public string GetWarnerStatus()
        {
            return "NYI";
        }

        public void InfoWindowFillout()
        {
            throw new NotImplementedException();
        }

        public void InfoWindowUpdate()
        {
            throw new NotImplementedException();
        }

        public void InfoWindowClear()
        {
            throw new NotImplementedException();
        }
    }
}
