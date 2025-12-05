using SmartPlantBuddies.Models;
using SmartPlantBuddy.Models;
using SmartPlantBuddy.Services;

namespace SmartPlantBuddy.Views;

public partial class DashboardPage : ContentPage
{
    private readonly DatabaseRepository _repo;
    private readonly LocationService _locationService;

    public DashboardPage(DatabaseRepository repo, LocationService locationService)
    {
        InitializeComponent();
        _repo = repo;
        _locationService = locationService;
        _ = LoadData();
    }

    private async Task LoadData()
    {
        var readings = await _repo.GetAllReadingsAsync();
        ReadingsList.ItemsSource = readings;

        var (city, temp) = await _locationService.GetLocationAndWeatherAsync();
        LocationLabel.Text = $"{city} • {temp}°C";
    }

    private async void OnRefreshLocation(object sender, EventArgs e)
    {
        await LoadData();
    }

    private async void OnAddReadingClicked(object sender, EventArgs e)
    {
        var reading = new SensorReading
        {
            SensorId = 1,
            MoistureLevel = new Random().Next(20, 80),
            Temperature = new Random().Next(15, 30)
        };
        await _repo.AddReadingAsync(reading);
        await LoadData();
    }
}