using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOs.Specialization;
using Project.BLL.ServiceContracts;

namespace Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecialization _specializationService;
        public SpecializationController(ISpecialization specializationService)
        {
            _specializationService = specializationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_specializationService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_specializationService.GetById(id));
        }

        [HttpPost]
        public ActionResult Insert(AddSpecializationDto specializationDto)
        {
            _specializationService.Add(specializationDto);
            return Ok();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _specializationService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditSpecializationDto specializationDto)
        {
            _specializationService.Update(specializationDto);
            return Ok();
        }

       
        [HttpGet("GetSpecificNumOfRecords")]
        public async Task<IActionResult> GetSpecificNumOfRecords(int num)
        {
            var Clients = await _specializationService.GetSpecificNumOfRecords(num);

            if (Clients == null)
                return NotFound();

            return Ok(Clients);
        }
    }
}
