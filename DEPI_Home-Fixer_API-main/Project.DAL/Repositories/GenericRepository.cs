using Microsoft.EntityFrameworkCore;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.BLL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DEPIProjectContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DEPIProjectContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual void AddEntity(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);

        }

        public virtual void DeleteEntity(int id)
        {
            TEntity entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
         => _dbSet.ToList();

        public virtual TEntity GetEntityById(int id)
         => _dbSet.Find(id);

        public virtual void UpdateEntity(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual List<TResult> GetEntityData<TResult>(Func<TEntity, TResult> selector)
        {
            return _dbSet.Select(selector).ToList();
        }


        public virtual async Task<IEnumerable<TEntity>> GetSpecificNumOfRecords(int num)
           => await _dbSet
           .Take(num)
           .ToListAsync();

    }
}
