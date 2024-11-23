using Project.BLL.DTOs.Offer;
using Project.BLL.DTOs.Pagination;
using Project.BLL.DTOs.Technician;

namespace Project.BLL.ServiceContracts
{
    public interface ITechnicianService
    {
        void Add(AddTechnicianDto dto);
        IEnumerable<AcceptedOfferDto> GetAcceptedOffers(int techId);
        public Task<TechnicianDto> GetById(string id);
        public PageData<TechnicianDto> GetPage(int? specializationId, int pageSize, int pageNo, bool needTotalCount, bool orderByWorksDesc = false);
        public Task<List<TechnicianDto>> GetAll();
        public Task<List<TechnicianDto>> GetSpecificNumOfRecords(int num);

    }
}
