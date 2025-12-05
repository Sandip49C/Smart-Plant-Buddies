using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using Windows.Devices.Geolocation;

namespace SmartPlantBuddy.Services;

public class LocationService
{
    public async Task<(string city, double temp)> GetLocationAndWeatherAsync()
    {
        try
        {
            var permission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (permission != PermissionStatus.Granted) return ("Permission denied", 0);

            var location = await Geolocation.Default.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
            if (location == null) return ("Unknown location", 0);

            var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);
            var city = placemarks?.FirstOrDefault()?.Locality ?? "Unknown City";

            var client = new HttpClient();
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m";
            var json = await client.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<JsonElement>(json);
            var temp = data.GetProperty("current").GetProperty("temperature_2m").GetDouble();

            return (city, temp);
        }
        catch
        {
            return ("Location unavailable", 0);
        }
    }
}