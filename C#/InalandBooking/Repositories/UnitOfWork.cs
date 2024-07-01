using InalandBooking.Data;
using InalandBooking.Repositories;

namespace InalandBookingDbContex.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InalandBookingDbContext _context;

        public UnitOfWork(InalandBookingDbContext context)
        {
            _context = context;
        }

        public UserRepository UserRepository => new(_context);
        

        IUserRepository IUnitOfWork.UserRepository => throw new NotImplementedException();

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}