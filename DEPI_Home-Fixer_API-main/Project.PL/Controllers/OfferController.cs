using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOs.Offer;
using Project.BLL.DTOs.Pagination;
using Project.BLL.ServiceContracts;
using Project.BLL.Services;

namespace Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {

        private readonly IOfferService _offerService;
        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_offerService.GetAll());
        }

        [HttpGet("requestId")]
        public IActionResult GetAll(int requestId)
        {
            return Ok(_offerService.GetOffersByRequestId(requestId));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_offerService.GetById(id));
        }

        [HttpPost]
        public ActionResult Add(AddOfferDto offer)
        {
            _offerService.Add(offer);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _offerService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditOfferDto offer)
        {
            _offerService.Update(offer);
            return Ok();
        }

        [HttpPut("AcceptOffer")]
        public IActionResult AcceptOffer(int offerId)
        {
            _offerService.AcceptOffer(offerId);
            return Ok();
        }

        [HttpPut("RejectOffer")]
        public IActionResult RejectOffer(int offerId)
        {
            _offerService.RejectOffer(offerId);
            return Ok();
        }

        [HttpGet("AcceptedOffers")]
        public IActionResult GetAcceptedOffersByRequestId(int requestId)
        {
            return Ok(_offerService.GetAcceptedOffersByRequestId(requestId));
        }

        [HttpGet("GetpageByRequestId")]
        public IActionResult GetPage(int requestId, int pageSize = 1, int pageNo = 1, bool needCount = true, bool sortByPrice = false)
        {
            return Ok(_offerService.GetpageByRequestId(requestId, pageSize, pageNo, needCount, sortByPrice));
        }

        [HttpGet("GetPageAcceptedOffersForClient")]
        public IActionResult GetPageAcceptedOffersForClient(int clientId, int pageSize, int pageNo, bool needCount, bool sortByPrice = false)
        {
            return Ok(_offerService.GetPageAcceptedOffersForClient(clientId, pageSize, pageNo, needCount, sortByPrice));
        }

        [HttpGet("GetPageAcceptedOffersForTechnician")]
        public IActionResult GetPageAcceptedOffersForTechnician(int technicianId, int pageSize, int pageNo, bool needCount, bool sortByPrice = false)
        {
            return Ok(_offerService.GetPageAcceptedOffersForTechnician(technicianId, pageSize, pageNo, needCount, sortByPrice));
        }
    }
}
