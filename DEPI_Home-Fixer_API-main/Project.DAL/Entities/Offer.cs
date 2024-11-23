namespace Project.DAL.Entities
{
    public enum OfferStatus
    {
        Pending,
        Accepted,
        Rejected
    }

    public class Offer : BaseEntity
    {
        public int OfferID { get; set; }

        public string OfferDetails { get; set; }
        public decimal Price { get; set; }
        public OfferStatus OfferStatus { get; set; } = OfferStatus.Pending;
        public DateTime VisitDate { get; set; }

        public int RequestID { get; set; }
        public int TechnicianID { get; set; }

        public Request Request { get; set; }
        public Technician Technician { get; set; }


    }
}
