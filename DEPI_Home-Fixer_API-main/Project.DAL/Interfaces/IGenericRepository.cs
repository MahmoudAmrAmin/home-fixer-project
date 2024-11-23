using Project.DAL.Entities;

namespace Project.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetEntityById(int id);

        void AddEntity(TEntity entity);
        public void AddRange(IEnumerable<TEntity> entities);

        void UpdateEntity(TEntity entity);

        void DeleteEntity(int id);

        public List<TResult> GetEntityData<TResult>(Func<TEntity, TResult> selector);

        public Task<IEnumerable<TEntity>> GetSpecificNumOfRecords(int num);



    }
}
