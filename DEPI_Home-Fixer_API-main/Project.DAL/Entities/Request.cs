namespace Project.DAL.Entities
{
    public enum RequestStatus
    {
        Pending,
        InProgress,
       // Finished
    }

    public class Request : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public int UserId { get; set; }

        public int SpecializationId { get; set; }
        public int CityId { get; set; }

        public User User { get; set; }
        public Specialization Specialization { get; set; }

        public City City { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();

    }
}
