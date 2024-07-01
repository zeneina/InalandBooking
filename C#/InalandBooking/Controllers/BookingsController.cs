using Microsoft.AspNetCore.Mvc;
using InalandBooking.Services;
using InalandBooking.Models;
using System.Threading.Tasks;

namespace InalandBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // Προβολή αρχικής σελίδας
        public IActionResult Home()
        {
            return View();
        }

        // Προβολή σελίδας δημιουργίας νέας κράτησης
        public IActionResult Create()
        {
            return View();
        }

        // Δημιουργία νέας κράτησης
        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return View(booking);
            }

            try
            {
                await _bookingService.CreateBookingAsync(booking);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(booking);
            }
        }

        // Προβολή σελίδας όλων των κρατήσεων
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return View(bookings);
        }

        // Προβολή σελίδας επεξεργασίας κράτησης
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // Επεξεργασία κράτησης
        [HttpPost]
        public async Task<IActionResult> Edit(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return View(booking);
            }

            try
            {
                await _bookingService.UpdateBookingAsync(booking);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(booking);
            }
        }

        // Διαγραφή κράτησης
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // Επιβεβαίωση διαγραφής κράτησης
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _bookingService.DeleteBookingAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
