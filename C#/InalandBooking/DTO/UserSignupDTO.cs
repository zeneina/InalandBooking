﻿using InalandBooking.Models;
using System.ComponentModel.DataAnnotations;

namespace InalandBooking.DTO
{
    public class UserSignupDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username should be between 2 and 50 characters.")]
        public string? Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*\W).{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, " +
            "one lowercase letter, one digit, and one special character.")]
        public string? Password { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Firstname should not exceed 50 characters.")]
        public string? Firstname { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Lastname should not exceed 50 characters.")]
        public string? Lastname { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Email should not exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Phone number should not exceed 15 characters.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }

        [Required]
        [EnumDataType(typeof(UserRole), ErrorMessage = "Invalid user role.")]
        public UserRole UserRole { get; set; }
    }
}
