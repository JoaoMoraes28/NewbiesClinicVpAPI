using ClinicVp.DTOs.Auth;

namespace ClinicVp.Repository.IAuth
{
    public interface IAuth
    {

        Task<AuthDto?> GetCredentials(string email);

    }
}
