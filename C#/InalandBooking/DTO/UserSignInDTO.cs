using System.ComponentModel.DataAnnotations;

namespace InalandBooking.DTO
{
    public class UserSignInDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username should be between 2 and 50 characters.")]
        public string? Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
        public string? Password { get; set; }

        public bool KeepMeLoggedIn { get; set; }
    }
}
