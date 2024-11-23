using Project.DAL.Entities;

namespace Project.DAL.Interfaces
{
    public interface IRequestRepository:IGenericRepository<Request>
    {
        public IEnumerable<Request> GetAllBySpecializationId(int specializationId);
        public IEnumerable<Request> GetPage(int? cityId, int specializationId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByCity = false);
        public IEnumerable<Request> GetPageByUserId(int userId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByCity = false);


    }

}

