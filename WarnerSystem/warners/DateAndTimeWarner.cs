using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarnerSystem.warners
{
    public class DateAndTimeWarner : Warner
    {
        public DateAndTimeWarner(string title) : base(title)
        {
        }

        public override string GetWarnerStatus()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
