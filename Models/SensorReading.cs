// Path: Models/SensorReading.cs
namespace SmartPlantBuddies.Models
{
    public class SensorReading
    {
        public int ReadingId { get; set; }
        public int SensorId { get; set; }
        public double MoistureLevel { get; set; }
        public double Temperature { get; set; }
        public string Timestamp { get; set; }
    }
}