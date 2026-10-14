using ClinicVp.DTOs.ContractType;
using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [Route("contract_doctor")]
    [ApiController]
    public class ContractDoctorController : ControllerBase
    {
        private readonly ContractDoctorService _service;

        public ContractDoctorController(ContractDoctorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContractDoctorWrite body)
        {
            var response = await _service.InsertContractDoctor(body);

            return Ok(response);
        }

        [HttpDelete("{idDoctor:int}")]
        public async Task<IActionResult> Delete(int idDoctor)
        {
            var response = await _service.DeleteContractDoctor(idDoctor);

            return Ok(response);
        }
    }
}
