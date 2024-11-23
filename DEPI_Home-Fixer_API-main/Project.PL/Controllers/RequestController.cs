using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOs.Request;
using Project.BLL.ServiceContracts;

namespace Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public IActionResult Index(int? cityId, int specializationId, int pageSize = 1, int pageNo = 1, bool needCount = true, bool sortByCity = false)
        {
            return Ok(_requestService.Getpage( cityId , specializationId, pageSize, pageNo, needCount,sortByCity));
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(_requestService.GetById(id));
        }

        [HttpGet("GetByIdForEdit")]

        public IActionResult GetByIdForEdit(int id)
        {
            return Ok(_requestService.GetByIdForEdit(id));
        }

        [HttpGet("SpecializationId")]
        public IActionResult GetAllBySpecializationId(int id)
        {
            return Ok(_requestService.GetAllBySpecializationId(id));
        }

        [HttpPost]
        public ActionResult Insert(AddRequestDto request)
        {
            if (ModelState.IsValid)
            {
                _requestService.Add(request);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _requestService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditRequestDto request)
        {
            _requestService.Update(request);
            return Ok();
        }

       

        [HttpGet("UserId")]
        public IActionResult GetPageByUserId(int userId, int pageSize = 1, int pageNo = 1, bool needCount = true, bool sortByCity = false)
        {
            return Ok(_requestService.GetpageByUserId(userId, pageSize, pageNo, needCount, sortByCity));
        }
    }
}
