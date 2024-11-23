using System.ComponentModel.DataAnnotations;

namespace HomeService_front.Models.Request
{
    public class CreateRequestVM
    {
        [Required(ErrorMessage = "Description")]
        public string Description { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Specialization Id")]
        public int SpecializationId { get; set; }

        [Required(ErrorMessage = "Specialization Id")]
        public int CityId { get; set; }

      
        public List<string> photosUrl { get; set; } = new List<string>();

        public List<IFormFile> Photos { get; set; } = new List<IFormFile>();
    }
}
