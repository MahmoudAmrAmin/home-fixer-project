using ApiServiceLayer.Services.APIServices;
using HomeService_front.Models.Paging;
using HomeService_front.Models.Specialization;
using HomeService_front.Models.Technician;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeService_front.Controllers
{
    public class ClientController : BaseController
    {
        public ClientController(IAPIService apiService, IConfiguration configuration) : base(apiService, configuration)
        {
        }

        public async Task<IActionResult> Index(int? specializationId, int pageSize = 9, int pageNo = 1, bool needTotalCount = true, bool orderByWorksDesc = false)
        {
            var res = await _apiService.GetPageAsync<PageData<TechnicianVM>>($"Technician/GetAllTechnicians?specializationId={specializationId}&pageSize={pageSize}&pageNo={pageNo}&needTotalCount={needTotalCount}&orderByWorksDesc={orderByWorksDesc}");
           
            var Specializations = await _apiService.GetAsync<List<SpecializationVM>>("Specialization");

            ViewBag.Specializations = new SelectList(Specializations, "SpecializationID", "SpecializationName",specializationId);

            return View(res);
        }
    }
}
