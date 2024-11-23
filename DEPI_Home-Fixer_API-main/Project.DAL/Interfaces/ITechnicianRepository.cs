using Project.DAL.Entities;

namespace Project.DAL.Interfaces
{
    public interface ITechnicianRepository:IGenericRepository<Technician>
    { 
          public  Task<Technician> GetCurrentUser(string username);
        public IEnumerable<Technician> GetPage(int? specializationId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool orderByWorksDesc = false);
        public Task<IEnumerable<Technician>> GetAllAsync();

    }
}
