using System.ComponentModel.DataAnnotations;

namespace HomeService_front.Models.Auth
{
    public class RegisterTechnicianVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public int SpecializationID { get; set; }



    }
}
