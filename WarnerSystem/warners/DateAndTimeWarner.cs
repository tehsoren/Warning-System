using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WarnerSystem.warners
{
    public class DateAndTimeWarner : Warner
    {
        private DateTime targetDate;
        public DateAndTimeWarner(string title) : base(title)
        {
            targetDate = DateTime.Now;
        }

        public DateTime TargetDate { get => targetDate; set => targetDate = value; }

        public override void InfoWindowClear()
        {
            throw new NotImplementedException();
        }

        public override StackPanel InfoWindowFillout()
        {
            StackPanel sp = new StackPanel();
            Label l1 = new Label() { Content = "Target Date: " };
            sp.Children.Add(l1);
            TextBox t1 = new TextBox();
            sp.Children.Add(t1);
            t1.TextChanged += dateTimeTextBox_InputValidation;

            XAMLHelper.CreateNewBinding(this, "TargetDate", BindingMode.OneWay, t1, TextBox.TextProperty);
            XAMLHelper.CreateNewBinding(this, "IsRunning", BindingMode.OneWay, t1, TextBox.IsReadOnlyProperty);


            return sp;
        }
        private void dateTimeTextBox_InputValidation(object sender, TextChangedEventArgs args)
        {
            var newText = (TextBox)sender;
            
            if (DateTime.TryParse(newText.Text, out DateTime parsed))
            {
                //cant set a timer before now
                if(DateTime.Compare(DateTime.Now,parsed)<0)
                {
                    targetDate = parsed;
                }
            }
            else
            {
                
            }
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
