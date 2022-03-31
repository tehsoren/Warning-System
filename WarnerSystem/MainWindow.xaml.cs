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

            List<IWarner> warnersList = new List<IWarner>();

            KB.ItemsSource = warnersList;

            warnersController = new WarnersController { warners = warnersList };

            AddNewWarner(new SimpleCountdown("Simple Timer"));

        }

        private void KB_changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            IWarner w = ((IWarner)e.AddedItems[0]);

            DataTitle.Content = w.GetTitle();
            DataStatus.Content = w.GetWarnerStatus();

        }
        public void AddNewWarner(IWarner warner)
        {
            warnersController.warners.Add(warner);
        }
        private void NewWarnerButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void DelWarnerButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StartWarnerButton(object sender, RoutedEventArgs e)
        {
            IWarner w = (IWarner)KB.SelectedItem;

            StartWarner(w);
        }

        private async void StartWarner(IWarner warner)
        {
            await warner.StartWarner();
        }

        private void SoundAlarm()
        {
            Debug.WriteLine("A Warner is Done");
        }

        private void StopWarnerButton(object sender, RoutedEventArgs e)
        {
            IWarner w = (IWarner)KB.SelectedItem;

            w.StopWarner();
        }
    }
}
