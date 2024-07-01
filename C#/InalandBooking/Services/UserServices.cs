using AutoMapper;
using InalandBooking.Data;
using InalandBooking.DTO;
using InalandBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InalandBooking.Services
{
    // Implementation of IUserService, handling user-related operations
    public class UserServices : IUserService
    {
        private readonly InalandBookingDbContext _context;
        private readonly IMapper _mapper;

        // Constructor to inject the DbContext and AutoMapper
        public UserServices(InalandBookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Signs up a new user
        public async Task<bool> SignUpUserAsync(UserSignupDTO userSignupDTO)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == userSignupDTO.Username);

            if (existingUser != null)
                return false;

            var user = _mapper.Map<User>(userSignupDTO);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Verifies and retrieves a user based on login details
        public async Task<UserLoginDTO?> VerifyAndGetUserAsync(UserLoginDTO userLoginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userLoginDTO.Username && u.Password == userLoginDTO.Password);

            if (user == null)
                return null;

            return _mapper.Map<UserLoginDTO>(user);
        }

        // Retrieves a user by their ID
        public async Task<UserDTO?> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
                return null;

            return _mapper.Map<UserDTO>(user);
        }

        // Updates a user's profile
        public async Task<bool> UpdateUserProfileAsync(int userId, UserProfileDTO userProfileDTO)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
                return false;

            _mapper.Map(userProfileDTO, user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Changes a user's password
        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
                return false;

            if (user.Password != currentPassword)
                return false;

            user.Password = newPassword;
            await _context.SaveChangesAsync();
            return true;
        }

        // Deletes a user
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Retrieves all users
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        // Resets a user's password
        public async Task<bool> ResetPasswordAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return false;

            user.Password = GenerateRandomPassword();
            await _context.SaveChangesAsync();
            return true;
        }

        // Assigns a role to a user
        public async Task<bool> AssignUserRoleAsync(int userId, UserRole userRole)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
                return false;

            user.UserRole = userRole;
            await _context.SaveChangesAsync();
            return true;
        }

        // Retrieves a filtered list of users with pagination
        public async Task<List<UserDTO>> GetAllUsersFiltered(int pageNumber, int pageSize, UserFiltersDTO userFiltersDTO)
        {
            var query = _context.Users.AsQueryable();

            // Apply filters to query
            if (!string.IsNullOrEmpty(userFiltersDTO.Username))
            {
                query = query.Where(u => u.Username.Contains(userFiltersDTO.Username));
            }

            if (!string.IsNullOrEmpty(userFiltersDTO.Email))
            {
                query = query.Where(u => u.Email.Contains(userFiltersDTO.Email));
            }

            // Add other filters as needed...

            var users = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        // Generates a random password
        private string GenerateRandomPassword()
        {
            const int length = 12;
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            var random = new Random();
            var password = new char[length];

            for (int i = 0; i < length; i++)
            {
                password[i] = validChars[random.Next(validChars.Length)];
            }

            return new string(password);
        }

        Task<User?> IUserService.GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IUserService.GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IUserService.GetAllUsersFiltered(int pageNumber, int pageSize, UserFiltersDTO userFiltersDTO)
        {
            throw new NotImplementedException();
        }
    }
}
