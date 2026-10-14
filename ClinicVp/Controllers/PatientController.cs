using ClinicVp.DTOs.PatientDto;
using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly PatientService _service;

        public PatientController(PatientService service)
        {
            _service = service;
        }

        [HttpGet("")]
        async public Task<IActionResult> GetAll()
        {
            var patients = await _service.GetAllPatientsAsync();

            return Ok(patients);
        }

        [HttpGet("{id:int}")]
        async public Task<IActionResult> GetId(int id)
        {
            var patient = await _service.GetPatientByIdAsync(id);

            return Ok(patient);
        }

        [HttpPost("")]
        async public Task<IActionResult> Post([FromBody] PatientWriteDto body)
        {
            var idPatient = await _service.CreatePatientAsync(body);

            return Ok(idPatient);
        }

        [HttpPut("{id:int}")]
        async public Task<IActionResult> Put([FromBody] PatientWriteDto body, int id)
        {
            var newPatient = await _service.UpdatePatientAsync(id, body);

            if (newPatient == null)
            {
                return NotFound();
            }

            return Ok(newPatient);
        }

        [HttpPatch("{id:int}")]
        async public Task<IActionResult> Patch(int id)
        {
            var response = await _service.DeletePatientAsync(id);

            return Ok(response);
        }
    }
}
