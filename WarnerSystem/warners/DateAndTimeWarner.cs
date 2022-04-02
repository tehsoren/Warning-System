using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WarnerSystem.warners
{
    public class DateAndTimeWarner : Warner
    {
        private DateTime targetDate;
        public DateAndTimeWarner(string title) : base(title)
        {
        }

        public override void InfoWindowClear()
        {
            throw new NotImplementedException();
        }

        public override StackPanel InfoWindowFillout()
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
                while (!token.IsCancellationRequested)
                {
                    if(DateTime.Compare(targetDate,DateTime.Now)<=0)//now needs to later than target
                    {
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                    
                }
            });
        }
    }
}
