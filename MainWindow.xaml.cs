using System;
using System.Windows;
using SmartPlantBuddies.Models;
using SmartPlantBuddies.Data;


namespace SmartPlantBuddies
{
    public partial class MainWindow : Window
    {
        private readonly Repository _repository;
        private int _currentSensorId = 1; // For demo
        private int _currentUserId = 1;   // For demo

        public MainWindow()
        {
            InitializeComponent(); // This is auto-generated after successful XAML parse
            _repository = new Repository();
            LoadLatestSensorData();
        }

        private void LoadLatestSensorData()
        {
            var readings = _repository.GetSensorReadings(_currentSensorId);
            if (readings.Count > 0)
            {
                var latest = readings[readings.Count - 1];
                MoistureText.Text = $"{latest.MoistureLevel}%";
                TempText.Text = $"{latest.Temperature}°C";
            }
            else
            {
                MoistureText.Text = "No Data";
                TempText.Text = "No Data";
            }
        }

        private void WaterButton_Click(object sender, RoutedEventArgs e)
        {
            var log = new WateringLog
            {
                UserId = _currentUserId,
                SensorId = _currentSensorId,
                EventType = "manual",
                Notes = "Manual watering",
                Timestamp = DateTime.Now.ToString("o")
            };
            _repository.SaveWateringLog(log);
            MessageBox.Show("Watering logged!");
        }

        private void ViewHistory_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("History feature not implemented yet.");
        }
    }
}