using Project.BLL.DTOs.Client;
using Project.BLL.DTOs.User;

namespace Project.BLL.ServiceContracts
{
    public interface IClientService
    {
        public void Add(AddClientDto dto);
        public Task<ClientDto> GetCurrentUser(string username);
        public Task<IEnumerable<ClientDto>> GetSpecificNumOfRecords(int num);
        public IEnumerable<ClientDto> GetAll();

    }
}
