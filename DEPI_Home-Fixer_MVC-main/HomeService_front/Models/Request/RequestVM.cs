using HomeService_front.Models.Photo;

namespace HomeService_front.Models.Request
{
    public class RequestVM
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string SpecializationName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CityName { get; set; }
        public DateTime RequestedAt { get; set; }
        public List<PhotoVM> Photos { get; set; } = new List<PhotoVM>();
    }
}
