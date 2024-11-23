namespace Project.BLL.DTOs.Offer
{
    public class AddOfferDto
    {
        public string OfferDetails { get; set; }
        public decimal Price { get; set; }
        public DateTime VisitDate { get; set; }
        public int RequestID { get; set; }
        public int TechnicianID { get; set; }
    }
}
