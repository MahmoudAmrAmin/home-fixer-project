using ApiServiceLayer.Services.APIServices;
using HomeService_front.Models.Admin;
using HomeService_front.Models.City;
using HomeService_front.Models.Client;
using HomeService_front.Models.Specialization;
using HomeService_front.Models.Technician;
using Microsoft.AspNetCore.Mvc;

namespace HomeService_front.Controllers
{
    public class AdminController : BaseController
    {
        private readonly int MAXNUM = 5;
        public AdminController(IAPIService apiService, IConfiguration configuration) : base(apiService, configuration)
        {
        }

        public async Task<IActionResult> Index()
        {
            var adminVM = new AdminIndexVM();

            adminVM.Cites = await GetCites();
            adminVM.CitesCount = await GetCitesCount();

            adminVM.Clients = await GetClients();
            adminVM.ClientsCount = await GetClientsCount();

            adminVM.Technicians = await GetTechnicians();
            adminVM.TechniciansCount = await GetTechniciansCount();

            adminVM.Specializations = await GeSpecializations();
            adminVM.SpecializationCount = await GetSpecializationsCount();

            return View(adminVM);
        }

        private async Task<List<CityVM>> GetCites()
        {
            var res = await _apiService.GetAsync<List<CityVM>>($"City/GetSpecificNumOfRecords?num={MAXNUM}");

            return res;
        }  
        private async Task<int> GetCitesCount()
        {
            var res = await _apiService.GetAsync<List<CityVM>>("City");
            return res.Count();
        }

        private async Task<List<ClientVM>> GetClients()
        {
            var res = await _apiService.GetAsync<List<ClientVM>>($"Client/GetSpecificNumOfRecords?num={MAXNUM}");

            return res;
        }

        private async Task<int> GetClientsCount()
        {
            var res = await _apiService.GetAsync<List<ClientVM>>("Client/GetAll");
            return res.Count();
        }

        private async Task<List<TechnicianVM>> GetTechnicians()
        {
            var res = await _apiService.GetAsync<List<TechnicianVM>>($"Technician/GetSpecificNumOfRecords?num={MAXNUM}");

            return res;
        }

        private async Task<int> GetTechniciansCount()
        {
            var res = await _apiService.GetAsync<List<TechnicianVM>>("Technician/GetAll");
            return res.Count();
        }
        
        
        private async Task<List<SpecializationVM>> GeSpecializations()
        {
            var res = await _apiService.GetAsync<List<SpecializationVM>>($"Specialization/GetSpecificNumOfRecords?num={MAXNUM}");

            return res;
        }

        private async Task<int> GetSpecializationsCount()
        {
            var res = await _apiService.GetAsync<List<SpecializationVM>>("Specialization");
            return res.Count();
        }

      
    }
}
