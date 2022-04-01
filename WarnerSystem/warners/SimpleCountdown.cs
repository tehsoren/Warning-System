using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WarnerSystem.warners
{
    public class SimpleCountdown : Warner
    {
        int timeToSleep;
        public SimpleCountdown(string title,int timeToSleep) : base(title)
        {
            this.timeToSleep = timeToSleep;
        }

        public override void InfoWindowClear()
        {
            throw new NotImplementedException();
        }

        public override void InfoWindowFillout()
        {
            throw new NotImplementedException();
        }

        public override void InfoWindowUpdate()
        {
            throw new NotImplementedException();
        }

        public override Action WarnerAction(CancellationToken token)
        {
            return (() =>
                {
                    for (int i = 0; i < timeToSleep; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                        Debug.WriteLine("I sleep still");
                        Thread.Sleep(1000);
                    }
                
                }) ;
        }
    }
}
