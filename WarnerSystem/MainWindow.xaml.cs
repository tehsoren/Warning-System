using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
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
            AddNewWarner(new SimpleCountdown("Simple Timer",5));

        }

        private void KB_changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Warner w = (Warner)e.AddedItems[0];

            DataTitle.Content = w.GetTitle();
            DataStatus.Content = w.GetWarnerStatus();

        }
        public void AddNewWarner(Warner warner)
        {
            warnersController.warners.Add(warner);
            KB.Items.Refresh();
        }
        private void NewWarnerButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewWarner(new SimpleCountdown("Simple Timer",5));
        }
        private void DelWarnerButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StartWarnerButton(object sender, RoutedEventArgs e)
        {
            Warner w = (Warner)KB.SelectedItem;

            StartWarner(w);
        }

        private async void StartWarner(Warner warner)
        {
            await warner.StartWarner();

        }

        private void SoundAlarm()
        {
            Debug.WriteLine("A Warner is Done");
        }

        private void StopWarnerButton(object sender, RoutedEventArgs e)
        {
            Warner w = (Warner)KB.SelectedItem;

            w.StopWarner();
        }
    }
}
