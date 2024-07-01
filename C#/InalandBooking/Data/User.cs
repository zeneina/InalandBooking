using InalandBooking.Models;
using System.Security.Claims;


namespace InalandBooking.Data
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public UserRole? UserRole { get; set; }

        public virtual Admin? Admin { get; set; }
        public virtual User? user { get; set; }
        public ClaimsIdentity? Role { get; internal set; }
        public string? PhoneNumber { get; internal set; }
       
    }
}