namespace Project.BLL.DTOs.Request
{
    public class EditRequestDto
    {
        public int RequestId { get; set; }
        public string Description { get; set; }
        public int SpecializationId { get; set; }
        public int CityId { get; set; }

        public List<string?> PhotosUrl { get; set; } = new List<string?>();

    }
}
    