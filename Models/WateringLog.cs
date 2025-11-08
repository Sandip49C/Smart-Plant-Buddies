// Path: Models/WateringLog.cs
namespace SmartPlantBuddies.Models
{
    public class WateringLog
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public int SensorId { get; set; }
        public string EventType { get; set; }
        public string Notes { get; set; }
        public string Timestamp { get; set; }
    }
}