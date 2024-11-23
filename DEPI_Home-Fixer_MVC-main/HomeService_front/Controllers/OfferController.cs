using ApiServiceLayer.Services.APIServices;
using HomeService_front.Models.Client;
using HomeService_front.Models.Paging;
using HomeService_front.Models.Technician;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOs.Offer;
using System.Security.Claims;

namespace HomeService_front.Controllers
{
    public class OfferController : BaseController
    {
        public OfferController(IAPIService apiService, IConfiguration configuration) : base(apiService, configuration)
        {
        }

        public IActionResult SendOffer(int requestID, int technicianID)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendOffer(AddOfferVM offer)
        {

            // Extract user ID from claims
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }

            var technician = await _apiService.GetAsync<TechnicianVM>($"Technician/GetTechnician?email={email}");

            offer.TechnicianID = technician.Id;

            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<OfferVM>("Offer", offer);
                return RedirectToAction("Index", "Request");
            }
            return View(offer);
        }

        public async Task<IActionResult> OffersForRequest(int requestId, int pageSize = 9, int pageNo = 1, bool needCount = true, bool sortByPrice = false)
        {
            var res = await _apiService.GetPageAsync<PageData<OfferVM>>($"Offer/GetpageByRequestId?requestId={requestId}&pageSize={pageSize}&pageNo={pageNo}&needCount={needCount}&sortByPrice={sortByPrice}");

            ViewBag.RequestId = requestId;

            return View(res);
        }

        public async Task<IActionResult> OffersDetails(int offerId)
        {
            var res = await _apiService.GetPageAsync<OfferVM>($"Offer/{offerId}");

            return View(res);
        }

        public async Task<IActionResult> AcceptOffer(int offerId)
        {
            await _apiService.PutWithOutBodyAsync($"Offer/AcceptOffer?offerId={offerId}");

            return RedirectToAction("ClientAcceptedOffer");
        }

        public async Task<IActionResult> RejectOffer(int offerId, int requestId)
        {
            await _apiService.PutWithOutBodyAsync($"Offer/RejectOffer?offerId={offerId}");
            return RedirectToAction("OffersForRequest", new { requestId = requestId });
        }

        public async Task<IActionResult> ClientAcceptedOffer(int pageSize = 2, int pageNo = 1, bool needCount = true, bool sortByPrice = false)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }

            var client = await _apiService.GetAsync<ClientVM>($"Client?email={email}");

            var res = await _apiService.GetPageAsync<PageData<AcceptedOfferVM>>($"Offer/GetPageAcceptedOffersForClient?clientId={client.Id}&pageSize={pageSize}&pageNo={pageNo}&needCount={needCount}&sortByPrice={sortByPrice}");

            return View(res);
        }

        public async Task<IActionResult> TechnicianAcceptedOffer(int pageSize = 2, int pageNo = 1, bool needCount = true, bool sortByPrice = false)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }

            var technician = await _apiService.GetAsync<TechnicianVM>($"Technician/GetTechnician?email={email}");

            var res = await _apiService.GetPageAsync<PageData<AcceptedOfferVM>>($"Offer/GetPageAcceptedOffersForTechnician?technicianId={technician.Id}&pageSize={pageSize}&pageNo={pageNo}&needCount={needCount}&sortByPrice={sortByPrice}");

            return View(res);
        }

    }
}
