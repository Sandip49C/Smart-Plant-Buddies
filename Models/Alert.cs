// Path: Models/Alert.cs
namespace SmartPlantBuddies.Models
{
    public class Alert
    {
        public int AlertId { get; set; }
        public int UserId { get; set; }
        public int ReadingId { get; set; }
        public string Type { get; set; }
        public string Timestamp { get; set; }
    }
}