namespace Project.BLL.DTOs.Request
{
    public class AddRequestDto
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public int SpecializationId { get; set; }
        public int CityId { get; set; }

        public List<string> PhotosUrl { get; set; } = new List<String>();
    }
}
