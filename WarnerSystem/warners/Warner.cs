using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WarnerSystem.warners
{
    public abstract class Warner
    {
        private string title;
        public Task task;
        private CancellationTokenSource tokenSource;
        private bool warned = false;
        public string Title { get => title; }
        public bool Warned { get => warned; set => warned = value; }

        public Warner(string title)
        {
            this.title = title;
        }


        public async virtual Task StartWarner()
        {
            NewTokenSource();

            Task task = Task.Run(WarnerAction(tokenSource.Token), tokenSource.Token);

            this.task = task;
            await task;



        }

        private void NewTokenSource()
        {
            if (tokenSource != null)
            {
                tokenSource.Dispose();
            }
            tokenSource = new CancellationTokenSource();
        }
        public virtual void StopWarner()
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
            }
        }
        public abstract Action WarnerAction(CancellationToken token);
        public virtual TaskStatus? GetWarnerStatus()
        {
            if (task != null)
            {
                return this.task.Status;
            }
            else
            {
                return null;
            }

        }
        public bool IsRunning { get => this.GetWarnerStatus() == TaskStatus.Running; }
        public abstract StackPanel InfoWindowFillout();
        public abstract void InfoWindowUpdate();
        public abstract void InfoWindowClear();
    }
}
