using ClinicVp.DTOs.ConsultationRecord;
using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [Route("consultation_record")]
    [ApiController]
    public class ConsultationRecordController : ControllerBase
    {

        private readonly ConsultationRecordService _service;

        public ConsultationRecordController(ConsultationRecordService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var consultationsRecord = await _service.SelectConsultationRecordIdConsultation(id);

            return Ok(consultationsRecord);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] ConsultatitonRecordWriteDto body)
        {
            var id = await _service.InsertConsultationRecord(body);

            return Ok(id);
        }

    }
}
