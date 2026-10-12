using ClinicVp.DTOs.RecepcionistDto;
using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecepcionistController : ControllerBase
    {

        private readonly RecepcionistService _service;

        public RecepcionistController(RecepcionistService service)
        {
            _service = service;
        }

        [HttpGet("")]
        async public Task<IActionResult> GetAll()
        {
            var recepcionists = await _service.SelectAllRecepcionist();

            return Ok(recepcionists);
        }

        [HttpGet("{id:int}")]
        async public Task<IActionResult> GetId(int id)
        {
            var recepcionist = await _service.SelectRecepcionistId(id);

            return Ok(recepcionist);
        }

        [HttpPost("")]
        async public Task<IActionResult> Post([FromBody] RecepcionistWriteDto body)
        {
            var idRecepcionit = await _service.InsertRecepcionist(body);

            return Ok(idRecepcionit);
        }

        [HttpPut("{id:int}")]
        async public Task<IActionResult> Put([FromBody] RecepcionistWriteDto body, int id)
        {
            var newRecepcionist = await _service.UpdateRecepcionist(body, id);

            if (newRecepcionist == null)
            {
                return NotFound();
            }

            return Ok(newRecepcionist);
        }

        [HttpDelete("{id:int}")]
        async public Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRecepcionist(id);

            return Ok(); ;
        }
    }
}
