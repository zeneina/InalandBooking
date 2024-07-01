using InalandBooking.Data;
using System;

namespace InalandBooking.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int PropertyID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string? Status { get; set; }

        public User? User { get; set; }
        
    }
}
