using ClinicVp.DTOs.Auth;
using ClinicVp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> PostCredentials([FromBody] AuthWrite body)
        {
            var login = await _service.PostAuth(body);

            return Ok(login);
        }

    }
}
