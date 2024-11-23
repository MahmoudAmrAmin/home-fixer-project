using System.ComponentModel.DataAnnotations;

namespace Project.BLL.DTOs.Offer
{
    public class AddOfferVM
    {
        [Required(ErrorMessage = "Offer Details is Required")]
        public string OfferDetails { get; set; }


        [Required(ErrorMessage = "Price is Required")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Visit Date is Required")]
        public DateTime VisitDate { get; set; }


        [Required(ErrorMessage = "Offer Details is Required")]
        public int RequestID { get; set; }

        public int TechnicianID { get; set; }
    }
}
