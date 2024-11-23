using Project.BLL.Repositories;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class SpecializationRepository : GenericRepository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(DEPIProjectContext context) : base(context)
        {
        }
    }
}
