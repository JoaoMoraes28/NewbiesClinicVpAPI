using ClinicVp.ConfigurationExtensions.HashedPassword;
using Microsoft.AspNetCore.Mvc;

namespace ClinicVp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpPost("")]
        public string GetPassHash([FromBody] PasswordCreate password)
        {

            var hashPass = SecurityPassword.GetPassHashed(password.Password);

            Console.WriteLine(SecurityPassword.VerifyPassword(password.NewPassword, hashPass));

            return hashPass;

        }

    }

    public class PasswordCreate
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }

        public PasswordCreate(string password, string newPassword)
        {
            Password = password;
            NewPassword = newPassword;
        }
    }
}
