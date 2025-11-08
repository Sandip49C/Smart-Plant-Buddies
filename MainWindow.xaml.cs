using System;
using System.Windows;
using SmartPlantBuddies.Models;
using SmartPlantBuddies.Data;
using System.Collections.Generic;

namespace SmartPlantBuddies
{
    public partial class MainWindow : Window
    {
        private Repository _repository;
        private bool _isHistoryVisible = false;

        public MainWindow()
        {
            InitializeComponent();
            _repository = new Repository();
            LoadWateringLogs(); // optional: load logs on startup
        }

        private void WaterButton_Click(object sender, RoutedEventArgs e)
        {
            var log = new WateringLog
            {
                WateredAt = DateTime.Now,
                Notes = "Watered via button"
            };
            _repository.AddWateringLog(log);
            StatusText.Text = "Watering logged!";
        }

        private void ToggleHistory_Click(object sender, RoutedEventArgs e)
        {
            if (_isHistoryVisible)
            {
                // Hide the history
                HistoryDataGrid.Visibility = Visibility.Collapsed;
                ToggleHistoryButton.Content = "Show History";
                _isHistoryVisible = false;
            }
            else
            {
                // Show the history
                LoadWateringLogs();
                HistoryDataGrid.Visibility = Visibility.Visible;
                ToggleHistoryButton.Content = "Hide History";
                _isHistoryVisible = true;
            }
        }

        private void LoadWateringLogs()
        {
            var logs = _repository.GetAllWateringLogs();
            HistoryDataGrid.ItemsSource = logs;
        }
    }
}