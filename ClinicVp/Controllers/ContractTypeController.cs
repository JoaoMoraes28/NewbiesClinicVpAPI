using ClinicVp.DTOs.ContractType;
using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [Route("contract_type")]
    [ApiController]
    public class ContractTypeController : ControllerBase
    {

        private readonly ContractTypeService _service;

        public ContractTypeController(ContractTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contracts = await _service.SelectAllContracts();

            return Ok(contracts);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContractWriteDto contract)
        {
            var response = await _service.InsertContract(contract);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteContract(id);

            return Ok(response);
        }
    }
}
