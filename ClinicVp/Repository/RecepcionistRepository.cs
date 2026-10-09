using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DTOs.Recepcionist;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository
{
    public class RecepcionistRepository : IRecepcionist
    {

        private readonly AppDbContext _db;

        public RecepcionistRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<int> Add(Recepcionist recepcionist)
        {

            var response = await _db.Recepcionists.AddAsync(recepcionist);
            await _db.SaveChangesAsync();

            return response.Entity.Id;
        }

        public async Task Delete(int id)
        {
            await _db.Recepcionists.Where(e => e.Id == id).ExecuteDeleteAsync();
            await _db.SaveChangesAsync();
        }

        public async Task<List<Recepcionist>> GetAll()
        {
            return await _db.Recepcionists.ToListAsync();
        }

        public async Task<List<Recepcionist>> GetId(int id)
        {
            return await _db.Recepcionists.Where(e => e.Id == id).ToListAsync();
        }

        public async Task<Recepcionist> Update(Recepcionist recepcionist, RecepcionistCreateDto newRecepcionist)
        {
            recepcionist.Name = newRecepcionist.Name;
            recepcionist.Cpf = newRecepcionist.Cpf;
            recepcionist.Email = newRecepcionist.Email;
            recepcionist.Photo = newRecepcionist.Photo;
            recepcionist.Phone = newRecepcionist.Phone;
            recepcionist.Salary = newRecepcionist.Salary;
            recepcionist.Gender = newRecepcionist.Gender;

            await _db.SaveChangesAsync();

            return recepcionist;
        }
    }
}
