using System;
using System.ComponentModel.DataAnnotations;

namespace InalandBooking.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Booking Date is required")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Number of Guests is required")]
        [Range(1, 100, ErrorMessage = "Number of Guests must be between 1 and 100")]
        public int NumberOfGuests { get; set; }
    }
}
