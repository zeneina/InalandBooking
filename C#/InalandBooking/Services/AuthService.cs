// Services/AuthService.cs
using InalandBooking.Data;

using Microsoft.EntityFrameworkCore;


namespace InalandBookingAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly InalandBookingDbContext _context;

        public AuthService(InalandBookingDbContext context) => _context = context;

        public async Task<bool> ValidateUser(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            return user != null;
        }
    }
}
