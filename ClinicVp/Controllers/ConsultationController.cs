using ClinicVp.DTOs.Consultation;
using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly ConsultationService _service;

        public ConsultationController(ConsultationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consultations = await _service.SelectAllConsultation();

            return Ok(consultations);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var consultation = await _service.SelectConsultationId(id);

            return Ok(consultation);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConsultationWriteDto body)
        {
            var newConsultation = await _service.InsertConsultation(body);

            return Ok(newConsultation);

        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id, [FromBody] ConsultationNewStatusDto newStatus)
        {
            var response = await _service.UpdateStatusConsultation(id, newStatus.NewStatus);

            return Ok(response);
        }
    }
}
