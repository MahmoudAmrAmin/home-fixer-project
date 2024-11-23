using Project.BLL.Repositories;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(DEPIProjectContext context) : base(context)
        {
        }
    }
}
