using Project.BLL.DTOs.Pagination;
using Project.BLL.DTOs.Request;

namespace Project.BLL.ServiceContracts
{
    public interface IRequestService
    {

        public IEnumerable<RequestDto> GetAll();
        public RequestDto GetById(int id);
        public IEnumerable<RequestDto> GetAllBySpecializationId(int specializationI);
        public PageData<RequestDto> Getpage(int? cityId, int specializationId, int pageSize, int pageNo, bool needCount, bool sortByCity = false);
        public PageData<RequestDto> GetpageByUserId(int userId, int pageSize, int pageNo, bool needCount, bool sortByCity = false);

        public void Add(AddRequestDto requestDto);
        public void Delete(int id);
        public void Update(EditRequestDto requestDto);
        public RequestDtoForEdit GetByIdForEdit(int id);


    }

}
