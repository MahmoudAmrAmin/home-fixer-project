using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTOs.City;
using Project.BLL.ServiceContracts;

namespace Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public ICityServece _cityServece;

        public CityController(ICityServece cityServece)
        {
            _cityServece = cityServece;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_cityServece.GetAll());

        }
        [HttpGet("GetSpecificNumOfRecords")]
        public async Task<IActionResult> GetSpecificNumOfRecords(int num)
        {
            return Ok(await _cityServece.GetSpecificNumOfRecords(num));

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_cityServece.GetById(id));
        }

        [HttpPost]
        public ActionResult Insert(AddCityDto cityDto)
        {
            _cityServece.Add(cityDto);
            return Ok();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _cityServece.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditCityDto cityDto)
        {
            _cityServece.Update(cityDto);
            return Ok();
        }
    }
}
