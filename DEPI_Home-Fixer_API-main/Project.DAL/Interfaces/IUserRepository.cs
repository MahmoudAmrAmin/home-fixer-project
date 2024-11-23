using Project.DAL.Entities;

namespace Project.DAL.Interfaces
{
    public interface IUserRepository:IGenericRepository<User> 
    {
        public  Task<User> GetCurrentUser(string username);
    }
}
