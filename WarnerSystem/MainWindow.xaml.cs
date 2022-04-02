using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WarnerSystem.warners;

namespace WarnerSystem
{
    public partial class MainWindow : Window
    {

        WarnersController warnersController;
        public MainWindow()
        {
            InitializeComponent();

            List<Warner> warnersList = new List<Warner>();

            warnersController = new WarnersController { warners = warnersList };
            KB.ItemsSource = warnersController.warners;
            AddNewWarner(new SimpleCountdown("Simple Timer",2));

        }

        private void KB_changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Warner w = (Warner)KB.SelectedItem;
            w.Warned = false;
            UpdateWarnerInfo();
            RefreshWarnerList();
        }

        private void UpdateWarnerInfo()
        {
            if(KB.SelectedItem != null)
            {
                Warner w = (Warner)KB.SelectedItem;
                DataTitle.Content = w.Title;
                
                DataStatus.Content = w.GetWarnerStatus();

                InfoRoot.Children.Clear();
                var sp = w.InfoWindowFillout();
                InfoRoot.Children.Add(sp);
                
            }
        }
        public void AddNewWarner(Warner warner)
        {
            warnersController.warners.Add(warner);
            RefreshWarnerList();
        }

        private void RefreshWarnerList()
        {
            KB.Items.Refresh();

        }

        private void NewWarnerButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewWarner(new SimpleCountdown("Simple Timer",5));
        }
        private void DelWarnerButton_Click(object sender, RoutedEventArgs e)
        {
            Warner w = (Warner)KB.SelectedItem;
            if(w != null)
            {
                if(w.GetWarnerStatus() != TaskStatus.Running)
                {
                    warnersController.warners.Remove(w);
                    RefreshWarnerList();
                }
            }
        }

        private void StartWarnerButton(object sender, RoutedEventArgs e)
        {
            Warner w = (Warner)KB.SelectedItem;
            if(w != null)
            {
                if(w.GetWarnerStatus() != TaskStatus.Running)
                    StartWarner(w);

            }
            UpdateWarnerInfo();

        }

        private async void StartWarner(Warner warner)
        {
            await warner.StartWarner();
            if(warner.GetWarnerStatus() == TaskStatus.RanToCompletion)
            {
                SoundAlarm(warner);
                UpdateWarnerInfo();
            }
            

        }

        private void SoundAlarm(Warner warner)
        {
            Debug.WriteLine("A Warner is Done");
            warner.Warned = true;
            RefreshWarnerList();
        }

        private void StopWarnerButton(object sender, RoutedEventArgs e)
        {
            Warner w = (Warner)KB.SelectedItem;
            if (w != null)
            {
                if (w.GetWarnerStatus() == TaskStatus.Running)
                    w.StopWarner();
            }
            UpdateWarnerInfo();
        }
    }
}
