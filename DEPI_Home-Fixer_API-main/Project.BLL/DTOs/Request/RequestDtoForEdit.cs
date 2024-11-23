using Project.BLL.DTOs.Photo;

namespace Project.BLL.DTOs.Request
{
    public class RequestDtoForEdit
    {
        public int RequestId { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public int SpecializationID { get; set; }
        public List<PhotoDto> Photos { get; set; } = new List<PhotoDto>();

    }
}
