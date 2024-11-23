namespace HomeService_front.Models.Technician
{
    public class TechnicianVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string SpecializationName { get; set; }
        public int SpecializationId { get; set; }
        public int FinishedWord { get; set; }
    }
}
