namespace Project.DAL.Entities
{
    public class Technician:BaseEntity
    {
        public int TechnicianId { get; set; }

        public int FinishedWorks { get; set; }

        public  string ApplicationUserId { get; set; }

        public ApplicationUser Person { get; set; }

        public int SpecializationID { get; set; }


        public  Specialization Specialization { get; set; }
    }
}
