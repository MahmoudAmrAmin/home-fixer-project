using ApiServiceLayer.Services.APIServices;
using HomeService_front.Models.Technician;
using Microsoft.AspNetCore.Mvc;

namespace HomeService_front.Controllers
{
    public class TechnicianController : BaseController
    {
        public TechnicianController(IAPIService apiService, IConfiguration configuration) : base(apiService, configuration)
        {
        }

        public async Task <IActionResult> Index()
        {
            var tech = await _apiService.GetAsync<TechnicianVM>("Technician/GetCurrentTechnician");

            return View(tech);
        }

    }
}
