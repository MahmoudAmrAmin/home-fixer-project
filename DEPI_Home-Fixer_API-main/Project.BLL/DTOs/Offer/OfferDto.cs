using Project.DAL.Entities;

namespace Project.BLL.DTOs.Offer
{
    public class OfferDto
    {
        public int OfferID { get; set; }
        public string OfferDetails { get; set; }
        public decimal Price { get; set; }
        public OfferStatus OfferStatus { get; set; }
        public DateTime VisitDate { get; set; }

        public string TechnicianFullName { get; set; }
        public int TechnicianTotalWorks { get; set; }
    }
}
