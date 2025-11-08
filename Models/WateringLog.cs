using System;

namespace SmartPlantBuddies.Models
{
    public class WateringLog
    {
        public int Id { get; set; }
        public DateTime WateredAt { get; set; }
        public string Notes { get; set; } // optional
    }
}