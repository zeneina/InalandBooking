
using InalandBooking.Models;
using InalandBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace InalandBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly InalandBookingDbContext _context;
        private readonly ILogger<BookingService> _logger;

        public BookingService(InalandBookingDbContext context, ILogger<BookingService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateBookingAsync(Booking booking)
        {
            if (booking == null)
            {
                _logger.LogError("Booking object is null.");
                return false;
            }

            try
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating booking: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            try
            {
                return await _context.Bookings.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving all bookings: {ex.Message}");
                return new List<Booking>();
            }
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            try
            {
                return await _context.Bookings.FindAsync(bookingId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving booking by ID {bookingId}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateBookingAsync(Booking booking)
        {
            if (booking == null)
            {
                _logger.LogError("Booking object is null.");
                return false;
            }

            try
            {
                _context.Bookings.Update(booking);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating booking: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            try
            {
                var booking = await _context.Bookings.FindAsync(bookingId);
                if (booking == null)
                {
                    _logger.LogError($"Booking with ID {bookingId} not found.");
                    return false;
                }

                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting booking with ID {bookingId}: {ex.Message}");
                return false;
            }
        }

        Task IBookingService.CreateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        Task IBookingService.UpdateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        Task IBookingService.DeleteBookingAsync(int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
