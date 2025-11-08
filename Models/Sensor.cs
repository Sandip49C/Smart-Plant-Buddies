// Path: Models/Sensor.cs
namespace SmartPlantBuddies.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }
}