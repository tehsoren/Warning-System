using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WarnerSystem.warners
{
    public class SimpleCountdown : Warner
    {
        int timeToSleep;
        public SimpleCountdown(string title,int timeToSleep) : base(title)
        {
            this.timeToSleep = timeToSleep;
        }

        public int TimeToSleep { get => timeToSleep; set => timeToSleep = value; }

        public override void InfoWindowClear()
        {
            throw new NotImplementedException();
        }

        public override StackPanel InfoWindowFillout()
        {
            StackPanel sp = new StackPanel();
            Label l1 = new Label() { Content= "Countdown Time: "};
            sp.Children.Add(l1);
            TextBox t1 = new TextBox();
            sp.Children.Add(t1);

            XAMLHelper.CreateNewBinding(this, "TimeToSleep", BindingMode.TwoWay, t1, TextBox.TextProperty);
            XAMLHelper.CreateNewBinding(this, "IsRunning", BindingMode.OneWay, t1, TextBox.IsReadOnlyProperty);


            return sp;
        }

        public bool IsRunning { get => this.GetWarnerStatus() == TaskStatus.Running;}

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
