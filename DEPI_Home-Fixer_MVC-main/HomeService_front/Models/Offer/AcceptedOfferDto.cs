namespace Project.BLL.DTOs.Offer
{
    public class AcceptedOfferVM
    {
        public int OfferID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string OfferDetails { get; set; }
        public decimal Price { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
