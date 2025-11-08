// Path: Models/User.cs
namespace SmartPlantBuddies.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string CreatedAt { get; set; }
    }
}