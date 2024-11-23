using System.ComponentModel.DataAnnotations;

namespace Project.BLL.DTOs.Auth
{
    public class RegisterTechnicianDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public int SpecializationID { get; set; }



    }
}
