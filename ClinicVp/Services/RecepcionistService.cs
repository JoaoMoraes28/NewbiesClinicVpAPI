using ClinicVp.DataBase.Models;
using ClinicVp.DTOs;
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

        public async Task<Recepcionist?> SelectRecepcionistId(int id)
        {
            return await _repository.GetId(id);
        }

        public async Task<int> InsertRecepcionist(RecepcionistDto body)
        {
            Recepcionist newRecepcionist = new(body.Name, body.Cpf, body.Email, body.Gender, body.Phone, body.Photo, body.Salary, body.Status, body.Password);

            var idRecepcionist = await _repository.Add(newRecepcionist);

            return idRecepcionist;
        }

        public async Task<Recepcionist> UpdateRecepcionist(RecepcionistDto body, int id)
        {

            var verifyId = await SelectRecepcionistId(id);

            if (verifyId == null)
                throw new KeyNotFoundException();


            var newRecepcionist = await _repository.Update(verifyId, body);

            return newRecepcionist;

        }

        public async Task DeleteRecepcionist(int id)
        {
            var verifyId = await SelectRecepcionistId(id);

            if (verifyId == null)
                throw new KeyNotFoundException();

            await _repository.Delete(verifyId);
        }

    }
}
