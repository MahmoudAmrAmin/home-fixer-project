using Project.BLL.DTOs.Auth;
using Project.BLL.DTOs.Person;
using Project.DAL.Entities;

namespace Project.BLL.ServiceContracts
{
    public interface IAuthService
    {
        public Task<ApplicationUser> GetUserByEmail(string email);
        public Task<PersonDto?> LogIn(LogInDto logInDto);
        Task<List<string>> RegisterTechnician(RegisterTechnicianDto registerDto);
        public Task SignOut();
        public Task<List<string>> RegisterUser(RegisterUserDto registerDto);
    }
}
