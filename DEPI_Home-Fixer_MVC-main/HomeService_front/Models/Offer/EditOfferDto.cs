namespace Project.BLL.DTOs.Offer
{
    public class EditOfferDto
    {
        public int Id { get; set; }
        public string OfferDetails { get; set; }
        public decimal Price { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
