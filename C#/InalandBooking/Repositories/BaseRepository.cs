using System.Collections.Generic;
using System.Threading.Tasks;
using InalandBooking.Data;
using InalandBooking.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InalandBooking.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly InalandBookingDbContext _context;
        protected readonly DbSet<T> _dbSet; // DbSet για τον τύπο T

        public BaseRepository(InalandBookingDbContext context)
        {
            _context = context;
            // Κάνουμε cast το αντικείμενο που επιστρέφεται από τη Set<T>() σε DbSet<T>
            _dbSet = (DbSet<T>)_context.Set<T>();
        }

        // Επιστρέφει όλα τα αντικείμενα του τύπου T
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Επιστρέφει ένα αντικείμενο του τύπου T με βάση το ID
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Επιστρέφει το πρώτο αντικείμενο του τύπου T που πληροί το κριτήριο
        public async Task<T> FindAsync(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        // Προσθήκη ενός αντικειμένου του τύπου T
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Ενημέρωση ενός αντικειμένου του τύπου T
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Διαγραφή ενός αντικειμένου του τύπου T
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
