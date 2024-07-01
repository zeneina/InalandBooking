using InalandBooking.Models;

namespace InalandBooking.Services
{
    public interface IBookingService
    {
        Task CreateBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int bookingId);
   
    }
}
