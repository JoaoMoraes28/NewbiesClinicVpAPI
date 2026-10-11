using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UfController : ControllerBase
    {

        private readonly UfService _service;

        public UfController(UfService service)
        {
            _service = service;
        }

        [HttpGet("")]
        async public Task<IActionResult> GetAll()
        {

            var ufs = await _service.SelectAllUfs();

            return Ok(ufs);

        }

    }
}
