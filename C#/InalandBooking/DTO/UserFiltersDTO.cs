using System;

namespace InalandBooking.DTO
{
    public class UserFiltersDTO
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        public string? Department { get; set; }
       
    }
}
