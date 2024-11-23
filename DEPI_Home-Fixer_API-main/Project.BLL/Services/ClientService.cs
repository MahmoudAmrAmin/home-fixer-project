using Project.BLL.DTOs.City;
using Project.BLL.DTOs.Client;
using Project.BLL.DTOs.User;
using Project.BLL.ServiceContracts;
using Project.DAL.Entities;
using Project.DAL.UnitOfWork;

namespace Project.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(AddClientDto dto)
        {
            User user = new User
            {
                ApplicationUserId = dto.ApplicationUserId,
            };

            _unitOfWork.UserRepository.AddEntity(user);
            _unitOfWork.Save();
        }

        public  IEnumerable<ClientDto> GetAll()
        {
            var clients = _unitOfWork.UserRepository.GetAll();

            return clients.Select(client => new ClientDto
            {
                FirstName = client.Person.FirstName,
                LastName = client.Person.LastName,
                Email = client.Person.Email,
                Id = client.UserId,
                PhoneNumber = client.Person.PhoneNumber,
                Username = client.Person.UserName
            });
        }

        public async Task<IEnumerable<ClientDto>> GetSpecificNumOfRecords(int num)
        {
            var clients = await _unitOfWork.UserRepository.GetSpecificNumOfRecords(num);

            return clients.Select(client => new ClientDto
            {
                FirstName = client.Person.FirstName,
                LastName = client.Person.LastName,
                Email = client.Person.Email,
                Id = client.UserId,
                PhoneNumber = client.Person.PhoneNumber,
                Username = client.Person.UserName
            });
        }

        public async Task<ClientDto> GetCurrentUser(string username)
        {
            var client = await _unitOfWork.UserRepository.GetCurrentUser(username);

            return new ClientDto
            {
                Id = client.UserId,
                Email = client.Person.Email,
                FirstName = client.Person.FirstName,
                LastName = client.Person.LastName,
                PhoneNumber = client.Person.PhoneNumber,
                Username = client.Person.UserName,
            };
        }
    }
}
