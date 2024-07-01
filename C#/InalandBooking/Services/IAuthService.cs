// Services/IAuthService.cs

namespace InalandBookingAPI.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(string username, string password);
    }
}
