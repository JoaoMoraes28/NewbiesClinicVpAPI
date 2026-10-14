using ClinicVp.DTOs.SpecialityDto;
using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecialityController : ControllerBase
    {

        private readonly SpecialityService _service;

        public SpecialityController(SpecialityService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var specialitys = await _service.SelectSpeciality();

            return Ok(specialitys);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] SpecialityDto body)
        {
            var specialityId = await _service.InsertSpeciality(body);

            return Ok(specialityId);
        }
    }
}
