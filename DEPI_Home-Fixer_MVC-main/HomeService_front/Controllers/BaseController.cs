using ApiServiceLayer.Services.APIServices;
using Microsoft.AspNetCore.Mvc;

namespace HomeService_front.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IAPIService _apiService;
        protected readonly IConfiguration _configuration;

        public BaseController(IAPIService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }
    }
}
