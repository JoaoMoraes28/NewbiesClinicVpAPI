using ClinicVp.ConfigurationExtensions.HashedPassword;
using ClinicVp.DTOs.Auth;
using ClinicVp.Repository.IAuth;

namespace ClinicVp.Services
{
    public class AuthService
    {

        private readonly IAuth _repository;

        public AuthService(IAuth repository)
        {
            _repository = repository;
        }

        public async Task<ResponseLogin> PostAuth(AuthWrite body)
        {

            var credentials = await _repository.GetCredentials(body.Email) ?? throw new KeyNotFoundException();

            return new ResponseLogin(SecurityPassword.VerifyPassword(body.Pass, credentials.Pass));

        }

    }
}
