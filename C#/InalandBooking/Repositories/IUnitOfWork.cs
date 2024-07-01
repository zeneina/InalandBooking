namespace InalandBooking.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}