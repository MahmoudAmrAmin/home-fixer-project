using Microsoft.AspNetCore.Mvc;
using Project.BLL.ServiceContracts;

namespace Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService userService)
        {
            _clientService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string email)
        {
            var user = await _clientService.GetCurrentUser(email);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Clients = _clientService.GetAll();

            if (Clients == null)
                return NotFound();

            return Ok(Clients);
        }

        [HttpGet("GetSpecificNumOfRecords")]
        public async Task<IActionResult> GetSpecificNumOfRecords(int num)
        {
            var Clients = await _clientService.GetSpecificNumOfRecords(num);

            if (Clients == null)
                return NotFound();

            return Ok(Clients);
        }

    }
}
