using ClinicVp.DataBase;
using ClinicVp.DTOs.Auth;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository.IAuth
{
    public class Auth : IAuth
    {
        private readonly AppDbContext _db;

        public Auth(AppDbContext context)
        {
            _db = context;
        }

        public Task<AuthDto?> GetCredentials(string email)
        {
            var recepcionist = _db.Recepcionists.Where(r => r.Email == email).Select(r => new AuthDto(r.Id, r.Email, r.Password)).FirstOrDefaultAsync();

            if (recepcionist == null)
            {
                var doctor = _db.Doctors.Where(d => d.Email == email).Select(d => new AuthDto(d.Id, d.Email, d.Password)).FirstOrDefaultAsync() ?? throw new KeyNotFoundException();

                return doctor;
            }

            return recepcionist;
        }

    }
}
