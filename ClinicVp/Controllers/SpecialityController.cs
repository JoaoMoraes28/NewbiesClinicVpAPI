using ClinicVp.DTOs.Speciality;
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
        async public Task<IActionResult> Get()
        {
            var specialitys = await _service.SelectSpeciality();

            return Ok(specialitys);
        }

        [HttpPost("")]
        async public Task<IActionResult> Post([FromBody] SpecialityCreateDto body)
        {
            var specialityId = await _service.InsertSpeciality(body);

            return Ok(specialityId);
        }
    }
}
