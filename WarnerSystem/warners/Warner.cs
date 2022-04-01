using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarnerSystem.warners
{
    public abstract class Warner
    {
        private string title;
        public Task task;
        private CancellationTokenSource tokenSource;

        public string Title { get => title; }

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
            if(task != null)
            {
                return this.task.Status;
            }
            else
            {
                return null;
            }
            
        }
        public abstract void InfoWindowFillout();
        public abstract void InfoWindowUpdate();
        public abstract void InfoWindowClear();
    }
}
