using InalandBooking.DTO;
using InalandBooking.Models;
using InalandBooking.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using InalandBooking.Data;

namespace InalandBooking.Controllers
{
    public class UserController : Controller
    {
        public List<Error> ErrorArray { get; set; } = new();

        private readonly IApplicationService _applicationService;

        public UserController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignupDTO userSignupDTO)
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState.Values)
                {
                    foreach (var error in entry.Errors)
                    {
                        ErrorArray!.Add(new Error("", error.ErrorMessage, ""));
                    }
                }
                ViewData["ErrorArray"] = ErrorArray;
                return View(); // Return to the form with validation errors
            }

            try
            {
                await _applicationService.UserService.SignUpUserAsync(userSignupDTO);
                return RedirectToAction("Login", "User");
            }
            catch (Exception e)
            {
                ErrorArray!.Add(new Error("", e.Message, ""));
                ViewData["ErrorArray"] = ErrorArray;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Check if user is authenticated
            if (User.Identity!.IsAuthenticated)
            {
                // Redirect based on user role
                if (User.IsInRole(UserRole.Admin.ToString()))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginDTO credentials)
        {
            var user = await _applicationService.UserService.VerifyAndGetUserAsync(credentials);
            if (user == null)
            {
                ViewData["ValidateMessage"] = "Error: User/Password not found ";
                return View();
            }

            // Create claims for the authenticated user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, credentials.Username!),
                new Claim(ClaimTypes.Role, user.UserRole.ToString())
            };

            // Create identity and authentication properties
            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = credentials.KeepLoggedIn
            };

            // Sign in the user with the created identity and properties
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity), authProperties);

            // Redirect based on user role
            if ((bool)(user.UserRole = UserRole.Admin))
            {
            
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}
