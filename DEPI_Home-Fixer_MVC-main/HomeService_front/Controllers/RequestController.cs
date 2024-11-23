using ApiServiceLayer.Services.APIServices;
using HomeService_front.Helpers;
using HomeService_front.Models.City;
using HomeService_front.Models.Client;
using HomeService_front.Models.Paging;
using HomeService_front.Models.Request;
using HomeService_front.Models.Specialization;
using HomeService_front.Models.Technician;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace HomeService_front.Controllers
{
    public class RequestController : BaseController
    {
        public RequestController(IAPIService apiService, IConfiguration configuration) : base(apiService, configuration)
        {
        }

        public async Task<IActionResult> Index(int? cityId, int pageSize = 9, int pageNo = 1, bool needCount = true, bool sortByCity = false)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized(); 
            }

            var technician = await _apiService.GetAsync<TechnicianVM>($"Technician/GetTechnician?email={email}");
            int id = technician.SpecializationId;
            var requests = await _apiService.GetPageAsync<PageData<RequestVM>>($"Request?cityId={cityId}&specializationId={id}&pageSize={pageSize}&pageNo={pageNo}&needCount={needCount}&sortByCity={sortByCity}");

            var requestIndexVM = new RequestIndexVM
            {
                Data = requests,
                SpecializationId = id,
                SpecializationName = technician.SpecializationName,
            };

            var cities = await _apiService.GetAsync<List<CityVM>>("City");

            ViewBag.Cities = new SelectList(cities, "CityId", "CityName");

            return View(requestIndexVM);
        }

        public async Task<IActionResult> RequestDetails(int id)
        {
            var request = await _apiService.GetPageAsync<RequestVM>($"Request/id?id={id}");

            return View(request);
        }

        public async Task<IActionResult> CreateRequest()
        {
            var Specializations = await _apiService.GetAsync<List<SpecializationVM>>("Specialization");
            ViewBag.Specializations = new SelectList(Specializations, "SpecializationID", "SpecializationName");

            var cities = await _apiService.GetAsync<List<CityVM>>("City");
            ViewBag.Cities = new SelectList(cities, "CityId", "CityName");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestVM create)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized(); // No valid user found
            }

            var client = await _apiService.GetAsync<ClientVM>($"Client?email={email}");
            create.UserId = client.Id;
            if (ModelState.IsValid)
            {
                create.photosUrl = create.Photos.Select(p => DocumentsSettings.UploadFile(p, "Images")).ToList();

                await _apiService.PostWithOutBodyAsync($"Request", create);

                return RedirectToAction("MyRequests");

            }
            var Specializations = await _apiService.GetAsync<List<SpecializationVM>>("Specialization");
            ViewBag.Specializations = new SelectList(Specializations, "SpecializationID", "SpecializationName");

            var cities = await _apiService.GetAsync<List<CityVM>>("City");
            ViewBag.Cities = new SelectList(cities, "CityId", "CityName");

            return View(create);
        }

        public async Task<IActionResult> MyRequests(int pageSize = 4, int pageNo = 1, bool needCount = true, bool sortByCity = false)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }

            var client = await _apiService.GetAsync<ClientVM>($"Client?email={email}");
            int userId = client.Id;

            var requests = await _apiService.GetPageAsync<PageData<RequestVM>>($"Request/UserId?userId={userId}&pageSize={pageSize}&pageNo={pageNo}&needCount={needCount}&sortByCity={sortByCity}");


            return View(requests);
        }

        public async Task<IActionResult> EditRequest(int requestId)
        {
            RequestVMForEdit request = await _apiService.GetAsync<RequestVMForEdit>($"Request/GetByIdForEdit?id={requestId}");

            
            var Specializations = await _apiService.GetAsync<List<SpecializationVM>>("Specialization");
            ViewBag.Specializations = new SelectList(Specializations, "SpecializationID", "SpecializationName", request.SpecializationID);

            var cities = await _apiService.GetAsync<List<CityVM>>("City");
            ViewBag.Cities = new SelectList(cities, "CityId", "CityName", request.CityId);

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> EditRequest(int requestId, RequestVMForEdit requestVM)
        {
            requestVM.RequestId = requestId;
            if (ModelState.IsValid)
            {
                await _apiService.PutWithOutBodyAsync("Request", requestVM);
                return RedirectToAction("MyRequests", "Request");
            }

            var Specializations = await _apiService.GetAsync<List<SpecializationVM>>("Specialization");
            ViewBag.Specializations = new SelectList(Specializations, "SpecializationID", "SpecializationName", requestVM.SpecializationID);

            var cities = await _apiService.GetAsync<List<CityVM>>("City");
            ViewBag.Cities = new SelectList(cities, "CityId", "CityName", requestVM.CityId);

            return View(requestVM);
        }

        public async Task<IActionResult> DeleteRequest(int requestId )
        {
            await _apiService.DeleteAsync($"Request?id={requestId}");
            TempData["Message"] = "Request Deleted Successfully";
            return RedirectToAction("MyRequests", "Request");
        }
    }
}
