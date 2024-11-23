using Microsoft.EntityFrameworkCore;
using Project.BLL.Repositories;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class TechnicianRepository : GenericRepository<Technician>, ITechnicianRepository
    {
        public TechnicianRepository(DEPIProjectContext context) : base(context)
        {

        }
        public async Task<Technician> GetCurrentUser(string email)
        {
            return await _context.Technicians
                .Include(u => u.Person)
                .Include(u => u.Specialization)
                .FirstAsync(u => u.Person.Email == email);
        }

        public async Task<IEnumerable<Technician>> GetAllAsync()
        {
            return await _dbSet
         .Include(u => u.Person)
         .Include(u => u.Specialization)
         .ToListAsync();  // Executes the query and makes it awaitable

        }

        public override async Task<IEnumerable<Technician>> GetSpecificNumOfRecords(int num)
        {
            return await _dbSet
               .Include(u => u.Person)
               .Include(u => u.Specialization)
               .Take(num).ToListAsync();
            ;
        }

        public IEnumerable<Technician> GetPage(int? specializationId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool orderByWorksDesc = false)
        {
            var query = _context.Technicians
                .Include(u => u.Person)
                .Include(u => u.Specialization)
                .AsQueryable(); ;

            if (specializationId != null)
                query = query.Where(u => u.SpecializationID == specializationId);

            if (orderByWorksDesc)
                query = query.OrderByDescending(u => u.FinishedWorks);
            else
                query = query.OrderBy(u => u.FinishedWorks);

            count = needTotalCount ? query.Count() : null;
            return query.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }


    }
}
