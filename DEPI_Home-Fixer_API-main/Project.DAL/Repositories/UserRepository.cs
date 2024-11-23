using Microsoft.EntityFrameworkCore;
using Project.BLL.Repositories;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DEPIProjectContext context) : base(context)
        {

        }

        public override IEnumerable<User> GetAll()
            => _dbSet
            .Include(u => u.Person)
           .ToList();

        public override async Task<IEnumerable<User>> GetSpecificNumOfRecords(int num)
           => await _dbSet
            .Include(u => u.Person)
           .Take(num)
           .ToListAsync();

        public async Task<User> GetCurrentUser(string email)
        {
            var res = await _context.Clients
                 .Include(u => u.Person)
                 .FirstAsync(u => u.Person.Email == email);

            return res;
        }
    }
}
