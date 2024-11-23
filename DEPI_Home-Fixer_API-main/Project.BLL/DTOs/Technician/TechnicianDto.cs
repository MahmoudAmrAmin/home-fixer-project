namespace Project.BLL.DTOs.Technician
{
    public class TechnicianDto
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string SpecializationName { get; set; }
            public int SpecializationID { get; set; }
            public int FinishedWord {  get; set; }
    }
}
