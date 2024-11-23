using Project.BLL.DTOs.Photo;

namespace Project.BLL.DTOs.Request
{
    public class RequestDto
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string SpecializationName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CityName { get; set; }

        public DateTime RequestedAt { get; set; }
        public List<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
        
    }
}


