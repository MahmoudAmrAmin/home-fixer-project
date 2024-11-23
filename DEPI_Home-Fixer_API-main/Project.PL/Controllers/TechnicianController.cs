using Microsoft.AspNetCore.Mvc;
using Project.BLL.ServiceContracts;

namespace Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private readonly ITechnicianService _technicianService;

        public TechnicianController(ITechnicianService technicianService)
        {
            _technicianService = technicianService;
        }
        [HttpGet]
        public IActionResult GetTechnicianFinishedRequests()
        {
            return Ok(User);
        }

        [HttpGet("GetTechnician")]
        public async Task<IActionResult> GetTechnician(string email)
        {
            try
            {

                // Now you can pass the userId to your service
                var user = await _technicianService.GetById(email);
                if (user == null)
                {
                    return NotFound(); // User not found
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllTechnicians")]
        public IActionResult GetAllTechnicians(int? specializationId, int pageSize, int pageNo, bool needTotalCount, bool orderByWorksDesc = false)
        {
            var res = _technicianService.GetPage(specializationId, pageSize, pageNo, needTotalCount, orderByWorksDesc);

            return Ok(res);
        }

        [HttpGet("GetSpecificNumOfRecords")]
        public async Task<IActionResult> GetSpecificNumOfRecords(int num)
        {
            return Ok(await _technicianService.GetSpecificNumOfRecords(num));

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _technicianService.GetAll());

        }

    }
}


