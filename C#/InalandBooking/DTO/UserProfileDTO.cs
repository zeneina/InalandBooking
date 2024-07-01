
namespace InalandBooking.DTO

{
    public class UserProfileDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }    // New property
        public string? Address { get; set; }        // New property
        public DateTime DateOfBirth { get; set; }  // New property
        public string? ProfilePictureUrl { get; set; }  // New property
        public string? Username { get; set; }       // New property
        
    }
}
