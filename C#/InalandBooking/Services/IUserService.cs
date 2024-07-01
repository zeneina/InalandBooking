
using InalandBooking.Data;
using InalandBooking.DTO;
using InalandBooking.Models;

namespace InalandBooking.Services
{
    // Interface for user service, defining the contract for user-related operations
    public interface IUserService
    {
        // Signs up a new user
        Task<bool> SignUpUserAsync(UserSignupDTO userSignupDTO);

        // Verifies and retrieves a user based on login details
        Task<UserLoginDTO?> VerifyAndGetUserAsync(UserLoginDTO userLoginDTO);

        // Retrieves a user by their ID
        Task<User?> GetUserByIdAsync(int userId);

        // Updates a user's profile
        Task<bool> UpdateUserProfileAsync(int userId, UserProfileDTO userProfileDTO);

        // Changes a user's password
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);

        // Deletes a user
        Task<bool> DeleteUserAsync(int userId);

        // Retrieves all users
        Task<IEnumerable<User>> GetAllUsersAsync();

        // Resets a user's password
        Task<bool> ResetPasswordAsync(string email);

        // Assigns a role to a user
        Task<bool> AssignUserRoleAsync(int userId, UserRole userRole);

        // Retrieves a filtered list of users with pagination
        Task<List<User>> GetAllUsersFiltered(int pageNumber, int pageSize, UserFiltersDTO userFiltersDTO);
    }
}
