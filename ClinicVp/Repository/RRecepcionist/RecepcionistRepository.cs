using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository.RRecepcionist
{
    public class RecepcionistRepository : IRecepcionist
    {

        private readonly AppDbContext _db;

        public RecepcionistRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<Recepcionist> Add(Recepcionist recepcionist)
        {

            var response = await _db.Recepcionists.AddAsync(recepcionist);

            await _db.SaveChangesAsync();

            return response.Entity;
        }

        public async Task Delete(Recepcionist recepcionist)
        {
            recepcionist.Status = EStatusEmployee.DESACTIVE;

            await _db.SaveChangesAsync();
        }

        public async Task<List<RecepcionistData>> GetAll()
        {
            return await _db.RecepcionistData.Where(r => r.Status != EStatusEmployee.DESACTIVE).ToListAsync();
        }

        public async Task<RecepcionistData?> GetId(int id)
        {
            return await _db.RecepcionistData.FirstOrDefaultAsync(r => r.Id == id && r.Status == EStatusEmployee.ACTIVE);
        }

        public async Task<Recepcionist?> GetEntityId(int id)
        {
            return await _db.Recepcionists.FirstOrDefaultAsync(r => r.Id == id && r.Status == EStatusEmployee.ACTIVE);
        }

        public async Task<Recepcionist> Update(Recepcionist recepcionist, Recepcionist newRecepcionist)
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
