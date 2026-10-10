using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DTOs;
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

            return response.Entity.Id;
        }

        public async Task Delete(Recepcionist recepcionist)
        {
            recepcionist.Status = EStatusEmployee.DESACTIVE;

            await _db.SaveChangesAsync();
        }

        public async Task<List<Recepcionist>> GetAll()
        {
            return await _db.Recepcionists.Where(r => r.Status != EStatusEmployee.DESACTIVE).ToListAsync();
        }

        public async Task<Recepcionist?> GetId(int id)
        {
            return await _db.Recepcionists.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Recepcionist> Update(Recepcionist recepcionist, RecepcionistDto newRecepcionist)
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
