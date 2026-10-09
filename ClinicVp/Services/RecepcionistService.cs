using ClinicVp.DataBase.Models;
using ClinicVp.DTOs.Recepcionist;
using ClinicVp.Repository;

namespace ClinicVp.Services
{
    public class RecepcionistService
    {

        private readonly IRecepcionist _repository;

        public RecepcionistService(IRecepcionist repository)
        {
            _repository = repository;
        }

        public async Task<List<Recepcionist>> SelectAllRecepcionist()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Recepcionist>> SelectRecepcionistId(int id)
        {
            return await _repository.GetId(id);
        }

        public async Task<int> InsertRecepcionist(RecepcionistCreateDto body)
        {
            Recepcionist newRecepcionist = new(body.Name, body.Cpf, body.Email, body.Gender, body.Phone, body.Photo, body.Salary, body.Status, body.Password);

            var idRecepcionist = await _repository.Add(newRecepcionist);

            return idRecepcionist;
        }

        public async Task<Recepcionist?> UpdateRecepcionist(RecepcionistCreateDto body, int id)
        {

            var verifyId = await SelectRecepcionistId(id);

            if (verifyId == null)
            {
                return null;
            }

            var newRecepcionist = await _repository.Update(verifyId[0], body);

            return newRecepcionist;

        }

        public async Task<bool> DeleteRecepcionist(int id)
        {
            var verifyId = SelectRecepcionistId(id);

            if (verifyId == null)
            {
                return false;
            }

            await _repository.Delete(id);

            return true;
        }

    }
}
