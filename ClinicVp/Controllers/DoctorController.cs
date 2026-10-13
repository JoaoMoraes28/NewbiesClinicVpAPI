using ClinicVp.DTOs.DoctorDto;
using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet("")]
        async public Task<IActionResult> GetAll()
        {
            var doctors = await _service.GetAllDoctorsAsync();

            return Ok(doctors);
        }

        [HttpGet("{id:int}")]
        async public Task<IActionResult> GetId(int id)
        {
            var doctor = await _service.GetDoctorByIdAsync(id);

            return Ok(doctor);
        }

        [HttpPost("")]
        async public Task<IActionResult> Post([FromBody] DoctorWriteDto body)
        {
            var idDoctor = await _service.CreateDoctorAsync(body);

            return Ok(idDoctor);
        }

        [HttpPut("{id:int}")]
        async public Task<IActionResult> Put([FromBody] DoctorWriteDto body, int id)
        {
            var newDoctor = await _service.UpdateDoctorAsync(id, body);

            if (newDoctor == null)
            {
                return NotFound();
            }

            return Ok(newDoctor);
        }

        [HttpDelete("{id:int}")]
        async public Task<IActionResult> Delete(int id)
        {
            await _service.DeleteDoctorAsync(id);

            return Ok(); ;
        }
    }
}
