using System.ComponentModel.DataAnnotations;

namespace HomeService_front.Models.Auth
{
    public class LogInVm
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
