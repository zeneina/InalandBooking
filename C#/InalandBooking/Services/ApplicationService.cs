namespace InalandBooking.Services
{
    public class ApplicationService : IApplicationService
    {
        public IUserService UserService { get; }
        public IBookingService BookingService { get; }
        

        public ApplicationService(IUserService userService, IBookingService bookingService)
        {
            UserService = userService;
            BookingService = bookingService;
            
        }
    }
}
