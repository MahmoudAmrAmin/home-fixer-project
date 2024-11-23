using System.ComponentModel.DataAnnotations;

namespace HomeService_front.Models.Auth
{
    public class RegisterUserVM
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "PhoneNumber is Required")]

        public string PhoneNumber { get; set; }
    }
}
