using Microsoft.EntityFrameworkCore;
using Project.BLL.Repositories;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(DEPIProjectContext context) : base(context)
        {
        }


        public override IEnumerable<Request> GetAll()
        {
            return _dbSet
                .Include(r => r.Photos)
                .Include(r => r.City)
                .Include(r => r.Specialization)
                .Include(r => r.User)
                .ThenInclude(u => u.Person)
                ;
        }

        public IEnumerable<Request> GetAllBySpecializationId(int specializationId)
        {
            return _dbSet
                .Where(r => r.SpecializationId == specializationId && r.Status == RequestStatus.Pending)
                .Include(r => r.Photos)
                .Include(r => r.City)
                .Include(r => r.Specialization)
                .Include(r => r.User)
                .ThenInclude(u => u.Person)
                ;
        }

        public IEnumerable<Request> GetPage(int? cityId, int specializationId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByCity = false)
        {
            var query = _dbSet
                .Where(r => r.SpecializationId == specializationId && r.Status == RequestStatus.Pending)
                .Include(r => r.Photos)
                .Include(r => r.City)
                .Include(r => r.Specialization)
                .Include(r => r.User)
                .ThenInclude(u => u.Person)
                .AsQueryable()
                ;

            if (cityId != null)
                query = query.Where(r => r.CityId == cityId);

            // Apply ordering based on sortByCity flag
            query = sortByCity
                ? query.OrderBy(r => r.City.CityId)
                : query.OrderBy(r => r.AddedAt);

            count = needTotalCount ? query.Count() : null;
            return query.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }


        public IEnumerable<Request> GetPageByUserId(int userId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByCity = false)
        {
            var query = _dbSet
                .Where(r => r.UserId == userId)
                .Include(r => r.Photos)
                .Include(r => r.City)
                .Include(r => r.Specialization)
                .Include(r => r.User)
                .ThenInclude(u => u.Person)
                .AsQueryable()
                ;

            if (sortByCity)
                query.OrderBy(r => r.City);
            else
                query.OrderBy(r => r.AddedAt);

            count = needTotalCount ? query.Count() : null;
            return query.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }

        public override Request GetEntityById(int id)
        {
            return _dbSet
                .Include(r => r.Photos)
                .Include(r => r.City)
                .Include(r => r.Specialization)
                .Include(r => r.User)
                .ThenInclude(u => u.Person)
                .FirstOrDefault(r => r.Id == id);

        }
    }

}
